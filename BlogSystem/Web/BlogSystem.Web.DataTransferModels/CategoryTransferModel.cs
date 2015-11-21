namespace BlogSystem.Web.DataTransferModels
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class CategoryTransferModel :
        IMapFrom<Category>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
        }
    }
}