namespace RealEstateSystem.Services.Data.Contracts
{
    using System.Linq;

    using RealEstateSystem.Data.Models;

    public interface ICommentsService
    {
        IQueryable<Comment> All();

        IQueryable<Comment> GetByRealEstateId(int realEstateId, int skip = 0, int take = 10);

        IQueryable<Comment> GetByUserId(string userId, int skip = 0, int take = 10);

        void Add(Comment model);
    }
}
