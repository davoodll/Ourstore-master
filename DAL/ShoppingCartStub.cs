using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurStore.Model;
using System.Web;
using System.Web.Mvc;

namespace OurStore.DAL
{
    public class ShoppingCartStub : IShoppingCartRepository
    {
        public const string CartSessionKey = "CartId";

        public ShoppingCart GetCart(HttpContextBase context)
        {
            if(context != null)
            {
                var temp = new ShoppingCartStub();
                var cart = new ShoppingCart()
                {
                    ShopCartId = temp.GetCartId(context)
                };
                return cart;
            }
            else
            {
                var cart = new ShoppingCart()
                {
                    ShopCartId = null
                };
                return cart;
            }
        }

        public ShoppingCart GetCart(Controller controller)
        {
            if(controller != null)
            {
                return GetCart(controller.HttpContext);
            }
            else
            {
                var cart = new ShoppingCart()
                {
                    ShopCartId = null
                };
                return cart;
            }
        }

        public bool AddToCart(Product product, ShoppingCart cart)
        {
            if(product != null && cart != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string getItemName(int id)
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
                return prod.Name;
            }
            else
            {
                var prod = new Product();
                prod.ProductId = 0;
                prod.Name = "";
                return prod.Name;
            }
        }

        public int RemoveFromCart(int id, ShoppingCart cart)
        {
            if(id != 0 && cart != null)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public bool EmptyCart(ShoppingCart cart)
        {
            if(cart != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Cart> GetCartItems(ShoppingCart cart)
        {
            if(cart != null)
            {
                var list = new List<Cart>();
                var ca = new Cart()
                {
                    CartId = "1",
                    Count = 1,
                    DateCreated = DateTime.Now,
                    RecordId = 1
                };
                list.Add(ca);
                return list;
            }
            else
            {
                return null;
            }
        }

        public int GetCount(ShoppingCart cart)
        {
            if(cart != null)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public decimal GetTotal(ShoppingCart cart)
        {
            if (cart != null)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public decimal getTotalBefore(Order order, ShoppingCart cart)
        {
            if (order != null && cart != null)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public int CreateOrder(Order order, ShoppingCart cart)
        {
            if (order != null && cart != null)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {

                    Guid tempCartId = Guid.NewGuid();

                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        public bool MigrateCart(string userName, ShoppingCart cart)
        {
            if(!userName.Equals(String.Empty) && cart != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
