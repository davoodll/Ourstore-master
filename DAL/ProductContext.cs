using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OurStore.Model;

namespace OurStore.DAL
{
    public class ProductContext : DbContext
    {
        /*public ProductContext()
            : base("name=OurStore")
        {
            Database.CreateIfNotExists();
        }*/
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}