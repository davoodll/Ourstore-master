using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurStore.Model;
using System.Web.Mvc;

namespace OurStore.DAL
{
    public interface ICategoryRepository
    {
        bool addCategory(Category cat);
        Category getCategory(int? id);
        bool editCategory(Category cat);
        bool deleteCategory(int? id);
        IEnumerable<Category> getAllCategories();
        Category getProductsFromCategory(string category);
        SelectList getCatList();
        bool dispose();
    }
}
