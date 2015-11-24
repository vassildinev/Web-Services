namespace BugLoggingSystem.Services.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    using Contracts;
    using Models;
    using System;

    [TestClass]
    public class BugsServiceTests
    {
        private readonly IQueryable<Bug> mockedBugsData = new List<Bug>
        {
            new Bug
            {
                Id = Guid.NewGuid(),
                Text = "Bug 1",
                LogDate = DateTime.Now
            },
            new Bug
            {
                Id = Guid.NewGuid(),
                Text = "Bug 2",
                LogDate = DateTime.Now,
                Status = BugStatus.ForTesting
            }
        }
        .AsQueryable();

        [TestMethod]
        public void AllShouldReturnData()
        {
            var mockedBugsService = new Mock<IBugsService>();
            mockedBugsService.Setup(s => s.All()).Returns(this.mockedBugsData);

            Assert.AreEqual(2, mockedBugsService.Object.All().Count());
        }

        [TestMethod]
        public void GetByAddedAfterShouldReturnZero()
        {
            var mockedBugsService = new Mock<IBugsService>();
            mockedBugsService.Setup(s => s.GetByAddedAfter(DateTime.Now.AddDays(-50))).Returns(new List<Bug>().AsQueryable());

            Assert.AreEqual(0, mockedBugsService.Object.GetByAddedAfter(DateTime.Now.AddDays(-50)).Count());
        }

        [TestMethod]
        public void GetByStatusShouldReturnZero()
        {
            var mockedBugsService = new Mock<IBugsService>();
            mockedBugsService.Setup(s => s.GetByStatus(BugStatus.Fixed)).Returns(new List<Bug>().AsQueryable());

            Assert.AreEqual(0, mockedBugsService.Object.GetByStatus(BugStatus.Fixed).Count());
        }

        [TestMethod]
        public void UpdateStatusShouldChangeData()
        {
            Bug testBug = this.mockedBugsData.First();
            var mockedBugsService = new Mock<IBugsService>();
            mockedBugsService.Setup(s => s.UpdateStatus(testBug.Id.ToString(), BugStatus.Assigned)).Verifiable();

            mockedBugsService.Object.UpdateStatus(testBug.Id.ToString(), BugStatus.Assigned);
            mockedBugsService.Verify(s=>s.UpdateStatus(testBug.Id.ToString(), BugStatus.Assigned));
        }

        [TestMethod]
        public void AddShouldChangeData()
        {
            var testBug = new Bug
            {
                Id = Guid.NewGuid(),
                Text = "Test bug",
                LogDate = DateTime.Now
            };

            var mockedBugsService = new Mock<IBugsService>();
            mockedBugsService.Setup(s => s.Add(testBug)).Verifiable();

            mockedBugsService.Object.Add(testBug);
            mockedBugsService.Verify(s => s.Add(testBug));
        }

        [TestMethod]
        public void GetByIdShouldReturnCorrectEntity()
        {
            Bug testBug = this.mockedBugsData.First();

            var mockedBugsService = new Mock<IBugsService>();
            mockedBugsService.Setup(s => s.GetById(testBug.Id.ToString())).Returns(this.mockedBugsData.FirstOrDefault(b => b.Id == testBug.Id));

            Bug foundBug = mockedBugsService.Object.GetById(testBug.Id.ToString());
            Assert.AreEqual(testBug.Id, foundBug.Id);
        }
    }
}
