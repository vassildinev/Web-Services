namespace BugLoggingSystem.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using BugLoggingSystem.Models;
    using Data;
    using Models;
    using Services.Contracts;
    using Services;

    public class BugsController : ApiController
    {
        private readonly IBugsService bugs;

        public BugsController()
            : this(new BugsService(new BugLoggingSystemData(new BugLoggingSystemDbContext()).BugsRepository))
        {
        }

        public BugsController(IBugsService bugs)
        {
            this.bugs = bugs;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            IQueryable<Bug> result = this.bugs.All();
            return this.Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetAddedAfter(string date)
        {
            string[] dateComponents = date.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            int day = int.Parse(dateComponents[0]);
            int month = int.Parse(dateComponents[1]);
            int year = int.Parse(dateComponents[2]);
            var parsedDate = new DateTime(year, month, day);

            IQueryable<Bug> result = this.bugs.GetByAddedAfter(parsedDate);
            return this.Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetByStatus(string type)
        {
            BugStatus status = BugStatus.Pending;
            switch (type)
            {
                case "assigned":
                    status = BugStatus.Assigned;
                    break;
                case "forTesting":
                    status = BugStatus.ForTesting;
                    break;
                case "fixed":
                    status = BugStatus.Fixed;
                    break;
                default:
                    break;
            }

            IQueryable<Bug> result = this.bugs.GetByStatus(status);
            return this.Ok(result);
        }

        [HttpPost]
        public IHttpActionResult AddNewBug(BugRequestModel bug)
        {
            if (bug == null)
            {
                return this.BadRequest();
            }

            var bugToAdd = new Bug
            {
                Text = bug.Text,
                LogDate = DateTime.Now,
            };

            Bug result = this.bugs.Add(bugToAdd);
            return this.Ok(result);
        }

        [HttpPut]
        public IHttpActionResult UpdateBugStatus(string id, [FromBody]string type)
        {
            if (id == null || type == null)
            {
                return this.BadRequest();
            }

            BugStatus status = BugStatus.Pending;
            switch (type)
            {
                case "assigned":
                    status = BugStatus.Assigned;
                    break;
                case "forTesting":
                    status = BugStatus.ForTesting;
                    break;
                case "fixed":
                    status = BugStatus.Fixed;
                    break;
                default:
                    break;
            }

            this.bugs.UpdateStatus(id, status);
            return this.Ok();
        }
    }
}