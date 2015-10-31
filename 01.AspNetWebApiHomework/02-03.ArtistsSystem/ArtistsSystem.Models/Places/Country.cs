namespace ArtistsSystem.Models.Places
{
    using System;
    using System.Collections.Generic;

    using People;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        private readonly ICollection<Person> population;

        public Country()
        {
            this.Id = Guid.NewGuid();
            this.population = new HashSet<Person>();
        }

        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Person> Population { get; set; }
    }
}
