namespace BugLoggingSystem.Data.Tests
{
    using System.Linq;
    using System.Transactions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Repositories;
    using System;

    [TestClass]
    public class BugsRepositoryTests
    {
        private TransactionScope tran;

        [TestInitialize]
        public void TestInit()
        {
            this.tran = new TransactionScope();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            this.tran.Dispose();
        }

        [TestMethod]
        public void CountShouldRemainTheSameWhenNoBugsAreAdded()
        {
            var repository = new BugLoggingSystemRepository<Bug>(new BugLoggingSystemDbContext());
            int previousBugsCount = repository.All().Count();
            int bugsCount = repository.All().Count();
            Assert.AreEqual(previousBugsCount, bugsCount);
        }

        [TestMethod]
        public void AddShouldWriteData()
        {
            var repository = new BugLoggingSystemRepository<Bug>(new BugLoggingSystemDbContext());
            int previousBugsCount = repository.All().Count();
            repository.Add(new Bug
            {
                Text = "pesho",
                LogDate = DateTime.Now
            });

            repository.SaveChanges();
            int bugsCount = repository.All().Count();
            Assert.AreEqual(previousBugsCount + 1, bugsCount);
        }

        [TestMethod]
        public void DeleteByIdShouldRemoveData()
        {
            var repository = new BugLoggingSystemRepository<Bug>(new BugLoggingSystemDbContext());
            int previousBugsCount = repository.All().Count();
            var bug = new Bug
            {
                Id = Guid.NewGuid(),
                Text = "pesho",
                LogDate = DateTime.Now
            };

            repository.Add(bug);
            repository.SaveChanges();
            int bugsCount = repository.All().Count();

            Assert.AreEqual(previousBugsCount + 1, bugsCount);

            repository.Delete(bug.Id.ToString());
            repository.SaveChanges();
            bugsCount = repository.All().Count();

            Assert.AreEqual(previousBugsCount, bugsCount);
        }

        [TestMethod]
        public void DeleteEntityShouldRemoveData()
        {
            var repository = new BugLoggingSystemRepository<Bug>(new BugLoggingSystemDbContext());
            int previousBugsCount = repository.All().Count();
            var bug = new Bug
            {
                Id = Guid.NewGuid(),
                Text = "pesho",
                LogDate = DateTime.Now
            };

            repository.Add(bug);
            repository.SaveChanges();
            int bugsCount = repository.All().Count();

            Assert.AreEqual(previousBugsCount + 1, bugsCount);

            repository.Delete(bug);
            repository.SaveChanges();
            bugsCount = repository.All().Count();

            Assert.AreEqual(previousBugsCount, bugsCount);
        }

        [TestMethod]
        public void UpdateShouldChangeEntity()
        {
            var repository = new BugLoggingSystemRepository<Bug>(new BugLoggingSystemDbContext());
            int previousBugsCount = repository.All().Count();
            var bug = new Bug
            {
                Id = Guid.NewGuid(),
                Text = "pesho",
                LogDate = DateTime.Now
            };

            repository.Add(bug);
            repository.SaveChanges();
            int bugsCount = repository.All().Count();

            Assert.AreEqual(previousBugsCount + 1, bugsCount);

            bug.Text = "gosho";
            repository.Update(bug);
            repository.SaveChanges();

            Bug foundBug = repository.FindById(bug.Id.ToString());
            Assert.AreEqual("gosho", foundBug.Text);
        }
    }
}
