namespace BugLoggingSystem.Data.Repositories.Contracts
{
    using System.Linq;
    using Models;

    public interface IRepository<TEntity> 
        where TEntity : class
    {
        IQueryable<TEntity> All();

        TEntity FindById(object id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(object id);

        int SaveChanges();
    }
}
