using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DigiMovei.Models
{
    public class ShopingContex//:DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipType { get; set; }
    }
}