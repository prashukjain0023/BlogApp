using BlogApp.Models;
using BlogApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Services
{
    public class BlogService : IBlogService
    {
        public readonly IBlogRepository _blogRepository;

        public BlogService()
        {
            _blogRepository = new BlogRepository();
        }
        public List<BlogsModel> GetBlogsList(int? userId = null)
        {
            return _blogRepository.GetBlogsList(userId);
        }

        public void ProcessBlog(BlogsModel model)
        {
            _blogRepository.ProcessBlog(model);
        }

        public BlogsModel GetBlogById(int Id)
        {
            return _blogRepository.GetBlogById(Id);
        }

    }
}