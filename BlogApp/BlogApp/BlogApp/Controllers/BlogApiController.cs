using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using AuthorizeAttribute = System.Web.Mvc.AuthorizeAttribute;
using BlogApp.Services;

namespace BlogApp.Controllers
{
    public class BlogApiController : ApiController
    {
        private readonly IBlogService _blogService;

        public BlogApiController()
        {
            _blogService = new BlogService();
        }
       
        [HttpGet]
        [Route("api/blogapi/all")]
        public IHttpActionResult GetList()
        {
            var blogsList = _blogService.GetBlogsList();
            return Ok(blogsList);
        }

    }
}