using System.Linq;
using System.Web.Mvc;
using OurStore.ViewModels;
using OurStore.BLL;

namespace OurStore.Controllers
{
    public class ShopCartController : Controller
    {
        private ShoppingCartLogic storeDB;
        private ProductLogic prodBLL;

        public ShopCartController()
        {
            storeDB = new ShoppingCartBLL();
            prodBLL = new ProductBLL();
        }
        public ShopCartController(ShoppingCartLogic stub, ProductLogic prodStub)
        {
            storeDB = stub;
            prodBLL = prodStub;
        }
        public ActionResult Index()
        {
            var cart = storeDB.GetCart(this.HttpContext);

            if(storeDB.GetCount(cart).Equals(0))
            {
                return View("EmptyCart");
            }

            var viewModel = new ShopCartViewModel
            {
                CartItems = storeDB.GetCartItems(cart),
                CartTotal = storeDB.GetTotal(cart)
            };

            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {
            var addedProduct = prodBLL.getProd(id);

            var cart = storeDB.GetCart(this.HttpContext);

            storeDB.AddToCart(addedProduct, cart);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            var cart = storeDB.GetCart(this.HttpContext);

            string productName = storeDB.getItemName(id);

            int itemCount = storeDB.RemoveFromCart(id, cart);

            var results = new ShopCartRemoveViewModel
            {
                Message = Server.HtmlEncode(productName) +
                    " has been removed from your shopping cart.",
                CartTotal = storeDB.GetTotal(cart),
                CartCount = storeDB.GetCount(cart),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }

        [ChildActionOnly]
        public ActionResult OurCart()
        {
            var cart = storeDB.GetCart(this.HttpContext);

            ViewData["CartCount"] = storeDB.GetCount(cart);
            return PartialView("OurCart");
        }
    }
}