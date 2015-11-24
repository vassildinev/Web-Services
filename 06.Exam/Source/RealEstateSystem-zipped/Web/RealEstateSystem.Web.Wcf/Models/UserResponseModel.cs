namespace RealEstateSystem.Web.Wcf.Models
{
    using System.Linq;

    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class UserResponseModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string UserName { get; set; }

        public double Rating { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration
                   .CreateMap<User, UserResponseModel>()
                   .ForMember(c => c.Rating, opt => opt.MapFrom(c => c.Ratings.Average(r => (double?)r.Value) ?? 0));
        }
    }
}