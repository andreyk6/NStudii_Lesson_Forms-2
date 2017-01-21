using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmptyProject.Models
{
    public class Item
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Descriplion { get; set; }
        public string ImageURL { get; set; }
        public float Price { get; set; }

        public Guid StoreId { get; set; }
        public virtual Store Store { get; set; }
    }
}