namespace BugLoggingSystem.Services.Contracts
{
    using System;
    using System.Linq;

    using Models;

    public interface IBugsService
    {
        IQueryable<Bug> All();

        IQueryable<Bug> GetByAddedAfter(DateTime date);

        IQueryable<Bug> GetByStatus(BugStatus status);

        Bug GetById(string id);

        Bug Add(Bug bug);

        void UpdateStatus(string id, BugStatus status);
    }
}
