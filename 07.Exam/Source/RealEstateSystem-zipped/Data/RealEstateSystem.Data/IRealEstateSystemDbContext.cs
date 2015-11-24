namespace RealEstateSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;

    public interface IRealEstateSystemDbContext
    {
        IDbSet<RealEstate> RealEstates { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Rating> Ratings { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
