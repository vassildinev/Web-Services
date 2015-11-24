namespace RealEstateSystem.Web.DataTransferModels
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class RealEstatePublicDetailedResponseModel : 
        RealEstatePublicResponseModel, IMapFrom<RealEstate>, IHaveCustomMappings
    {
        private const string EnumToStringFormat = "g";

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public int ConstructionYear { get; set; }

        public string Address { get; set; }

        public string RealEstateType { get; set; }

        public new void CreateMappings(IConfiguration configuration)
        {
            configuration
                .CreateMap<RealEstate, RealEstatePublicDetailedResponseModel>()
                .ForMember(
                c => c.CanBeRented,
                opt => opt.MapFrom(
                    c => c.Status == RealEstateStatus.ForRenting ||
                    c.Status == RealEstateStatus.ForRentingAndSelling));

            configuration
                .CreateMap<RealEstate, RealEstatePublicDetailedResponseModel>()
                .ForMember(
                c => c.CanBeSold,
                opt => opt.MapFrom(
                    c => c.Status == RealEstateStatus.ForSelling ||
                    c.Status == RealEstateStatus.ForRentingAndSelling));

            configuration
                .CreateMap<RealEstate, RealEstatePublicDetailedResponseModel>()
                .ForMember(
                c => c.RealEstateType,
                opt => opt.MapFrom(
                    c => c.Type.ToString(EnumToStringFormat)));
        }
    }
}
