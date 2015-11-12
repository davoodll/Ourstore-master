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
    public class CheckoutControllerTest
    {
        [TestMethod]
        public void test_index()
        {
            var controller = new CheckoutController(new OrderBLL(new OrderStub()), new ShoppingCartBLL(new ShoppingCartStub()));

            var result = (ViewResult)controller.Index();

            Assert.AreEqual(result.ViewName, "Error");
        }

        [TestMethod]
        public void test_addressandpayment()
        {
            var controller = new CheckoutController(new OrderBLL(new OrderStub()), new ShoppingCartBLL(new ShoppingCartStub()));

            var result = (ViewResult)controller.AddressAndPayment();

            Assert.AreEqual(result.ViewName, "");
        }

        /*[TestMethod]
        public void test_addressandpayment2()
        {
            var controller = new CheckoutController(new OrderBLL(new OrderStub()), new ShoppingCartBLL(new ShoppingCartStub()));

            var temp = new FormCollection();
            temp.Add("OrderId", "1");
            temp.Add("FirstName", "lol");
            temp.Add("LastName", "lol");
            temp.Add("City", "lol");
            temp.Add("PostalCode", "123");
            temp.Add("Phone", "123");
            temp.Add("Email", "123");
            temp.Add("UserId", "123");
            temp.Add("Username", "lol");
            temp.Add("Total", "123");
            temp.Add("OrderDate", "123");
            temp.Add("Promotion_Code_Box", "");
            

            var result = (RedirectToRouteResult)controller.AddressAndPayment(temp);

            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Complete");
        }*/

        /*[TestMethod]
        public void test_complete()
        {
            var controller = new CheckoutController(new OrderBLL(new OrderStub()), new ShoppingCartBLL(new ShoppingCartStub()));

            var result = (ViewResult)controller.Complete(3);

            Assert.AreEqual(result.ViewName, "Error");
        }*/
    }
}
