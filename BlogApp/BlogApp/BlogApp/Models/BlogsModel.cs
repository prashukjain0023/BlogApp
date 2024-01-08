using System;


namespace BlogApp.Models
{
    public class BlogsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
        public String Status { get; set; }
        public string Content { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}