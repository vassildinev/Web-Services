namespace BlogSystem.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class BlogSystemDbContext : IdentityDbContext<User>, IBlogSystemDbContext
    {
        private const string BlogSystemDbConnectionName = "BlogSystemDbConnection";

        public BlogSystemDbContext()
            : base(BlogSystemDbConnectionName, throwIfV1Schema: false)
        {
        }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public static BlogSystemDbContext Create()
        {
            return new BlogSystemDbContext();
        }
    }
}
