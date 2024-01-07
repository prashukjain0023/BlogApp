using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AuthorizeAttribute = System.Web.Mvc.AuthorizeAttribute;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult List()
        {
            return View();
        }

        public ActionResult GetBlog(int id)
        {
            Post p = new Post()
            {
                Title = "name",
                Author = 1,
                PublishedDate = DateTime.Now,
                Content = "blogcontent"
            };
            return View(p);
        }
    }
}