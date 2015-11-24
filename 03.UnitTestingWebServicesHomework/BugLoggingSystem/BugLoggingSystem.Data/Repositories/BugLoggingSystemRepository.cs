namespace BugLoggingSystem.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Contracts;
    using System.Data.Entity.Infrastructure;

    public class BugLoggingSystemRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly IBugLoggingSystemDbContext context;
        private readonly IDbSet<TEntity> set;

        public BugLoggingSystemRepository(IBugLoggingSystemDbContext context)
        {
            this.context = context;
            this.set = this.context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            this.set.Add(entity);
        }

        public IQueryable<TEntity> All()
        {
            return this.set;
        }

        public void Delete(object id)
        {
            TEntity entity = this.FindById(id);
            this.ChangeEntityState(entity, EntityState.Deleted);
        }

        public void Delete(TEntity entity)
        {
            this.ChangeEntityState(entity, EntityState.Deleted);
        }

        public TEntity FindById(object id)
        {
            return this.set.Find(new Guid((string)id));
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        private void ChangeEntityState(TEntity entity, EntityState state)
        {
            DbEntityEntry entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}
