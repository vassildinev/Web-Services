namespace ArtistsSystem.Models.MusicItems
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using People;

    public class Song
    {
        public Song()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [MaxLength(20)]
        public string Title { get; set; }

        public string Genre { get; set; }

        public short Year { get; set; }

        [InverseProperty("Id")]
        public Guid SingerId { get; set; }

        [ForeignKey("SingerId")]
        public virtual Singer Singer { get; set; }
    }
}
