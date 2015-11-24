namespace RealEstateSystem.Web.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Data.Repositories;
    using DataTransferModels;
    using Infrastructure.IdentityProviders;
    using Infrastructure.IdentityProviders.Contracts;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using Services.Data.Contracts;

    [RoutePrefix("api/Comments")]
    public class CommentsController : ApiController
    {
        private const string InvalidTakeMessage = "You cannot take more than 100 real estate descriptions at once.";
        private const string InvalidParametersMessage = "You cannot skip or take less than 0 real estate descriptions.";
        private const string InvalidIdMessage = "Invalid Id.";
        private const string InvalidModelMessage = "Invalid model.";

        private readonly ICommentsService comments;
        private readonly IIdentityProvider identityProvider;

        public CommentsController()
        {
            this.comments = new CommentsService(new GenericRepository<Comment>(new RealEstateSystemDbContext()));
            this.identityProvider = new AspNetIdentityProvider();
        }

        public CommentsController(ICommentsService comments, IIdentityProvider identityProvider)
        {
            this.comments = comments;
            this.identityProvider = identityProvider;
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public IHttpActionResult GetCommentsByRealEstateId(int id, int skip = 0, int take = 10)
        {
            if (skip < 0 || take < 0)
            {
                return this.BadRequest(InvalidParametersMessage);
            }

            if (take > 100)
            {
                return this.BadRequest(InvalidTakeMessage);
            }

            IQueryable<CommentResponseModel> result = this.comments
                .GetByRealEstateId(id, skip, take)
                .ProjectTo<CommentResponseModel>();

            return this.Ok(result);
        }

        [HttpGet]
        [Authorize]
        [Route("ByUser/{id}")]
        public IHttpActionResult GetCommentsByUserId(string id, int skip = 0, int take = 10)
        {
            if (id == null)
            {
                return this.BadRequest(InvalidParametersMessage);
            }

            if (skip < 0 || take < 0)
            {
                return this.BadRequest(InvalidParametersMessage);
            }

            if (take > 100)
            {
                return this.BadRequest(InvalidTakeMessage);
            }

            IQueryable<CommentResponseModel> result = this.comments
                .GetByUserId(id, skip, take)
                .ProjectTo<CommentResponseModel>();

            return this.Ok(result);
        }


        [Authorize]
        [HttpPost]
        [Route("")]
        public IHttpActionResult AddComment(CommentRequestModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest(InvalidModelMessage);
            }

            var entity = new Comment
            {
                Content = model.Content,
                UserName = this.identityProvider.GetIdentity().GetUserId(),
                CreatedOn = DateTime.Now,
                RealEstateId = model.RealEstateId
            };

            this.comments.Add(entity);

            CommentResponseModel response = this.comments
                .All()
                .Where(x => x.RealEstateId == entity.RealEstateId & x.Content == entity.Content)
                .ProjectTo<CommentResponseModel>()
                .FirstOrDefault();

            return this.Created("api/Comments", response);
        }
    }
}