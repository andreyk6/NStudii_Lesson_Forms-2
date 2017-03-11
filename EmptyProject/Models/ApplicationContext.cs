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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Token>()
                .HasRequired(t => t.User)
                .WithOptional(u => u.Token);
        }
        public ApplicationContext() : base("ProjectxDb") { }
        public DbSet<Token> Tokens { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Subscription> Subscriptions { get; set;}

        public DbSet<SubscriptionType> SubscriptionTypes { get; set;}

        public DbSet<Item> Items { get; set; }

        public DbSet<Store> Stores { get; set; }
    }
}