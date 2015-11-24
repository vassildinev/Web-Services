namespace RealEstateSystem.Web.DataTransferModels
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class RealEstatePublicResponseModel : IMapFrom<RealEstate>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal? SellingPrice { get; set; }

        public decimal? RentingPrice { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration
                .CreateMap<RealEstate, RealEstatePublicResponseModel>()
                .ForMember(
                c => c.CanBeRented, 
                opt => opt.MapFrom(
                    c => c.Status == RealEstateStatus.ForRenting ||
                    c.Status == RealEstateStatus.ForRentingAndSelling));

            configuration
                .CreateMap<RealEstate, RealEstatePublicResponseModel>()
                .ForMember(
                c => c.CanBeSold,
                opt => opt.MapFrom(
                    c => c.Status == RealEstateStatus.ForSelling ||
                    c.Status == RealEstateStatus.ForRentingAndSelling));
        }
    }
}
