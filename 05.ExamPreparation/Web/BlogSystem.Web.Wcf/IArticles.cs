namespace BlogSystem.Web.Wcf
{
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    using DataTransferModels;

    [ServiceContract]
    public interface IArticles
    {
        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/articles")]
        IQueryable<ArticleTransferModel> GetArticles();

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/articles",
            RequestFormat = WebMessageFormat.Json)]
        ArticleTransferModel AddNew(ArticleTransferModel model);
    }
}
