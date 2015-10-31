namespace StudentSystem.Data
{
    using System.Data.Entity;

    using Models;

    public class StudentSystemDbContext : DbContext, IStudentSystemDbContext
    {
        private const string DbConnectionName = "StudentSystemConnection";
        public StudentSystemDbContext()
            : base(DbConnectionName)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Test> Tests { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
