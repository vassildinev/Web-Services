namespace StudentSystem.Services.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Models;
    using Data;
    using Data.Repositories;
    using StudentSystem.Models;

    public class CoursesController : ApiController
    {
        public ICollection<Course> Get()
        {
            var db = new StudentSystemDbContext();
            var coursesRepo = new GenericRepository<Course>(db);
            List<Course> courses = coursesRepo.All().ToList();
            return courses;
        }

        public IHttpActionResult Post(CourseRequestModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            var db = new StudentSystemDbContext();
            var coursesRepo = new GenericRepository<Course>(db);
            var courseToAdd = new Course
            {
                Name = model.Name,
                Description = model.Description
            };

            coursesRepo.Add(courseToAdd);
            coursesRepo.SaveChanges();
            return this.Ok();
        }
    }
}