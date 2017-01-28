using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmptyProject.ViewModels.Brand
{
    public class CreateBradVM
    {
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }


        [Required]
        [DataType(DataType.ImageUrl)]
        public string LogoURL { get; set; } 
       [Required]
       [MaxLength(1000)]
       [MinLength(2)]
        public string Description { get; set; }
        
    }
}