using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurStore.DAL;
using System.Web.Mvc;
using System.Web;
using OurStore.Model;

namespace OurStore.BLL
{
    public class ShoppingCartBLL : ShoppingCartLogic
    {
        public const string CartSessionKey = "CartId";
        private IShoppingCartRepository temp;
        public ShoppingCartBLL()
        {
            temp = new ShoppingCartDAL();
        }
        public ShoppingCartBLL(IShoppingCartRepository stub)
        {
            temp = stub;
        }
        public ShoppingCart GetCart(HttpContextBase context)
        {
            return temp.GetCart(context);
        }

        public ShoppingCart GetCart(Controller controller)
        {
            return temp.GetCart(controller.HttpContext);
        }
        public bool AddToCart(Product product, ShoppingCart cart)
        {
            return temp.AddToCart(product, cart);
        }

        public string getItemName(int id)
        {
            return temp.getItemName(id);
        }
        public int RemoveFromCart(int id, ShoppingCart cart)
        {
            return temp.RemoveFromCart(id, cart);
        }
        public bool EmptyCart(ShoppingCart cart)
        {
            return temp.EmptyCart(cart);
        }
        public List<Cart> GetCartItems(ShoppingCart cart)
        {
            return temp.GetCartItems(cart);
        }
        public int GetCount(ShoppingCart cart)
        {
            return temp.GetCount(cart);
        }
        public decimal GetTotal(ShoppingCart cart)
        {
            return temp.GetTotal(cart);
        }

        public decimal getTotalBefore(Order order, ShoppingCart cart)
        {
            return temp.getTotalBefore(order, cart);
        }

        public int CreateOrder(Order order, ShoppingCart cart)
        {
            return temp.CreateOrder(order, cart);
        }

        public string GetCartId(HttpContextBase context)
        {
            return temp.GetCartId(context);
        }

        public bool MigrateCart(string userName, ShoppingCart cart)
        {
            return temp.MigrateCart(userName, cart);
        }
    }
}
