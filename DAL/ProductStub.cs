using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurStore.Model;

namespace OurStore.DAL
{
    public class ProductStub : IProductRepository
    {
        public IEnumerable<Product> getAllProducts()
        {
            var list = new List<Product>();
            var prod = new Product()
            {
                ProductId = 1,
                CategoryId = 1,
                Name = "lololo",
                Price = 123,
                ProductPicUrl = "/Content/Images/placeholder.gif"
            };
            list.Add(prod);
            list.Add(prod);
            list.Add(prod);
            return list;
        }

        public Product getProduct(int? id)
        {
            if(id != 0)
            {
                var prod = new Product()
                {
                    ProductId = 1,
                    CategoryId = 1,
                    Name = "lololo",
                    Price = 123,
                    ProductPicUrl = "/Content/Images/placeholder.gif"
                };
                return prod;
            }
            else
            {
                var prod = new Product();
                prod.ProductId = 0;
                return prod;
            }
        }

        public Product getProd(int id)
        {
            if (id != 0)
            {
                var prod = new Product()
                {
                    ProductId = 1,
                    CategoryId = 1,
                    Name = "lololo",
                    Price = 123,
                    ProductPicUrl = "/Content/Images/placeholder.gif"
                };
                return prod;
            }
            else
            {
                var prod = new Product();
                prod.ProductId = 0;
                return prod;
            }
        }

        public bool addProduct(Product product)
        {
            if(product != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool editProduct(Product product)
        {
            if (product != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool deleteProduct(int? id)
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

        public bool dispose()
        {
            return true;
        }
    }
}
