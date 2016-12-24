﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmptyProject.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}