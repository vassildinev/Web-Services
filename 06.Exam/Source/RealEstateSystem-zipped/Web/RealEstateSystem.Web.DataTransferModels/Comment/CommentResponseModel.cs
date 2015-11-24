namespace RealEstateSystem.Web.DataTransferModels
{
    using System;

    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class CommentResponseModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration
                .CreateMap<Comment, CommentResponseModel>()
                .ForMember(
                c => c.UserName,
                opt => opt.MapFrom(
                    c => c.Author.UserName));
        }
    }
}
