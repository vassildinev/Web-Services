namespace BlogSystem.Services.Data
{
    using System.Linq;
    
    using Contracts;
    using BlogSystem.Data.Models;
    using BlogSystem.Data.Repositories;

    public class ArticlesService : IArticlesService
    {
        private readonly IRepository<Article> articles;

        public ArticlesService(IRepository<Article> articles)
        {
            this.articles = articles;
        }

        public IQueryable<Article> GetSortedArticles()
        {
            return this.articles
                .All()
                .OrderBy(article => article.DateCreated)
                .Take(10);
        }

        public void Add(Article article)
        {
            this.articles.Add(article);
            this.articles.SaveChanges();
        }
    }
}
