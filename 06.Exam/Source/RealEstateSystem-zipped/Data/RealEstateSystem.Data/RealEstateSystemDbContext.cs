namespace RealEstateSystem.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class RealEstateSystemDbContext : IdentityDbContext<User>, IRealEstateSystemDbContext
    {
        private const string RealEstateSystemDbConnectionName = "RealEstateSystemDbConnection";

        public RealEstateSystemDbContext()
            : base(RealEstateSystemDbConnectionName, throwIfV1Schema: false)
        {
        }

        public IDbSet<RealEstate> RealEstates { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Rating> Ratings { get; set; }

        public static RealEstateSystemDbContext Create()
        {
            return new RealEstateSystemDbContext();
        }
    }
}
