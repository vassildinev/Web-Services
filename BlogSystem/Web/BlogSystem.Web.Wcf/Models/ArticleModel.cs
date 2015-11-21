namespace BlogSystem.Web.Wcf.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class ArticleModel
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Content { get; set; }
    }
}