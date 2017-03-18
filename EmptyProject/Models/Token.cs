using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmptyProject.Models
{
    public class Token
    {
        public Guid Id { get; set; }

        public string Value { get; set; }

        public DateTime ExpiresDate { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}