﻿using BlogApp.Models;
using BlogApp.Repositories;
using BlogApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AuthorizeAttribute = System.Web.Mvc.AuthorizeAttribute;

namespace BlogApp.Controllers
{
    [Authorize]
    public class UserBlogController : Controller
    {
        private readonly IBlogService _blogService;

        public UserBlogController()
        {
            _blogService = new BlogService(new BlogRepository());

        }
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View("Form");
        }

        public ActionResult Edit(int id)
        {
            var blog = _blogService.GetBlogById(id);
            return View("Form",blog);
        }

        public ActionResult GetBlog(int id)
        {
            var blog = _blogService.GetBlogById(id);
            return View(blog);
        }
    }
}