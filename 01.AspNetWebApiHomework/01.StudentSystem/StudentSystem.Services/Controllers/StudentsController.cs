namespace StudentSystem.Services.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Models;
    using Data;
    using Data.Repositories;
    using StudentSystem.Models;


    public class StudentsController : ApiController
    {
        public ICollection<Student> Get()
        {
            var db = new StudentSystemDbContext();
            var studentsRepo = new GenericRepository<Student>(db);
            List<Student> students = studentsRepo.All().ToList();
            return students;
        }

        public IHttpActionResult Post(StudentRequestModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            var db = new StudentSystemDbContext();
            var studentsRepo = new GenericRepository<Student>(db);
            var studentToAdd = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Level = model.Level
            };

            studentsRepo.Add(studentToAdd);
            studentsRepo.SaveChanges();
            return this.Ok();
        }
    }
}