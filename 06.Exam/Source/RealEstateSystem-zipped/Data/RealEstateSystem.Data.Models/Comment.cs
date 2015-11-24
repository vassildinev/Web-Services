namespace RealEstateSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(500)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int RealEstateId { get; set; }

        public virtual RealEstate RealEstate { get; set; }

        public string UserName { get; set; }

        [ForeignKey("UserName")]
        public virtual User Author { get; set; }
    }
}
