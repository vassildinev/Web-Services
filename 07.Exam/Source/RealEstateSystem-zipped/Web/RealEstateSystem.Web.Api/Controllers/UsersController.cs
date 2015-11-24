namespace RealEstateSystem.Web.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AutoMapper.QueryableExtensions;
    using DataTransferModels.User;
    using Infrastructure.IdentityProviders.Contracts;
    using Services.Data.Contracts;

    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        private const string InvalidUsernameMessage = "Invalid Username.";
        private const string InvalidModelMessage = "Invalid model.";

        private readonly IUsersService users;
        private readonly IIdentityProvider identityProvider;

        public UsersController(IUsersService users, IIdentityProvider identityProvider)
        {
            this.users = users;
            this.identityProvider = identityProvider;
        }

        [HttpGet]
        [Route("{username}")]
        public IHttpActionResult GetStatisticsForUser(string username)
        {
            IQueryable<UserResponseModel> result = this.users.GetStatisticsFor(username).ProjectTo<UserResponseModel>();
            if (result.Count() == 0)
            {
                return this.BadRequest(InvalidUsernameMessage);
            }

            return this.Ok(result.FirstOrDefault());
        }

        [HttpPost]
        [Authorize]
        [Route("Rate")]
        public IHttpActionResult RateUser(RatingRequestModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest(InvalidModelMessage);
            }

            this.users.Rate(model.UserId, model.Value);
            return this.Ok();
        }
    }
}