using BlogApp.Models;
using BlogApp.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace BlogApp.Controllers
{
    public class AccountApiController : ApiController
    {
        private readonly IUserService _userService;
        public AccountApiController()
        {
            _userService = new UserService();
        }

        [HttpPost]
        [Route("api/accountapi/register")]
        public IHttpActionResult Register(User u)
        {
            _userService.CreateUser(u);
            return Ok();
        }

        [HttpPost]
        [Route("api/accountapi/login")]
        public IHttpActionResult Login(LoginModel model)
        {
            var user = _userService.ValidUser(model);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Name, false);
                return Ok();
            }
            return BadRequest();
        }
    }
}