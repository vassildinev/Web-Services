namespace RealEstateSystem.Services.Data
{
    using System.Linq;

    using Contracts;
    using RealEstateSystem.Data.Models;
    using RealEstateSystem.Data.Repositories;

    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Comment> comments;

        public CommentsService(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public IQueryable<Comment> All()
        {
            return this.comments.All();
        }

        public void Add(Comment model)
        {
            this.comments.Add(model);
            this.comments.SaveChanges();
        }

        public IQueryable<Comment> GetByRealEstateId(int realEstateId, int skip = 0, int take = 10)
        {
            return this.comments.All()
                .Where(c => c.RealEstateId == realEstateId)
                .OrderBy(c => c.CreatedOn)
                .Skip(skip * take)
                .Take(take);
        }

        public IQueryable<Comment> GetByUserId(string userId, int skip = 0, int take = 10)
        {
            return this.comments.All()
                .Where(c => c.UserName == userId)
                .OrderBy(c => c.CreatedOn)
                .Skip(skip * take)
                .Take(take);
        }
    }
}
