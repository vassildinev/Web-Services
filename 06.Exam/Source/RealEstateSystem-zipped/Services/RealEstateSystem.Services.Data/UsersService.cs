namespace RealEstateSystem.Services.Data
{
    using System.Linq;

    using Contracts;
    using RealEstateSystem.Data.Models;
    using RealEstateSystem.Data.Repositories;

    public class UsersService : IUsersService
    {
        private readonly IRepository<User> users;

        public UsersService(IRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> All()
        {
            return this.users.All();
        }

        public IQueryable<User> GetStatisticsFor(string username)
        {
            return this.users
                .All()
                .Where(u => u.UserName == username);
        }

        public void Rate(string userId, int rating)
        {
            this.users
                .All()
                .Where(u => u.Id == userId)
                .FirstOrDefault()
                .Ratings
                .Add(new Rating { Value = rating });

            this.users.SaveChanges();
        }
    }
}
