using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Models
{
    public class CurrentUserContext
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public void SetUser(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
        }
    }
}