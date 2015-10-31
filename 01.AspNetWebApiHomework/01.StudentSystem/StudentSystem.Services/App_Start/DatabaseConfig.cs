using StudentSystem.Data;
using StudentSystem.Data.Migrations;
using System.Data.Entity;

namespace StudentSystem.Services
{
    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
        }
    }
}