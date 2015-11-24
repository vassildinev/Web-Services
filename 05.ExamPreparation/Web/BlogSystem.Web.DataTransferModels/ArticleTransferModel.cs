namespace BlogSystem.Web.DataTransferModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class ArticleTransferModel :
        IMapFrom<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public CategoryTransferModel Category { get; set; }

        public ICollection<TagTransferModel> Tags { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
        }
    }
}
