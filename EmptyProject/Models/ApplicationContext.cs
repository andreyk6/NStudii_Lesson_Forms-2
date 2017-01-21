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

        public DbSet<Brand> Brand { get; set; }

        public DbSet<Subscription> Subscription { get; set;}

        public DbSet<SubscriptionType> SubscriptionType { get; set;}

        public DbSet<Item> Item { get; set; }

        public DbSet<Store> Store { get; set; }
    }
}