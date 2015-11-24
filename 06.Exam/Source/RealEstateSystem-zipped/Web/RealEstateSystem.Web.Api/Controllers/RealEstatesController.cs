namespace RealEstateSystem.Web.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using AutoMapper.QueryableExtensions;
    using Data.Models;
    using DataTransferModels;
    using Infrastructure.IdentityProviders.Contracts;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;

    [RoutePrefix("api/RealEstates")]
    public class RealEstatesController : ApiController
    {
        private const string InvalidTakeMessage = "You cannot take more than 100 real estate descriptions at once.";
        private const string InvalidParametersMessage = "You cannot skip or take less than 0 real estate descriptions.";
        private const string InvalidIdMessage = "Invalid Id.";
        private const string InvalidModelMessage = "Invalid model.";

        private readonly IRealEstateService realEstates;
        private readonly IIdentityProvider identityProvider;

        public RealEstatesController(IRealEstateService realEstates, IIdentityProvider identityProvider)
        {
            this.realEstates = realEstates;
            this.identityProvider = identityProvider;
        }

        [HttpGet]
        public IHttpActionResult GetPublicRealEstates(int skip = 0, int take = 10)
        {
            if (skip < 0 || take < 0)
            {
                return this.BadRequest(InvalidParametersMessage);
            }

            if (take > 100)
            {
                return this.BadRequest(InvalidTakeMessage);
            }

            IQueryable<RealEstatePublicResponseModel> result = this.realEstates
                .GetSpecific(skip, take)
                .ProjectTo<RealEstatePublicResponseModel>();

            return this.Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetRealEstateById(int id)
        {
            IQueryable<RealEstate> data = this.realEstates
                    .GetById(id);
            if (data.FirstOrDefault() == null)
            {
                return this.BadRequest(InvalidIdMessage);
            }

            if (this.identityProvider.GetIdentity().IsAuthenticated)
            {
                RealEstatePrivateResponseModel result = data
                    .ProjectTo<RealEstatePrivateResponseModel>()
                    .FirstOrDefault();

                return this.Ok(result);
            }
            else
            {
                RealEstatePublicDetailedResponseModel result = data
                    .ProjectTo<RealEstatePublicDetailedResponseModel>()
                    .FirstOrDefault();

                return this.Ok(result);
            }
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult CreateRealEstateAd(RealEstateRequestModel model)
        {
            if (!this.ModelState.IsValid || model == null)
            {
                return this.BadRequest(InvalidModelMessage);
            }

            var entry = new RealEstate
            {
                Title = model.Title,
                Description = model.Description,
                Address = model.Address,
                Contact = model.Contact,
                UserName = this.identityProvider.GetIdentity().GetUserId(),
                CreatedOn = DateTime.Now,
                RentingPrice = model.RentingPrice,
                SellingPrice = model.SellingPrice,
                Type = (RealEstateType)model.Type,
                ConstructionYear = model.ConstructionYear
            };

            if (model.RentingPrice != null && model.SellingPrice == null)
            {
                entry.Status = RealEstateStatus.ForRenting;
            }
            else if (model.RentingPrice == null && model.SellingPrice != null)
            {
                entry.Status = RealEstateStatus.ForSelling;
            }
            else if (model.RentingPrice != null && model.SellingPrice != null)
            {
                entry.Status = RealEstateStatus.ForRentingAndSelling;
            }
            else
            {
                entry.Status = RealEstateStatus.ForRenting;
            }

            this.realEstates.Add(entry);

            IQueryable<RealEstate> response = this.realEstates
                .All()
                .Where(
                x => x.Title == entry.Title &&
                x.Description == entry.Description &&
                x.UserName == entry.UserName);

            return this.Created("api/RealEstates", response.ProjectTo<RealEstatePublicResponseModel>());
        }
    }
}