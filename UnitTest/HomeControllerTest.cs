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
    public class HomeControllerTest
    {
        [TestMethod]
        public void test_index()
        {
            var controller = new HomeController();

            var resultat = (ViewResult)controller.Index();

            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void test_about()
        {
            var controller = new HomeController();

            var resultat = (ViewResult)controller.About();

            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void test_contact()
        {
            var controller = new HomeController();

            var resultat = (ViewResult)controller.Contact();

            Assert.AreEqual(resultat.ViewName, "");
        }
    }
}
