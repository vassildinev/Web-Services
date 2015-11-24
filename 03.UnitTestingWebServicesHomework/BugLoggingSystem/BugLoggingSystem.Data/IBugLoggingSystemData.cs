namespace BugLoggingSystem.Data
{
    using Models;
    using Repositories.Contracts;

    public interface IBugLoggingSystemData
    {
        IRepository<Bug> BugsRepository { get; }

        int SaveChanges();
    }
}
