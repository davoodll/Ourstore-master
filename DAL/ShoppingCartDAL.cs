using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OurStore.Model;

namespace OurStore.DAL
{
    public partial class ShoppingCartDAL : IShoppingCartRepository
    {
        ProductContext storeDB = new ProductContext();
        public const string CartSessionKey = "CartId";
        public ShoppingCart GetCart(HttpContextBase context)
        {
            var temp = new ShoppingCartDAL();
            var cart = new ShoppingCart()
            {
                ShopCartId = temp.GetCartId(context)
            };
            return cart;
        }

        public ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public bool AddToCart(Product product, ShoppingCart cart)
        {
            if(product != null && cart != null)
            {
                var cartItem = storeDB.Carts.SingleOrDefault(
                c => c.CartId == cart.ShopCartId
                && c.ProductId == product.ProductId);

                if (cartItem == null)
                {

                    cartItem = new Cart
                    {
                        ProductId = product.ProductId,
                        CartId = cart.ShopCartId,
                        Count = 1,
                        DateCreated = DateTime.Now
                    };
                    storeDB.Carts.Add(cartItem);
                }
                else
                {
                    cartItem.Count++;
                }

                storeDB.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public string getItemName(int id)
        {
            var db = new ProductContext();
            return db.Carts.Single(item => item.RecordId == id).Product.Name;
        }

        public int RemoveFromCart(int id, ShoppingCart cart)
        {

            var cartItem = storeDB.Carts.Single(
                c => c.CartId == cart.ShopCartId
                && c.RecordId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    storeDB.Carts.Remove(cartItem);
                }

                storeDB.SaveChanges();
            }
            return itemCount;
        }
        public bool EmptyCart(ShoppingCart cart)
        {
            if(cart != null)
            {
                var cartItems = storeDB.Carts.Where(
                c => c.CartId == cart.ShopCartId);

                foreach (var cartItem in cartItems)
                {
                    storeDB.Carts.Remove(cartItem);
                }

                storeDB.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Cart> GetCartItems(ShoppingCart cart)
        {
            return storeDB.Carts.Where(
                c => c.CartId == cart.ShopCartId).ToList();
        }
        public int GetCount(ShoppingCart cart)
        {
            int? count = (from cartItems in storeDB.Carts
                          where cartItems.CartId == cart.ShopCartId
                          select (int?)cartItems.Count).Sum();

            return count ?? 0;
        }
        public decimal GetTotal(ShoppingCart cart)
        {

            decimal? total = (from cartItems in storeDB.Carts
                              where cartItems.CartId == cart.ShopCartId
                              select (int?)cartItems.Count *
                              cartItems.Product.Price).Sum();

            return total ?? decimal.Zero;
        }

        public decimal getTotalBefore(Order order, ShoppingCart cart)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems(cart);

            foreach (var item in cartItems)
            {
                orderTotal += (item.Count * item.Product.Price);
            }

            return orderTotal;
        }

        public int CreateOrder(Order order, ShoppingCart cart)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems(cart);

            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = item.ProductId,
                    OrderId = order.OrderId,
                    ProductPrice = item.Product.Price,
                    Quantity = item.Count
                };

                orderTotal += (item.Count * item.Product.Price);
                
                storeDB.OrderDetails.Add(orderDetail);

            }

            order.Total = orderTotal;
            
            order.OrderDetails = storeDB.OrderDetails.Where(o => o.OrderId == order.OrderId).ToList();


            storeDB.SaveChanges();

            EmptyCart(cart);

            return order.OrderId;
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
                var shoppingCart = storeDB.Carts.Where(
                c => c.CartId == cart.ShopCartId);

                foreach (Cart item in shoppingCart)
                {
                    item.CartId = userName;
                }
                storeDB.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}