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

    public class ProducersController : BaseController
    {
        [HttpGet]
        public ICollection<Producer> Get()
        {
            ICollection<Producer> producers = this.data.ProducersRepository.All().ToList();
            return producers;
        }

        [HttpPost]
        public IHttpActionResult Post(ProducerRequestModel request)
        {
            if (request == null)
            {
                return this.BadRequest(GlobalMessages.EntityMustNotBeNullMessage);
            }

            var producer = new Producer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age
            };

            Country defaultCountry = this.data.CountriesRepository.All().FirstOrDefault();

            producer.Country = defaultCountry;
            this.data.ProducersRepository.Add(producer);
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

            this.data.ProducersRepository.Delete(id);
            int result = this.data.SaveChanges();
            return this.Ok($"{GlobalMessages.EntitySuccessfullyDeletedMessage} - {result}");
        }

        [HttpPut]
        public IHttpActionResult Update(string id, ProducerRequestModel request)
        {
            if (id == null)
            {
                return this.BadRequest(GlobalMessages.IdMustNotBeNullMessage);
            }

            if (request == null)
            {
                return this.BadRequest(GlobalMessages.EntityMustNotBeNullMessage);
            }

            Producer entity = this.data.ProducersRepository.FindById(id);
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

            this.data.ProducersRepository.Update(entity);
            int result = this.data.SaveChanges();
            return this.Ok($"{GlobalMessages.EntitySuccessfullyUpdatedMessage} - {result}");
        }
    }
}