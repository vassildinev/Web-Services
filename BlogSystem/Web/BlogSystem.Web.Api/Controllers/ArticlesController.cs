namespace BlogSystem.Web.Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using AutoMapper.QueryableExtensions;
    using Data.Models;
    using DataTransferModels;
    using Infrastructure.IdentityProviders.Contracts;
    using Services.Data.Contracts;

    public class ArticlesController : ApiController
    {
        private readonly IArticlesService articles;
        private readonly IIdentityProvider identityProvider;

        public ArticlesController(IArticlesService articles, IIdentityProvider identityProvider)
        {
            this.articles = articles;
            this.identityProvider = identityProvider;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            //IQueryable<ArticleTransferModel> result = this.articles
            //    .GetSortedArticles()
            //    .ProjectTo<ArticleTransferModel>();

            //return this.Ok(result);
            if (this.identityProvider.GetIdentity().IsAuthenticated)
            {
                return this.Ok("Authenticated");
            }

            return this.Ok("You are not authenticated");
        }

        [HttpPost]
        public IHttpActionResult Post(ArticleTransferModel request)
        {
            if (request == null || !this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var article = new Article
            {
                Title = request.Title,
                Content = request.Content,
                DateCreated = request.DateCreated,
                Tags = new HashSet<Tag>()
            };

            this.articles.Add(article);

            return this.Created("api/articles", article);
        }
    }
}