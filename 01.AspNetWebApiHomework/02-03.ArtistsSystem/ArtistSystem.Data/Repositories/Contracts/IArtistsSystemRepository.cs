namespace ArtistsSystem.Data.Repositories.Contracts
{
    using System.Linq;

    public interface IArtistsSystemRepository<TEntity>
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
