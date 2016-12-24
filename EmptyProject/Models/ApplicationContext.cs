using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmptyProject.Models
{
    public class ApplicationContext : DbContext
    {
        static ApplicationContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationContext>());
        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}