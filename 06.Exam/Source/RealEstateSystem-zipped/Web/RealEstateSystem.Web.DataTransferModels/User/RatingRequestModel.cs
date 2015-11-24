namespace RealEstateSystem.Web.DataTransferModels.User
{
    using System.ComponentModel.DataAnnotations;

    public class RatingRequestModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        [Range(1, 5)]
        public int Value { get; set; }
    }
}
