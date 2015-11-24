namespace BlogSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tag
    {
        private ICollection<Article> articles;

        public Tag()
        { 
            this.articles = new HashSet<Article>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Article> Articles
        {
            get { return this.articles; }
            set { this.articles = value; }
        }
    }
}
