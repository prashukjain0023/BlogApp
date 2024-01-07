using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Models
{
    public class BlogsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public String Status { get; set; }
        public string Content { get; set; }
        public byte[] Image { get; set; }
        public byte[] Video { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}