namespace ArtistsSystem.Services.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using ArtistsSystem.Models.People;
    using ArtistsSystem.Models.Places;
    using Common;
    using Contracts;
    using Models;

    public class SingersController : BaseController
    {
        [HttpGet]
        public ICollection<Singer> Get()
        {
            ICollection<Singer> singers = this.data.SingersRepository.All().ToList();
            return singers;
        }

        [HttpPost]
        public IHttpActionResult Post(SingerRequestModel request)
        {
            if (request == null)
            {
                return this.BadRequest(GlobalMessages.EntityMustNotBeNullMessage);
            }

            var singer = new Singer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age
            };
            
            Country defaultCountry = this.data.CountriesRepository.All().FirstOrDefault();

            singer.Country = defaultCountry;
            this.data.SingersRepository.Add(singer);
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

            this.data.SingersRepository.Delete(id);
            int result = this.data.SaveChanges();
            return this.Ok($"{GlobalMessages.EntitySuccessfullyDeletedMessage} - {result}");
        }

        [HttpPut]
        public IHttpActionResult Update(string id, SingerRequestModel request)
        {
            if (id == null)
            {
                return this.BadRequest(GlobalMessages.IdMustNotBeNullMessage);
            }

            if (request == null)
            {
                return this.BadRequest(GlobalMessages.EntityMustNotBeNullMessage);
            }

            Singer entity = this.data.SingersRepository.FindById(id);
            if (entity == null)
            {
                return this.BadRequest(GlobalMessages.EntityDoesNotExist);
            }

            // Map the request model to the db model
            if (request.FirstName != default(string))
            {
                entity.FirstName = request.FirstName;
            }

            if (request.LastName != default(string))
            {
                entity.LastName = request.LastName;
            }

            if (request.Age != default(short))
            {
                entity.Age = request.Age;
            }

            this.data.SingersRepository.Update(entity);
            int result = this.data.SaveChanges();
            return this.Ok($"{GlobalMessages.EntitySuccessfullyUpdatedMessage} - {result}");
        }
    }
}