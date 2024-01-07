using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Repositories
{
    public interface IUserRepository
    {
        void CreateUser(User u);
        User ValidUser(LoginModel model);

    }
}