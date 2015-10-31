namespace ArtistsSystem.Models.MusicItems
{
    using System;
    using System.Collections.Generic;

    using People;
    using System.ComponentModel.DataAnnotations;

    public class Album
    {
        private ICollection<Singer> singers;

        public Album()
        {
            this.Id = Guid.NewGuid();
            this.singers = new HashSet<Singer>();
        }
        
        public Guid Id { get; set; }
        
        [MaxLength(20)]
        public string Title { get; set; }

        public short Year { get; set; }

        public virtual ICollection<Singer> Singers
        {
            get { return this.singers; }
            set { this.singers = value; }
        }

        public Guid ProducerId { get; set; }

        public Producer Producer { get; set; }
    }
}
