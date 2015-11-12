using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurStore.Model;

namespace OurStore.BLL
{
    public interface ProductLogic
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
