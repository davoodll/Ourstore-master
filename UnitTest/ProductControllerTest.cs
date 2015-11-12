using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OurStore.BLL;
using OurStore.DAL;
using OurStore.Model;
using OurStore.Controllers;
using System.Web.Mvc;
using System.Web;
using System.Collections.Generic;

namespace OurStore.UnitTest
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void test_index()
        {
            var controller = new ProductsController(new ProductBLL(new ProductStub()));

            var list = new List<Product>();
            var prod = new Product()
            {
                ProductId = 1,
                CategoryId = 1,
                Name = "lololo",
                Price = 123,
                ProductPicUrl = "/Content/Images/placeholder.gif"
            };
            list.Add(prod);
            list.Add(prod);
            list.Add(prod);

            var result = (ViewResult)controller.Index();
            var resultList = (List<Product>)result.Model;

            Assert.AreEqual(result.ViewName, "");

            for(var i = 0; i < resultList.Count; i++)
            {
                Assert.AreEqual(list[i].ProductId, resultList[i].ProductId);
                Assert.AreEqual(list[i].CategoryId, resultList[i].CategoryId);
                Assert.AreEqual(list[i].Name, resultList[i].Name);
                Assert.AreEqual(list[i].Price, resultList[i].Price);
                Assert.AreEqual(list[i].ProductPicUrl, resultList[i].ProductPicUrl);
            }
        }

        [TestMethod]
        public void test_details1()
        {
            var controller = new ProductsController(new ProductBLL(new ProductStub()));

            var prod = new Product()
            {
                ProductId = 1,
                CategoryId = 1,
                Name = "lololo",
                Price = 123,
                ProductPicUrl = "/Content/Images/placeholder.gif"
            };

            var result = (ViewResult)controller.Details(1);
            var resultProd = (Product)result.Model;

            Assert.AreEqual(result.ViewName, "");
            Assert.AreEqual(resultProd.Name, prod.Name);
        }

        [TestMethod]
        public void test_create()
        {
            var controller = new ProductsController(new ProductBLL(new ProductStub()));

            var result = (ViewResult)controller.Create();

            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void test_post_create()
        {
            var controller = new ProductsController(new ProductBLL(new ProductStub()));

            var prod = new Product()
            {
                ProductId = 1,
                CategoryId = 1,
                Name = "llll",
                Price = 213,
                ProductPicUrl = "/Content/Images/placeholder.gif"
            };

            var result = (RedirectToRouteResult)controller.Create(prod);

            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Index");
        }

        [TestMethod]
        public void test_post_create2()
        {
            var controller = new ProductsController(new ProductBLL(new ProductStub()));

            var prod = new Product();
            controller.ViewData.ModelState.AddModelError("prouctname", "No product name");

            var result = (ViewResult)controller.Create(prod);

            Assert.IsTrue(result.ViewData.ModelState.Count == 1);
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void test_edit1()
        {
            var controller = new ProductsController(new ProductBLL(new ProductStub()));

            var prod = new Product()
            {
                ProductId = 1,
                CategoryId = 1,
                Name = "lololo",
                Price = 123,
                ProductPicUrl = "/Content/Images/placeholder.gif"
            };

            var result = (ViewResult)controller.Edit(1);
            var resultProd = (Product)result.Model;

            Assert.AreEqual(resultProd.Name, prod.Name);
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void test_post_edit()
        {
            var controller = new ProductsController(new ProductBLL(new ProductStub()));

            var prod = new Product()
            {
                ProductId = 1,
                CategoryId = 1,
                Name = "llll",
                Price = 213,
                ProductPicUrl = "/Content/Images/placeholder.gif"
            };

            var result = (RedirectToRouteResult)controller.Edit(prod);

            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Index");
        }

        [TestMethod]
        public void test_post_edit2()
        {
            var controller = new ProductsController(new ProductBLL(new ProductStub()));

            Product prod = null;
            controller.ViewData.ModelState.AddModelError("prouctname", "No product name");

            var result = (ViewResult)controller.Edit(prod);

            Assert.IsTrue(result.ViewData.ModelState.Count == 1);
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void test_delete1()
        {
            var controller = new ProductsController(new ProductBLL(new ProductStub()));

            var prod = new Product()
            {
                ProductId = 1,
                CategoryId = 1,
                Name = "lololo",
                Price = 123,
                ProductPicUrl = "/Content/Images/placeholder.gif"
            };

            var result = (ViewResult)controller.Delete(1);
            var resultProd = (Product)result.Model;

            Assert.AreEqual(result.ViewName, "");
            Assert.AreEqual(resultProd.Name, prod.Name);
        }

        [TestMethod]
        public void test_post_delete()
        {
            var controller = new ProductsController(new ProductBLL(new ProductStub()));

            var prod = new Product()
            {
                ProductId = 1,
                CategoryId = 1,
                Name = "llll",
                Price = 213,
                ProductPicUrl = "/Content/Images/placeholder.gif"
            };

            var result = (RedirectToRouteResult)controller.DeleteConfirmed(1);

            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Index");
        }
    }
}
