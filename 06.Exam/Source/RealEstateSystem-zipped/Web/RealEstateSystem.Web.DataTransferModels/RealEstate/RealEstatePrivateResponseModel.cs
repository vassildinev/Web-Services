namespace RealEstateSystem.Web.DataTransferModels
{
    using System.Collections.Generic;

    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class RealEstatePrivateResponseModel : RealEstatePublicDetailedResponseModel, IMapFrom<RealEstate>, IHaveCustomMappings
    {
        private const string EnumToStringFormat = "g";

        public string Contact { get; set; }

        public ICollection<CommentResponseModel> Comments { get; set; }

        public new void CreateMappings(IConfiguration configuration)
        {
            configuration
                .CreateMap<RealEstate, RealEstatePrivateResponseModel>()
                .ForMember(
                c => c.CanBeRented,
                opt => opt.MapFrom(
                    c => c.Status == RealEstateStatus.ForRenting ||
                    c.Status == RealEstateStatus.ForRentingAndSelling));

            configuration
                .CreateMap<RealEstate, RealEstatePrivateResponseModel>()
                .ForMember(
                c => c.CanBeSold,
                opt => opt.MapFrom(
                    c => c.Status == RealEstateStatus.ForSelling ||
                    c.Status == RealEstateStatus.ForRentingAndSelling));

            configuration
                .CreateMap<RealEstate, RealEstatePrivateResponseModel>()
                .ForMember(
                c => c.RealEstateType,
                opt => opt.MapFrom(
                    c => c.Type.ToString(EnumToStringFormat)));
        }
    }
}
