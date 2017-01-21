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

        public virtual ICollection<Role> Roles { get; set; }
        /*
         public string name {get;private set;}
         private string _name;
         public string getName()
         {
           return _name;
         }
         private void setName(string value)
         {
            _name=value;
         }
        */

    }
}