namespace ArtistsSystem.Data
{
    using System.Data.Entity;

    using Models.People;
    using Models.Places;
    using Models.MusicItems;
    using Migrations;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ArtistsSystemDbContext : DbContext, IArtistsSystemDbContext
    {
        private const string DbConnectionName = "ArtistsSystemConnection";

        public ArtistsSystemDbContext()
            : base(DbConnectionName)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArtistsSystemDbContext, Configuration>());
            this.Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<Singer> Singers { get; set; }

        public IDbSet<Producer> Producers { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Song> Songs { get; set; }

        public IDbSet<Album> Albums { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Singer>().Map(s => s.MapInheritedProperties());
            modelBuilder.Entity<Producer>().Map(p => p.MapInheritedProperties());
            modelBuilder.Entity<Song>()
                .Property(s => s.Title)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Title") { IsUnique = true }));

            modelBuilder.Entity<Album>()
                .Property(a => a.Title)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Title") { IsUnique = true }));
        }
    }
}
