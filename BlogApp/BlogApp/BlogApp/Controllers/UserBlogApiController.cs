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
using System.Security.Claims;

namespace BlogApp.Controllers
{
    public class UserBlogApiController : ApiController
    {
        private readonly IBlogService _blogService;
        private CurrentUserContext _currentUserContext;

        public UserBlogApiController(IBlogService blogService, CurrentUserContext currentUserContext)
        {
            _blogService = blogService;            _currentUserContext = currentUserContext;

        }

        [HttpPost]
        [Route("api/userblogapi/process")]
        [Authorize]
        public IHttpActionResult Process([FromBody] BlogsModel model)
        {
            model.AuthorId = _currentUserContext.Id;
            _blogService.ProcessBlog(model);
            return Ok();
        }


        [HttpGet]
        [Route("api/userblogapi/list")]
        [Authorize]
        public IHttpActionResult GetList()
        {
            var blogsList = _blogService.GetBlogsList(_currentUserContext.Id);
            return Ok(blogsList);
        }
    }
}