namespace ArtistsSystem.Services.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using ArtistsSystem.Models.MusicItems;
    using ArtistsSystem.Models.People;
    using Contracts;
    using Common;
    using Models;

    public class SongsController : BaseController
    {
        [HttpGet]
        public ICollection<Song> Get()
        {
            ICollection<Song> songs = this.data.SongsRepository.All().ToList();
            return songs;
        }

        [HttpPost]
        public IHttpActionResult Post(SongRequestModel request)
        {
            if (request == null)
            {
                return this.BadRequest(GlobalMessages.EntityMustNotBeNullMessage);
            }

            var song = new Song
            {
                Title = request.Title,
                Genre = request.Genre,
                Year = request.Year
            };

            Singer defaultSinger = this.data.SingersRepository.All().FirstOrDefault();
            song.Singer = defaultSinger;

            this.data.SongsRepository.Add(song);
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

            this.data.SongsRepository.Delete(id);
            int result = this.data.SaveChanges();
            return this.Ok($"{GlobalMessages.EntitySuccessfullyDeletedMessage} - {result}");
        }

        [HttpPut]
        public IHttpActionResult Update(string id, SongRequestModel request)
        {
            if (id == null)
            {
                return this.BadRequest(GlobalMessages.IdMustNotBeNullMessage);
            }

            if (request == null)
            {
                return this.BadRequest(GlobalMessages.EntityMustNotBeNullMessage);
            }

            Song entity = this.data.SongsRepository.FindById(id);
            if (entity == null)
            {
                return this.BadRequest(GlobalMessages.EntityDoesNotExist);
            }

            // Map the request model to the db model
            if (request.Title != default(string))
            {
                entity.Title = request.Title;
            }

            if (request.Genre != default(string))
            {
                entity.Genre = request.Genre;
            }

            if (request.Year != default(short))
            {
                entity.Year = request.Year;
            }

            this.data.SongsRepository.Update(entity);
            int result = this.data.SaveChanges();
            return this.Ok($"{GlobalMessages.EntitySuccessfullyUpdatedMessage} - {result}");
        }
    }
}