namespace BugLoggingSystem.Data
{
    using System.Data.Entity;

    using Models;
    using Migrations;

    public class BugLoggingSystemDbContext : DbContext, IBugLoggingSystemDbContext
    {
        private const string DbConnectionName = "BugLoggingSystemConnection";

        public BugLoggingSystemDbContext()
            : base(DbConnectionName)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BugLoggingSystemDbContext, Configuration>());
        }

        public IDbSet<Bug> Bugs { get; set; }

        IDbSet<TEntity> IBugLoggingSystemDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }
    }
}
