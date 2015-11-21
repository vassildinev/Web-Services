using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace BlogSystem.Web.Api.IntegrationTests
{
    using Data.Repositories;
    using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using Ninject;
    using System;
    using System.Net;
    using System.Net.Http;
    using Infrastructure.IdentityProviders.Contracts;
    using MyTested.WebApi.Builders.Contracts.Servers;

    [TestClass]
    public class ArticlesTests
    {
        static IServerBuilder server;

        [TestInitialize]
        public void TestInit()
        {
            server = MyWebApi.Server().Starts<Startup>();
        }

        [TestMethod]
        public void GetAllArticlesWithoutAuthenticationShouldReturnCorrectResponse()
        {
            server
                .WithHttpRequestMessage(m => m
                    .WithMethod(HttpMethod.Get)
                    .WithRequestUri("api/articles"))
                .ShouldReturnHttpResponseMessage()
                .WithStatusCode(HttpStatusCode.OK)
                .WithStringContent("\"You are not authenticated\"");
        }

        [TestMethod]
        public void GetAllArticlesWithAuthenticationShouldReturnCorrectResponse()
        {
            IIdentityProvider identityProvider = FakesFactory.GetFakeIdentityProvider();
            Action<IKernel> dependenciesRegistration = kernel =>
            {
                kernel
                    .Bind<IBlogSystemDbContext>()
                    .To<BlogSystemDbContext>();
                kernel
                    .Bind(typeof(IRepository<>))
                    .To(typeof(GenericRepository<>));
                kernel
                    .Bind<IIdentityProvider>()
                    .ToConstant(identityProvider);
            };

            NinjectConfig.DependenciesRegistration = dependenciesRegistration;

            server
                .WithHttpRequestMessage(m => m
                    .WithMethod(HttpMethod.Get)
                    .WithRequestUri("api/articles"))
                .ShouldReturnHttpResponseMessage()
                .WithStatusCode(HttpStatusCode.OK)
                .WithStringContent("\"Authenticated\"");
        }

        [TestCleanup]
        public void Clean()
        {
            MyWebApi.Server().Stops();
        }
    }
}
