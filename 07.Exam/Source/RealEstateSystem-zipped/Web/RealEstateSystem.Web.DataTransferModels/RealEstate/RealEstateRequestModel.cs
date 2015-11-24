namespace RealEstateSystem.Web.DataTransferModels
{
    using System.ComponentModel.DataAnnotations;

    public class RealEstateRequestModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string Contact { get; set; }

        public int? ConstructionYear { get; set; }

        public decimal? SellingPrice { get; set; }

        public decimal? RentingPrice { get; set; }

        public int Type { get; set; }
    }
}
