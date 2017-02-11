using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmptyProject.Models
{
    public class User : ModelBase
    {
        public string Email { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public Guid TokenId { get; set; }
        public virtual Token Token { get; set; }

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