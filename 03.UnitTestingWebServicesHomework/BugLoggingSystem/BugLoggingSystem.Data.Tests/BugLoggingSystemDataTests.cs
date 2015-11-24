using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace BugLoggingSystem.Data.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BugLoggingSystemDataTests
    {
        [TestMethod]
        public void GetBugsRepositoryShouldNotReturnNull()
        {
            var data = new BugLoggingSystemData(new BugLoggingSystemDbContext());
            Assert.AreNotEqual(null, data.BugsRepository);
        }
    }
}
