namespace BlogSystem.Web.Wcf
{
    using System.Linq;
    using System.ServiceModel;

    using Models;
    using System.ServiceModel.Web;

    [ServiceContract]
    public interface IArticles
    {
        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/articles")]
        IQueryable<ArticleModel> GetArticles();
    }
}
