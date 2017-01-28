using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace EmptyProject.ViewModels.Brand
{
    public class CreateBrandVM
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
       public string Name { get; set; }

       public string LogoURL { get; set; }

       public string Description { get; set; }

        public Guid UserID { get; set; }

    }
}