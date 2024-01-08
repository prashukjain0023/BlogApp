using BlogApp.Models;
using BlogApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(User u)
        {
            _userRepository.CreateUser(u);
        }

        public User ValidUser(LoginModel model)
        {
            return _userRepository.ValidUser(model);
        }

    }
}