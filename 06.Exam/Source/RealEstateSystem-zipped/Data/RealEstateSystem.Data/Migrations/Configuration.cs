namespace RealEstateSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<RealEstateSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
            this.ContextKey = "RealEstateSystem.Data.RealEstateSystemDbContext";
        }

        protected override void Seed(RealEstateSystemDbContext context)
        {
        }
    }
}
