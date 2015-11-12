using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurStore.Model;

namespace OurStore.DAL
{
    public interface IProductRepository
    {
        IEnumerable<Product> getAllProducts();

        Product getProduct(int? id);

        Product getProd(int id);

        bool addProduct(Product product);
        bool editProduct(Product product);
        bool deleteProduct(int? id);
        bool dispose();
    }
}
