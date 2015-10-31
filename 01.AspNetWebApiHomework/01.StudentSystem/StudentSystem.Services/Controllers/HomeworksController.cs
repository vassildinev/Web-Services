namespace StudentSystem.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Models;
    using Data;
    using Data.Repositories;
    using StudentSystem.Models;

    public class HomeworksController : ApiController
    {
        public ICollection<Homework> Get()
        {
            var db = new StudentSystemDbContext();
            var homeworksRepo = new GenericRepository<Homework>(db);
            List<Homework> homeworks = homeworksRepo.All().ToList();
            return homeworks;
        }

        public IHttpActionResult Post(HomeworkRequestModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            var db = new StudentSystemDbContext();
            var homeworsRepo = new GenericRepository<Homework>(db);
            var coursesRepo = new GenericRepository<Course>(db);
            var studentsRepo = new GenericRepository<Student>(db);
            Course defaultCourse = coursesRepo.All().ToList().FirstOrDefault();
            Student defaultStudent = studentsRepo.All().ToList().FirstOrDefault();
            var homeworkToAdd = new Homework
            {
                FileUrl = model.FileUrl,
                TimeSent = new DateTime(model.TimeSentTicks),
                Course = defaultCourse,
                CourseId = defaultCourse.Id,
                Student = defaultStudent,
                StudentIdentification = defaultStudent.StudentIdentification
            };

            homeworsRepo.Add(homeworkToAdd);
            homeworsRepo.SaveChanges();
            return this.Ok();
        }
    }
}