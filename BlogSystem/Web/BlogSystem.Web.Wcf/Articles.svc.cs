namespace BlogSystem.Web.Wcf
{
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    using Data.Models;
    using Data.Repositories;
    using Models;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Articles : IArticles
    {
        private readonly IRepository<Article> articles;

        public Articles()
        {
            this.articles = new GenericRepository<Article>();
        }

        public IQueryable<ArticleModel> GetArticles()
        {
            this.SetCorrectContentType();

            return this.articles
                .All()
                .Select(a => new ArticleModel
                {
                    Title = a.Title,
                    Content = a.Content
                });
        }

        private void SetCorrectContentType()
        {
            WebOperationContext operationCtx = WebOperationContext.Current;
            WebMessageFormat responseFormat = WebMessageFormat.Xml;
            if (!string.IsNullOrEmpty(operationCtx.IncomingRequest.ContentType))
            {
                if(operationCtx.IncomingRequest.ContentType.EndsWith("/json"))
                {
                    responseFormat = WebMessageFormat.Json;
                }
            }

            operationCtx.OutgoingResponse.Format = responseFormat;
        }
    }
}
