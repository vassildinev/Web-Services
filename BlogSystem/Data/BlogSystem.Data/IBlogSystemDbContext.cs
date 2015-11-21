namespace BlogSystem.Data
{
    using Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IBlogSystemDbContext
    {
        IDbSet<Article> Articles { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Tag> Tags { get; set; }

        IDbSet<Category> Categories { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
