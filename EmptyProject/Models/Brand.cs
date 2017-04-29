using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmptyProject.Models
{
    public class Brand : ModelBase
    {
        public string Name { get; set; }
        public string LogoURL { get; set; }
        public string Description { get; set; }
        
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Store> Stores { get; set; }

    }
}