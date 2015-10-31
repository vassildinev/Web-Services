namespace ArtistsSystem.Models.People
{
    using Places;
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class Person
    {
        public Person()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public Guid CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
