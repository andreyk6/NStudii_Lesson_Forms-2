using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmptyProject.Models
{
    public class Token
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public DateTime ExpirensDate { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}