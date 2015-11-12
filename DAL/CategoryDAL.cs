using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using OurStore.Model;
using System.Web.Mvc;

namespace OurStore.DAL
{
    public class CategoryDAL : OurStore.DAL.ICategoryRepository
    {
        public bool addCategory(Category cat)
        {
            var db = new ProductContext();
            if(cat != null)
            {
                db.Categories.Add(cat);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public Category getCategory(int? id)
        {
            var db = new ProductContext();
            Category cat = db.Categories.Find(id);
            return cat;
        }

        public bool editCategory(Category cat)
        {
            var db = new ProductContext();
            if(cat != null)
            {
                db.Entry(cat).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool deleteCategory(int? id)
        {
            var db = new ProductContext();
            Category cat = db.Categories.Find(id);
            if(cat != null)
            {
                db.Categories.Remove(cat);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Category> getAllCategories()
        {
            var db = new ProductContext();

            return db.Categories.ToList();
        }

        public Category getProductsFromCategory(string category)
        {
            var db = new ProductContext();
            var categoryModel = db.Categories.Include("Products").Single(c => c.Name == category);
            return categoryModel;
        }

        public SelectList getCatList()
        {
            var db = new ProductContext();
            var list = new SelectList(db.Categories, "CategoryId", "Name");
            return list;
        }

        public bool dispose()
        {
            var db = new ProductContext();
            db.Dispose();
            return true;
        }
    }
}
