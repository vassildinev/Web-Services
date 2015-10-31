namespace StudentSystem.Data
{
    using System;
    using System.Collections.Generic;

    using Repositories;
    using Models;

    public class StudentSystemData : IStudentSystemData
    {
        private readonly IStudentSystemDbContext context;
        private readonly IDictionary<Type, object> repositories;

        public StudentSystemData()
            : this(new StudentSystemDbContext())
        {
        }

        public IGenericRepository<Course> Courses
        {
            get
            {
                return this.GetRepository<Course>();
            }
        }

        public IGenericRepository<Test> Tests
        {
            get
            {
                return this.GetRepository<Test>();
            }
        }

        public StudentsRepository Students
        {
            get
            {
                return (StudentsRepository)this.GetRepository<Student>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public StudentSystemData(IStudentSystemDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            Type typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                Type type = typeof(GenericRepository<T>);

                if (typeOfModel.IsAssignableFrom(typeof(Student)))
                {
                    type = typeof(StudentsRepository);
                }

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
