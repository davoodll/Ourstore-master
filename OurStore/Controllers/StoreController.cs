using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OurStore.BLL;

namespace OurStore.Controllers
{
    public class StoreController : Controller
    {
        private CategoryLogic catBLL;
        private ProductLogic prodBLL;

        public StoreController()
        {
            catBLL = new CategoryBLL();
            prodBLL = new ProductBLL();
        }
        public StoreController(CategoryLogic stub, ProductLogic prostub)
        {
            catBLL = stub;
            prodBLL = prostub;
        }

        public ActionResult Index()
        {
            var categories = catBLL.getAllCategories();
            return View(categories);
        }


        public ActionResult Browse(string category)
        {
            var categoryModel = catBLL.getProductsFromCategory(category);
            return View(categoryModel);
        }

        public ActionResult Details(int id)
        {
            var product = prodBLL.getProduct(id);
            return View(product);
        }


        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            var genres = catBLL.getAllCategories();
            return PartialView(genres);
        }
    }
}