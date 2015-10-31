namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Linq;

    using Data;
    using Models;

    public class ConsoleClient
    {
        public static void Main()
        {
            var data = new StudentSystemData();

            IQueryable<Course> courses = data.Courses.All();

            foreach (var course in courses)
            {
                Console.WriteLine(course.Name);
            }

            data.Courses.Add(new Course
            {
                Name = "Repo Pattern",
                Description = "Cool"
            });

            data.SaveChanges();
        }
    }
}
