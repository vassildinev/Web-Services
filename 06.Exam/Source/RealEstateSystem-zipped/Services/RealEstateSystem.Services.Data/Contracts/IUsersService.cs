namespace RealEstateSystem.Services.Data.Contracts
{
    using System.Linq;

    using RealEstateSystem.Data.Models;

    public interface IUsersService
    {
        IQueryable<User> All();

        IQueryable<User> GetStatisticsFor(string username);

        void Rate(string userId, int rating);
    }
}
