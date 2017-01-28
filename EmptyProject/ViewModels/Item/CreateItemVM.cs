using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmptyProject.ViewModels.Item
{
    public class CreateItemVM
    {
        [Required]
        public string Name { get; set; }

        //[Required]
        public string Description { get; set; }

        [Required]
        [Range(0.01,99999999999)]
        public float Price { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Required]
        public Guid StoreId { get; set; }
    }
}