namespace BugLoggingSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public  sealed class Configuration : DbMigrationsConfiguration<BugLoggingSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BugLoggingSystemDbContext context)
        {
        }
    }
}
