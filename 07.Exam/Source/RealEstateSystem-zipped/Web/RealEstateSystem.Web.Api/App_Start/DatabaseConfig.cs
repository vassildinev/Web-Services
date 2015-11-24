namespace RealEstateSystem.Web.Api
{
    using System.Data.Entity;

    using Data;
    using Data.Migrations;

    public class DatabaseConfig
    {
        public static void Configure()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RealEstateSystemDbContext, Configuration>());
        }
    }
}