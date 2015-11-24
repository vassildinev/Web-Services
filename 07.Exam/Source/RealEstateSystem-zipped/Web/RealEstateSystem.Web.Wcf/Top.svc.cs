namespace RealEstateSystem.Web.Wcf
{
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    using AutoMapper.QueryableExtensions;
    using Models;
    using Services.Data.Contracts;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Top : ITop
    {
        private const int UsersToTake = 10;

        private readonly IUsersService users;

        public Top(IUsersService users)
        {
            this.users = users;
        }

        public IQueryable<UserResponseModel> Get()
        {
            this.SetCorrectContentType();
            return this.users
                .All()
                .OrderByDescending(u => u.Ratings.Average(r => (double?)r.Value) ?? 0)
                .Take(UsersToTake)
                .ProjectTo<UserResponseModel>();
        }

        private void SetCorrectContentType()
        {
            WebOperationContext operationCtx = WebOperationContext.Current;
            WebMessageFormat responseFormat = WebMessageFormat.Xml;
            if (!string.IsNullOrEmpty(operationCtx.IncomingRequest.ContentType))
            {
                if (operationCtx.IncomingRequest.ContentType.EndsWith("/json"))
                {
                    responseFormat = WebMessageFormat.Json;
                }
            }

            operationCtx.OutgoingResponse.Format = responseFormat;
        }
    }
}
