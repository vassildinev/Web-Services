namespace BugLoggingSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;

    public interface IBugLoggingSystemDbContext
    {
        IDbSet<Bug> Bugs { get; set; }

        DbEntityEntry Entry(object entity);

        IDbSet<TEntity> Set<TEntity>() 
            where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
