namespace ArtistsSystem.Data.Data.Contracts
{
    using Models.People;
    using Models.MusicItems;
    using Models.Places;
    using Repositories.Contracts;

    public interface IArtistsSystemData
    {
        IArtistsSystemRepository<Country> CountriesRepository { get; }

        IArtistsSystemRepository<Song> SongsRepository { get; }

        IArtistsSystemRepository<Album> AlbumsRepository { get; }

        IArtistsSystemRepository<Singer> SingersRepository { get; }

        IArtistsSystemRepository<Producer> ProducersRepository { get; }

        int SaveChanges();
    }
}
