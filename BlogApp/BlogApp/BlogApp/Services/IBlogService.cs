using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Services
{
    public interface IBlogService
    {
        List<BlogsModel> GetBlogsList(int? userId = null);
        void ProcessBlog(BlogsModel model);

        BlogsModel GetBlogById(int Id);
    }
}