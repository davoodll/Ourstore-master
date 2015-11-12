using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OurStore.Model;

namespace OurStore.DAL
{
    public class SampleData : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            var categories = new List<Category>
            {
                new Category { Name = "Men" },
                new Category { Name = "Women" },
                new Category { Name = "Teenagers" },
                new Category { Name = "Kids" },
                new Category { Name = "Animals" }
            };

            new List<Product>
            {

                new Product { Name = "Neck Purse", Category = categories.Single(c => c.Name == "Men"), Price = 599.90M, ProductPicUrl = "/Content/Images/placeholder.gif" },
                new Product { Name = "Man Purse", Category = categories.Single(c => c.Name == "Men"), Price = 69.90M, ProductPicUrl = "/Content/Images/placeholder.gif" },
                new Product { Name = "Belt Purse", Category = categories.Single(c => c.Name == "Men"), Price = 239.90M, ProductPicUrl = "/Content/Images/placeholder.gif" },
                new Product { Name = "Rock Purse", Category = categories.Single(c => c.Name == "Men"), Price = 99.90M, ProductPicUrl = "/Content/Images/placeholder.gif" },
                new Product { Name = "Armani", Category = categories.Single(c => c.Name == "Women"), Price = 2499.90M, ProductPicUrl = "/Content/Images/placeholder.gif" },
                new Product { Name = "Louis Vitton", Category = categories.Single(c => c.Name == "Women"), Price = 1999.90M, ProductPicUrl = "/Content/Images/placeholder.gif" },
                new Product { Name = "DKNY", Category = categories.Single(c => c.Name == "Women"), Price = 1499.90M, ProductPicUrl = "/Content/Images/placeholder.gif" },
                new Product { Name = "Tiffanys", Category = categories.Single(c => c.Name == "Women"), Price = 999.90M, ProductPicUrl = "/Content/Images/placeholder.gif" },
                new Product { Name = "Hip Purse", Category = categories.Single(c => c.Name == "Teenagers"), Price = 59.90M, ProductPicUrl = "/Content/Images/placeholder.gif" },
                new Product { Name = "Punk Purse", Category = categories.Single(c => c.Name == "Teenagers"), Price = 179.90M, ProductPicUrl = "/Content/Images/placeholder.gif" },
                new Product { Name = "Cool Purse", Category = categories.Single(c => c.Name == "Teenagers"), Price = 449.90M, ProductPicUrl = "/Content/Images/placeholder.gif" },
                new Product { Name = "Awesome Purse", Category = categories.Single(c => c.Name == "Teenagers"), Price = 499.90M, ProductPicUrl = "/Content/Images/placeholder.gif" },
                new Product { Name = "Cute Purse", Category = categories.Single(c => c.Name == "Kids"), Price = 9.90M, ProductPicUrl = "/Content/Images/placeholder.gif" },
                new Product { Name = "Donut Purse", Category = categories.Single(c => c.Name == "Kids"), Price = 99.90M, ProductPicUrl = "/Content/Images/placeholder.gif" },
                new Product { Name = "Ultra Purse", Category = categories.Single(c => c.Name == "Kids"), Price = 199.90M, ProductPicUrl = "/Content/Images/placeholder.gif" },
                new Product { Name = "Super Purse", Category = categories.Single(c => c.Name == "Kids"), Price = 299.90M,  ProductPicUrl = "/Content/Images/placeholder.gif" },
                new Product { Name = "Dog Purse", Category = categories.Single(c => c.Name == "Animals"), Price = 19.90M, ProductPicUrl = "/Content/Images/placeholder.gif" },
                new Product { Name = "Car Purse", Category = categories.Single(c => c.Name == "Animals"), Price = 29.90M, ProductPicUrl = "/Content/Images/placeholder.gif" },
                new Product { Name = "Bird Purse", Category = categories.Single(c => c.Name == "Animals"), Price = 149.90M, ProductPicUrl = "/Content/Images/placeholder.gif" },
                new Product { Name = "Big Dog Purse", Category = categories.Single(c => c.Name == "Animals"), Price = 49.50M, ProductPicUrl = "/Content/Images/placeholder.gif" }
            }.ForEach(p => context.Products.Add(p));
        }
    }
}