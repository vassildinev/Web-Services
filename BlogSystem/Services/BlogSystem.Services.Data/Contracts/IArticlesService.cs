namespace BlogSystem.Services.Data.Contracts
{
    using System.Linq;

    using BlogSystem.Data.Models;

    public interface IArticlesService
    {
        IQueryable<Article> GetSortedArticles();

        void Add(Article article);
    }
}
