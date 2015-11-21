namespace BlogSystem.Web.DataTransferModels
{
    using System;

    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class CategoryTransferModel :
        IMapFrom<Category>, IHaveCustomMappings
    {
        public void CreateMappings(IConfiguration configuration)
        {
        }
    }
}