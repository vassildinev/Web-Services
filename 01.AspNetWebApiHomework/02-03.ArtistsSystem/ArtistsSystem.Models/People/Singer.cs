namespace ArtistsSystem.Models.People
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using MusicItems;

    [Table("Singers")]
    public class Singer : Person
    {
        private ICollection<Song> songs;
        private ICollection<Album> albums;

        public Singer()
            : base()
        {
            this.songs = new HashSet<Song>();
            this.albums = new HashSet<Album>();
        }

        public virtual ICollection<Song> Songs
        {
            get { return this.songs; }
            set { this.songs = value; }
        }

        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }
    }
}
