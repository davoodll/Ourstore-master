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
using OurStore.ViewModels;

namespace OurStore.UnitTest
{
    [TestClass]
    public class ShopCartControllerTest
    {
        [TestMethod]
        public void test_index()
        {
            var controller = new ShopCartController(new ShoppingCartBLL(new ShoppingCartStub()), new ProductBLL(new ProductStub()));

            var result = (ViewResult)controller.Index();
            var resultMod = (ShopCartViewModel)result.Model;

            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void test_addtocart()
        {
            var controller = new ShopCartController(new ShoppingCartBLL(new ShoppingCartStub()), new ProductBLL(new ProductStub()));

            var result = (RedirectToRouteResult)controller.AddToCart(1);

            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Index");
        }

        [TestMethod]
        public void test_ourcart()
        {
            var controller = new ShopCartController(new ShoppingCartBLL(new ShoppingCartStub()), new ProductBLL(new ProductStub()));

            var result = (PartialViewResult)controller.OurCart();

            Assert.AreEqual(result.ViewName, "OurCart");
        }
    }
}
