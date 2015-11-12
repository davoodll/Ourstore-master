using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurStore.Model;
using OurStore.DAL;

namespace OurStore.BLL
{
    public class ProductBLL : ProductLogic
    {
        private IProductRepository prod;

        public ProductBLL()
        {
            prod = new ProductDAL();
        }
        public ProductBLL(IProductRepository stub)
        {
            prod = stub;
        }
        public IEnumerable<Product> getAllProducts()
        {
            return prod.getAllProducts();
        }

        public Product getProduct(int? id)
        {
            return prod.getProduct(id);
        }

        public Product getProd(int id)
        {
            return prod.getProd(id);
        }

        public bool addProduct(Product product)
        {
            return prod.addProduct(product);
        }

        public bool editProduct(Product product)
        {
            return prod.editProduct(product);
        }

        public bool deleteProduct(int? id)
        {
            return prod.deleteProduct(id);
        }

        public bool dispose()
        {
            return prod.dispose();
        }
    }
}
