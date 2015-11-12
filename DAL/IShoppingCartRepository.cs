using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurStore.Model;
using System.Web.Mvc;
using System.Web;

namespace OurStore.DAL
{
    public interface IShoppingCartRepository
    {
        ShoppingCart GetCart(HttpContextBase context);
        ShoppingCart GetCart(Controller controller);
        bool AddToCart(Product product, ShoppingCart cart);
        string getItemName(int id);
        int RemoveFromCart(int id, ShoppingCart cart);
        bool EmptyCart(ShoppingCart cart);
        List<Cart> GetCartItems(ShoppingCart cart);
        int GetCount(ShoppingCart cart);
        decimal GetTotal(ShoppingCart cart);
        decimal getTotalBefore(Order order, ShoppingCart cart);
        int CreateOrder(Order order, ShoppingCart cart);
        string GetCartId(HttpContextBase context);
        bool MigrateCart(string userName, ShoppingCart cart);
    }
}
