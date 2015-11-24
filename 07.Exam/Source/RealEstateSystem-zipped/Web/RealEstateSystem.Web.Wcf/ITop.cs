namespace RealEstateSystem.Web.Wcf
{
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    using Models;

    [ServiceContract]
    public interface ITop
    {
        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/")]
        IQueryable<UserResponseModel> Get();
    }
}
