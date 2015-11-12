using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OurStore.BLL;
using OurStore.Model;

namespace OurStore.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        ShoppingCartLogic cartBLL;
        OrderLogic db;
        const String PromotionCode = "FIFTY CENT";
        public static decimal total = 0;

        public CheckoutController()
        {
            db = new OrderBLL();
            cartBLL = new ShoppingCartBLL();
        }

        public CheckoutController(OrderLogic stubOrder, ShoppingCartLogic stubCart)
        {
            db = stubOrder;
            cartBLL = stubCart;
        }
        public ActionResult Index()
        {
            return View("Error");
        }

        public ActionResult AddressAndPayment()
        {
            var cart = cartBLL.GetCart(this.HttpContext);
            if (cartBLL.GetCount(cart).Equals(0))
            {
                return View("EmptyCart");
            }
            ViewBag.Wrong = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                if(string.Equals(values["Promotion_Code_Box"], string.Empty) == true)
                {
                    order.Username = User.Identity.Name;
                    order.UserId = User.Identity.GetUserId();
                    order.OrderDate = DateTime.Now;

                    db.addOrder(order);

                    var cart = cartBLL.GetCart(this.HttpContext);
                    var tot = cartBLL.getTotalBefore(order, cart);
                    cartBLL.CreateOrder(order, cart);

                    order.Total = tot;
                    db.editOrder(order);
                    order.OrderDetails = order.OrderDetails;
                    db.save();

                    return RedirectToAction("Complete", new { id = order.OrderId });
                }
                else if (string.Equals(values["Promotion_Code_Box"], PromotionCode,
                    StringComparison.OrdinalIgnoreCase) == false)
                {
                    ViewBag.Wrong = " Wrong Promotion Code. Please write a valid promotion code, or leave this field empty.";
                    return View(order);
                }
                else
                {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    db.addOrder(order);
                    
                    db.save();

                    var cart = cartBLL.GetCart(this.HttpContext);
                    var tot = cartBLL.getTotalBefore(order, cart);
                    cartBLL.CreateOrder(order, cart);

                    order.Total = tot / 2;
                    db.editOrder(order);
                    db.save();

                    return RedirectToAction("Complete", new { id = order.OrderId });
                }
            }
            catch
            {

                return View(order);
            }
        }

        public ActionResult Complete(int id)
        {
            string user = User.Identity.Name;
            bool isValid = db.validateUserPurchase(id, user);

            if (isValid)
            {
                var orderModel = db.getOrder(id);
                ViewBag.tot = total;
                return View(orderModel);
            }
            else
            {
                return View("Error");
            }
        }
    }
}