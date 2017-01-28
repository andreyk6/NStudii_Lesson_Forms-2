using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmptyProject.Models
{
    public class Store : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public Guid BrandId { get; set; }
        public virtual Brand Brand { get; set; }
    }
}