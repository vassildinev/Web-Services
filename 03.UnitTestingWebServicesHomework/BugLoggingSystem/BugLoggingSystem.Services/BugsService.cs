namespace BugLoggingSystem.Services
{
    using System;
    using System.Linq;
    using Models;
    using Contracts;
    using Data.Repositories.Contracts;

    public class BugsService : IBugsService
    {
        private readonly IRepository<Bug> bugs;

        public BugsService(IRepository<Bug> bugsRepository)
        {
            this.bugs = bugsRepository;
        }

        public IQueryable<Bug> All()
        {
            return this.bugs.All();
        }

        public IQueryable<Bug> GetByAddedAfter(DateTime date)
        {
            return this
                .All()
                .ToList()
                .Where(bug => (bug.LogDate - date).Days >= 0)
                .AsQueryable();
        }

        public IQueryable<Bug> GetByStatus(BugStatus status)
        {
            return this
                .All()
                .ToList()
                .Where(bug => bug.Status == status)
                .AsQueryable();
        }

        public void UpdateStatus(string id, BugStatus status)
        {
            Bug bug = this.GetById(id);
            bug.Status = status;
            this.bugs.Update(bug);
            this.bugs.SaveChanges();
        }

        public Bug GetById(string id)
        {
            return this.bugs.FindById(id);
        }

        public Bug Add(Bug bug)
        {
            this.bugs.Add(bug);
            this.bugs.SaveChanges();
            return bug;
        }
    }
}
