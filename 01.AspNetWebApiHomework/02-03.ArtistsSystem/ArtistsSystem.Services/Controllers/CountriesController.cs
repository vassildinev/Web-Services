namespace ArtistsSystem.Services.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using ArtistsSystem.Models.Places;
    using Common;
    using Contracts;
    using Models;

    public class CountriesController : BaseController
    {
        [HttpGet]
        public ICollection<Country> Get()
        {
            ICollection<Country> countries = this.data.CountriesRepository.All().ToList();
            return countries;
        }

        [HttpPost]
        public IHttpActionResult Post(CountryRequestModel request)
        {
            if (request == null)
            {
                return this.BadRequest(GlobalMessages.EntityMustNotBeNullMessage);
            }

            var country = new Country
            {
                Name = request.Name
            };

            this.data.CountriesRepository.Add(country);
            int result = this.data.SaveChanges();
            return this.Ok($"{GlobalMessages.EntitySuccessfullyAddedMessage} - {result}");
        }

        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            if (id == null)
            {
                return this.BadRequest(GlobalMessages.IdMustNotBeNullMessage);
            }

            this.data.CountriesRepository.Delete(id);
            int result = this.data.SaveChanges();
            return this.Ok($"{GlobalMessages.EntitySuccessfullyDeletedMessage} - {result}");
        }

        [HttpPut]
        public IHttpActionResult Update(string id, CountryRequestModel request)
        {
            if (id == null)
            {
                return this.BadRequest(GlobalMessages.IdMustNotBeNullMessage);
            }

            if (request == null)
            {
                return this.BadRequest(GlobalMessages.EntityMustNotBeNullMessage);
            }

            Country entity = this.data.CountriesRepository.FindById(id);
            if (entity == null)
            {
                return this.BadRequest(GlobalMessages.EntityDoesNotExist);
            }
            
            // Map the request model to the db model
            entity.Name = request.Name;

            this.data.CountriesRepository.Update(entity);
            int result = this.data.SaveChanges();
            return this.Ok($"{GlobalMessages.EntitySuccessfullyUpdatedMessage} - {result}");
        }
    }
}