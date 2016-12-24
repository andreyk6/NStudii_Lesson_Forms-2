using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmptyProject.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}