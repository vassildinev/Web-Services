namespace RealEstateSystem.Web.DataTransferModels
{
    using System.ComponentModel.DataAnnotations;

    public class CommentRequestModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(500)]
        public string Content { get; set; }

        public int RealEstateId { get; set; }
    }
}
