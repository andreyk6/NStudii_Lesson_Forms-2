using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmptyProject.Models
{
    public class Brand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string LogoURL { get; set; }
        public string Description { get; set; }
        
        public Guid UserId { get; set; }
        public virtual User User { get; set; }


    }
}