namespace BlogSystem.Web.Api.IntegrationTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Principal;

    using Data.Repositories;
    using Infrastructure.IdentityProviders.Contracts;
    using Moq;

    public static class FakesFactory
    {
        private static readonly string fakeIdentityName = "FakeIdentityName";

        public static IIdentityProvider GetFakeIdentityProvider()
        {
            var mockedIdentity = new Mock<IIdentity>();
            mockedIdentity
                .Setup(i => i.Name)
                .Returns(fakeIdentityName);
            mockedIdentity
                .Setup(i => i.IsAuthenticated)
                .Returns(!default(bool));

            var mockedIdentityProvider = new Mock<IIdentityProvider>();
            mockedIdentityProvider
                .Setup(i => i.GetIdentity())
                .Returns(mockedIdentity.Object);

            return mockedIdentityProvider.Object;
        }

        public static IRepository<TEntity> GetFakeRepository<TEntity>()
            where TEntity : class, new()
        {
            IQueryable<TEntity> data = new List<TEntity>().AsQueryable();

            var fakeRepository = new Mock<IRepository<TEntity>>();
            fakeRepository
                .Setup(r => r.All())
                .Returns(data);
            fakeRepository
                .Setup(r => r.Add(It.IsAny<TEntity>()))
                .Callback(() => data.ToList().Add(new TEntity()));
            fakeRepository
                .Setup(r => r.Attach(It.IsAny<TEntity>()))
                .Verifiable();
            fakeRepository
                .Setup(r => r.Detach(It.IsAny<TEntity>()))
                .Verifiable();
            fakeRepository
                .Setup(r => r.Delete(It.IsAny<TEntity>()))
                .Verifiable();
            fakeRepository
                .Setup(r => r.Update(It.IsAny<TEntity>()))
                .Verifiable();
            fakeRepository
                .Setup(r => r.SaveChanges())
                .Verifiable();
            fakeRepository
                .Setup(r => r.GetById(It.IsAny<object>()))
                .Verifiable();

            return fakeRepository.Object;
        }
    }
}
