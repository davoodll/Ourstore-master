using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurStore.Model;
using System.Web.Mvc;

namespace DAL
{
    public class CategoryStub : OurStore.DAL.ICategoryRepository
    {
        public bool addCategory(Category cat)
        {
            if(cat != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Category getCategory(int? id)
        {
            if(id == 0)
            {
                var cat = new Category();
                cat.CategoryId = 0;
                return cat;
            }
            else
            {
                var cat = new Category()
                {
                    CategoryId = 1,
                    Name = "HelloMon"
                };
                return cat;
            }
        }

        public bool editCategory(Category cat)
        {
            if (cat != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool deleteCategory(int? id)
        {
            if (id != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Category> getAllCategories()
        {
            var list = new List<Category>();
            var cat = new Category()
            {
                CategoryId = 1,
                Name = "HelloMon"
            };
            list.Add(cat);
            list.Add(cat);
            list.Add(cat);
            return list;
        }

        public Category getProductsFromCategory(string category)
        {
            if (string.Equals(category, String.Empty))
            {
                var cat = new Category();
                cat.CategoryId = 0;
                cat.Products = null;
                return cat;
            }
            else
            {
                var temp = new List<Product>();
                var prod = new Product()
                {
                    ProductId = 1,
                    CategoryId = 1,
                    Name = "LOLOL",
                    Price = 123,
                    ProductPicUrl = "/Content/Images/placeholder.gif"
                };
                temp.Add(prod);
                temp.Add(prod);
                temp.Add(prod);
                var cat = new Category()
                {
                    CategoryId = 1,
                    Name = "HelloMon",
                    Products = temp
                };
                return cat;
            }
        }

        public SelectList getCatList()
        {
            var temp = new List<Category>();
            var cat = new Category()
            {
                CategoryId = 1,
                Name = "lolololo"
            };
            return new SelectList(temp, "CategoryId", "Name");
        }

        public bool dispose()
        {
            return true;
        }
    }
}
