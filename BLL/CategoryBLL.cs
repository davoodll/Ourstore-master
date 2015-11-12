using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using OurStore.Model;
using OurStore.DAL;

namespace OurStore.BLL
{
    public class CategoryBLL : CategoryLogic
    {
        private ICategoryRepository db;

        public CategoryBLL()
        {
            db = new CategoryDAL();
        }

        public CategoryBLL(ICategoryRepository stub)
        {
            db = stub;
        }

        public bool addCategory(Category cat)
        {
            return db.addCategory(cat);
        }

        public Category getCategory(int? id)
        {
            return db.getCategory(id);
        }

        public bool editCategory(Category cat)
        {
            return db.editCategory(cat);
        }

        public bool deleteCategory(int? id)
        {
            return db.deleteCategory(id);
        }

        public IEnumerable<Category> getAllCategories()
        {
            return db.getAllCategories();
        }

        public Category getProductsFromCategory(string category)
        {
            return db.getProductsFromCategory(category);
        }

        public SelectList getCatList()
        {
            return db.getCatList();
        }

        public bool dispose()
        {
            db.dispose();
            return true;
        }
    }
}
