using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Services
{
    public interface IUserService
    {
        void CreateUser(User u);
        User ValidUser (LoginModel model);
    }
}