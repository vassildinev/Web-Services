namespace BugLoggingSystem.Data
{
    using System;
    using System.Collections.Generic;

    using Models;
    using Repositories.Contracts;
    using Repositories;

    public class BugLoggingSystemData : IBugLoggingSystemData
    {
        private readonly IBugLoggingSystemDbContext context;
        private readonly IDictionary<Type, object> repositories;

        public BugLoggingSystemData(IBugLoggingSystemDbContext context)
        {
            this.repositories = new Dictionary<Type, object>();
            this.context = context;
        }

        public IRepository<Bug> BugsRepository
        {
            get { return this.GetRepository<Bug>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class
        {
            Type repositoryType = typeof(TEntity);
            if (!this.repositories.ContainsKey(repositoryType))
            {
                var repository = new BugLoggingSystemRepository<TEntity>(this.context);
                this.repositories.Add(repositoryType, repository);
            }

            return (IRepository<TEntity>)this.repositories[repositoryType];
        }
    }
}
