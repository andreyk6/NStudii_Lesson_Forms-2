using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmptyProject.Models
{
    public class Token
    {
        public String token { get; set; }

        public virtual User user { get; set; }

        public Guid UserId { get; set; }

        public DateTime ExpiresDate { get; set; }

        public Guid Id { get; set; }

        public Token(String value, DateTime data, Guid userId, Guid id)
        {
            token = value;
            ExpiresDate = data;
            UserId = userId;
            Id = id;
        }
    }
}