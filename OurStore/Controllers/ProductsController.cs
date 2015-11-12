using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OurStore.Model;
using OurStore.BLL;

namespace OurStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private ProductLogic db;

        public ProductsController()
        {
            db = new ProductBLL();
        }
        public ProductsController(ProductLogic stub)
        {
            db = stub;
        }
        public ActionResult Index()
        {
            return View(db.getAllProducts());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.getProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        public ActionResult Create()
        {
            CategoryBLL catBLL = new CategoryBLL();
            ViewBag.CategoryId = catBLL.getCatList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.addProduct(product);
                return RedirectToAction("Index");
            }
            CategoryBLL catBLL = new CategoryBLL();
            ViewBag.CategoryId = catBLL.getCatList();
            return View(product);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.getProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            CategoryBLL catBLL = new CategoryBLL();
            ViewBag.CategoryId = catBLL.getCatList();
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid || product != null)
            {
                db.editProduct(product);
                return RedirectToAction("Index");
            }
            CategoryBLL catBLL = new CategoryBLL();
            ViewBag.CategoryId = catBLL.getCatList();
            return View(product);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.getProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.deleteProduct(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.dispose();
            }
            base.Dispose(disposing);
        }
    }
}
