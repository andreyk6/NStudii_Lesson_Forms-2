using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmptyProject.ViewModels.Item
{
    public class ReadItemVM
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public string ImageUrl { get; set; }

        public Guid StoreId { get; set; }

        public Guid Id { get; set; }
    }
}