namespace ArtistsSystem.Models.People
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using MusicItems;

    [Table("Producers")]
    public class Producer : Person
    {
        private ICollection<Album> albums;

        public Producer()
            : base()
        {
            this.albums = new HashSet<Album>();
        }

        /// <summary>
        /// A rating from 0 to 100
        /// </summary>
        public int Recognition { get; set; }

        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }
    }
}
