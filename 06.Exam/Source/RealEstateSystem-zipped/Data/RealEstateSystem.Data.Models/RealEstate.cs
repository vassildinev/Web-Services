namespace RealEstateSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class RealEstate
    {
        private ICollection<Comment> comments;

        public RealEstate()
        {
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string Contact { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(1000)]
        public string Description { get; set; }

        public RealEstateType Type { get; set; }

        public RealEstateStatus Status { get; set; }

        public decimal? RentingPrice { get; set; }

        public decimal? SellingPrice { get; set; }

        [Range(1800, int.MaxValue)]
        public int? ConstructionYear { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserName { get; set; }

        [ForeignKey("UserName")]
        public virtual User Author { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
