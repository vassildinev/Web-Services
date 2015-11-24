namespace BlogSystem.Web.Wcf
{
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    using AutoMapper.QueryableExtensions;
    using DataTransferModels;
    using Services.Data.Contracts;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Articles : IArticles
    {
        private readonly IArticlesService articles;

        public Articles(IArticlesService articles)
        {
            this.articles = articles;
        }

        public IQueryable<ArticleTransferModel> GetArticles()
        {
            this.SetCorrectContentType();

            return this.articles
                .GetSortedArticles()
                .ProjectTo<ArticleTransferModel>();
        }

        public ArticleTransferModel AddNew(ArticleTransferModel model)
        {
            this.SetCorrectContentType();
            return model;
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
