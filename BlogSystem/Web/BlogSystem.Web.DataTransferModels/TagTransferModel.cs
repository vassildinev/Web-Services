namespace BlogSystem.Web.DataTransferModels
{
    using System;

    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class TagTransferModel :
        IMapFrom<Tag>, IHaveCustomMappings
    {
        public void CreateMappings(IConfiguration configuration)
        {
        }
    }
}