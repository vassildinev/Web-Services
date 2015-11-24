namespace BlogSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<BlogSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
            this.ContextKey = "BlogSystem.Data.BlogSystemDbContext";
        }

        protected override void Seed(BlogSystemDbContext context)
        {
        }
    }
}
