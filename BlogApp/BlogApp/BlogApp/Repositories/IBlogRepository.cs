using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BlogApp.Repositories
{
    public interface IBlogRepository
    {
        List<BlogsModel> GetBlogsList(int? userId = null);
        void ProcessBlog(BlogsModel model);
        BlogsModel GetBlogById(int Id);
    }
}