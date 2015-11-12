using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using OurStore.Model;

namespace OurStore.DAL
{
    public class ProductDAL : IProductRepository
    {
        public IEnumerable<Product> getAllProducts()
        {
            ProductContext db = new ProductContext();
            var products = db.Products.Include(c => c.Category);
            return products.ToList();
        }

        public Product getProduct(int? id)
        {
            ProductContext db = new ProductContext();
            Product product = db.Products.Find(id);
            return product;
        }

        public Product getProd(int id)
        {
            ProductContext db = new ProductContext();
            return db.Products.Single(product => product.ProductId == id);
        }

        public bool addProduct(Product product)
        {
            ProductContext db = new ProductContext();
            if(product != null)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool editProduct(Product product)
        {
            ProductContext db = new ProductContext();
            if(product != null)
            {
                db.Entry(product).State = EntityState.Modified;
                //db.SaveChanges();
                bool saveFailed;
                do
                {
                    saveFailed = false;

                    try
                    {
                       db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;

                        // Update the values of the entity that failed to save from the store 
                        ex.Entries.Single().Reload();
                    }

                } while (saveFailed); 
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool deleteProduct(int? id)
        {
            ProductContext db = new ProductContext();
            Product product = db.Products.Find(id);
            if(product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool dispose()
        {
            ProductContext db = new ProductContext();
            db.Dispose();
            return true;
        }
    }
}
