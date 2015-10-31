namespace StudentSystem.Services.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Models;
    using Data;
    using Data.Repositories;
    using StudentSystem.Models;

    public class TestsController : ApiController
    {
        public ICollection<Test> Get()
        {
            var db = new StudentSystemDbContext();
            var testsRepo = new GenericRepository<Test>(db);
            List<Test> tests = testsRepo.All().ToList();
            return tests;
        }

        public IHttpActionResult Post(TestRequestModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            var db = new StudentSystemDbContext();
            var testsRepo = new GenericRepository<Test>(db);
            var coursesRepo = new GenericRepository<Course>(db);
            List<Course> allCourses = coursesRepo.All().ToList();
            var testCourse = new Course
            {
                Name = model.Course.Name,
                Description = model.Course.Description
            };

            var testToAdd = new Test
            {
                Course = testCourse
            };

            testsRepo.Add(testToAdd);
            testsRepo.SaveChanges();
            return this.Ok();
        }
    }
}