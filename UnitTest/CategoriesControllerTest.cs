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
using DAL;

namespace OurStore.UnitTest
{
    [TestClass]
    public class CategoriesControllerTest
    {
        [TestMethod]
        public void test_index()
        {
            var controller = new CategoriesController(new CategoryBLL(new CategoryStub()));

            var list = new List<Category>();
            var cat = new Category()
            {
                CategoryId = 1,
                Name = "HelloMon"
            };
            list.Add(cat);
            list.Add(cat);
            list.Add(cat);

            var result = (ViewResult)controller.Index();
            var resultList = (List<Category>)result.Model;

            Assert.AreEqual(result.ViewName, "");
            Assert.AreEqual(resultList.First().CategoryId, list.First().CategoryId);
        }

        [TestMethod]
        public void test_details()
        {
            var controller = new CategoriesController(new CategoryBLL(new CategoryStub()));

            var cat = new Category()
            {
                CategoryId = 1,
                Name = "HelloMon"
            };

            var result = (ViewResult)controller.Details(1);
            var resultCat = (Category)result.Model;

            Assert.AreEqual(result.ViewName, "");
            Assert.AreEqual(resultCat.Name, cat.Name);
        }

        [TestMethod]
        public void test_create()
        {
            var controller = new CategoriesController(new CategoryBLL(new CategoryStub()));

            var result = (ViewResult)controller.Create();

            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void test_post_create()
        {
            var controller = new CategoriesController(new CategoryBLL(new CategoryStub()));

            var cat = new Category()
            {
                CategoryId = 1,
                Name = "HelloMon"
            };

            var result = (RedirectToRouteResult)controller.Create(cat);

            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Index");
        }

        [TestMethod]
        public void test_post_create2()
        {
            var controller = new CategoriesController(new CategoryBLL(new CategoryStub()));

            var cat = new Category();
            controller.ViewData.ModelState.AddModelError("name", "No category name");

            var result = (ViewResult)controller.Create(cat);

            Assert.IsTrue(result.ViewData.ModelState.Count == 1);
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void test_edit1()
        {
            var controller = new CategoriesController(new CategoryBLL(new CategoryStub()));

            var cat = new Category()
            {
                CategoryId = 1,
                Name = "HelloMon"
            };

            var result = (ViewResult)controller.Edit(1);
            var resultProd = (Category)result.Model;

            Assert.AreEqual(resultProd.Name, cat.Name);
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void test_post_edit()
        {
            var controller = new CategoriesController(new CategoryBLL(new CategoryStub()));

            var cat = new Category()
            {
                CategoryId = 1,
                Name = "HelloMon"
            };

            var result = (RedirectToRouteResult)controller.Edit(cat);

            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Index");
        }

        [TestMethod]
        public void test_post_edit2()
        {
            var controller = new CategoriesController(new CategoryBLL(new CategoryStub()));

            Category prod = null;
            controller.ViewData.ModelState.AddModelError("name", "No category name");

            var result = (ViewResult)controller.Edit(prod);

            Assert.IsTrue(result.ViewData.ModelState.Count == 1);
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void test_delete1()
        {
            var controller = new CategoriesController(new CategoryBLL(new CategoryStub()));

            var cat = new Category()
            {
                CategoryId = 1,
                Name = "HelloMon"
            };

            var result = (ViewResult)controller.Delete(1);
            var resultProd = (Category)result.Model;

            Assert.AreEqual(result.ViewName, "");
            Assert.AreEqual(resultProd.Name, cat.Name);
        }

        [TestMethod]
        public void test_post_delete()
        {
            var controller = new CategoriesController(new CategoryBLL(new CategoryStub()));

            var cat = new Category()
            {
                CategoryId = 1,
                Name = "HelloMon"
            };

            var result = (RedirectToRouteResult)controller.DeleteConfirmed(1);

            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Index");
        }
    }
}
