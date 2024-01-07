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
    public class UserBlogApiController : ApiController
    {
        private readonly IBlogService _blogService;

        public UserBlogApiController()
        {
            _blogService = new BlogService();
        }

        [HttpPost]
        [Route("api/userblogapi/process")]
        [Authorize]
        public IHttpActionResult Process(BlogsModel model)
        {
            _blogService.ProcessBlog(model);
            return Ok();
        }


        [HttpGet]
        [Route("api/userblogapi/list")]
        [Authorize]
        public IHttpActionResult GetList()
        {
            //int? userId = HttpContext.Current.Session["UserId"] as int?;
            var blogsList = _blogService.GetBlogsList(1);
            return Ok(blogsList);
        }
    }
}