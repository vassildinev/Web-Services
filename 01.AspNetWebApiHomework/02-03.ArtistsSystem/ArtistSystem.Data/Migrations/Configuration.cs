namespace ArtistsSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Models.People;
    using Models.MusicItems;
    using Models.Places;

    public sealed class Configuration : DbMigrationsConfiguration<ArtistsSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ArtistsSystemDbContext context)
        {
            if (context.Singers.Count() == 0)
            {
                var singer = new Singer
                {
                    FirstName = "Peter",
                    LastName = "Georgiev",
                    Age = 26
                };

                var producer = new Producer
                {
                    FirstName = "Anton",
                    LastName = "Petrov",
                    Age = 46,
                    Recognition = 95
                };

                var firstSong = new Song
                {
                    Title = "Song1",
                    Year = 2009,
                    Genre = "Pop"
                };

                var secondSong = new Song
                {
                    Title = "Song2",
                    Year = 2012,
                    Genre = "Jazz"
                };

                var album = new Album
                {
                    Title = "Album1",
                    Year = 2013
                };


                var firstCountry = new Country
                {
                    Name = "Germany"
                };

                var secondCountry = new Country
                {
                    Name = "Spain"
                };

                producer.Country = firstCountry;
                album.Producer = producer;
                singer.Country = secondCountry;
                singer.Songs.Add(firstSong);
                singer.Songs.Add(secondSong);
                singer.Albums.Add(album);

                context.Singers.AddOrUpdate(singer);
            }
        }
    }
}
