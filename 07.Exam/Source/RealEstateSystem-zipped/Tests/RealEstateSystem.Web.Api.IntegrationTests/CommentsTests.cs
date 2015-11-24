namespace RealEstateSystem.Web.Api.IntegrationTests
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;

    using Api;
    using Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using DataTransferModels;

    [TestClass]
    public class CommentsTests
    {
        private static IServerBuilder server;

        [TestInitialize]
        public void TestInit()
        {
            server = MyWebApi.Server().Starts<Startup>();
        }

        [TestMethod]
        public void GetUserCommentsShouldReturnCorrectResponseWhenNotAuthorized()
        {
            server
                .WithHttpRequestMessage(m => m
                    .WithMethod(HttpMethod.Get)
                    .WithRequestUri("api/Comments/ByUser/blabla"))
                .ShouldReturnHttpResponseMessage()
                .WithStatusCode(HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public void GetUserCommentsWithDefaultParametersShouldReturnCorrectResponse()
        {
            MyWebApi
                .Controller<CommentsController>()
                .WithAuthenticatedUser(user => user.WithUsername("NewUserName"))
                .Calling(c => c.GetCommentsByUserId("NewUserName", 0, 10))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<IQueryable<CommentResponseModel>>();
        }

        [TestMethod]
        public void GetUserCommentsWithInvalidSkipShouldReturnCorrectResponse()
        {
            MyWebApi
                .Controller<CommentsController>()
                .WithAuthenticatedUser(user => user.WithUsername("NewUserName"))
                .Calling(c => c.GetCommentsByUserId("NewUserName", -1, 10))
                .ShouldReturn()
                .BadRequest();
        }

        [TestMethod]
        public void GetUserCommentsWithInvalidTakeShouldReturnCorrectResponse()
        {
            MyWebApi
                .Controller<CommentsController>()
                .WithAuthenticatedUser(user => user.WithUsername("NewUserName"))
                .Calling(c => c.GetCommentsByUserId("NewUserName", 1, -10))
                .ShouldReturn()
                .BadRequest();
        }

        [TestMethod]
        public void GetUserCommentsWithInvalidSkipAndTakeShouldReturnCorrectResponse()
        {
            MyWebApi
                .Controller<CommentsController>()
                .WithAuthenticatedUser(user => user.WithUsername("NewUserName"))
                .Calling(c => c.GetCommentsByUserId("NewUserName", -1, -10))
                .ShouldReturn()
                .BadRequest();
        }

        [TestMethod]
        public void GetCommentsByUserIdInvalidModelStateShoulReturnCorrectResponse()
        {
            MyWebApi
                .Controller<CommentsController>()
                .WithAuthenticatedUser(user => user.WithUsername("NewUserName"))
                .Calling(c => c.GetCommentsByUserId(null, 1, 10))
                .ShouldReturn()
                .BadRequest();
        }

        [TestCleanup]
        public void Clean()
        {
            MyWebApi.Server().Stops();
        }
    }
}
