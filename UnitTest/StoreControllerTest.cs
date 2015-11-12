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
using System.Text;
using DAL;

namespace OurStore.UnitTest
{
    /// <summary>
    /// Summary description for StoreControllerTest
    /// </summary>
    [TestClass]
    public class StoreControllerTest
    {
        [TestMethod]
        public void test_index()
        {
            var controller = new StoreController(new CategoryBLL(new CategoryStub()), new ProductBLL(new ProductStub()));

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

            for (var i = 0; i < resultList.Count; i++)
            {
                Assert.AreEqual(list[i].CategoryId, resultList[i].CategoryId);
                Assert.AreEqual(list[i].Name, resultList[i].Name);
            }
        }

        [TestMethod]
        public void test_browse()
        {
            var controller = new StoreController(new CategoryBLL(new CategoryStub()), new ProductBLL(new ProductStub()));

            var temp = new List<Product>();
            var prod = new Product()
            {
                ProductId = 1,
                CategoryId = 1,
                Name = "LOLOL",
                Price = 123,
                ProductPicUrl = "/Content/Images/placeholder.gif"
            };
            temp.Add(prod);
            temp.Add(prod);
            temp.Add(prod);
            var cat = new Category()
            {
                CategoryId = 1,
                Name = "HelloMon",
                Products = temp
            };

            var result = (ViewResult)controller.Browse("HelloMon");
            var resultCat = (Category)result.Model;

            Assert.AreEqual(result.ViewName, "");
            Assert.AreEqual(resultCat.Name, cat.Name);
        }

        [TestMethod]
        public void details()
        {
            var controller = new StoreController(new CategoryBLL(new CategoryStub()), new ProductBLL(new ProductStub()));

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
        public void test_category_menu()
        {
            var controller = new StoreController(new CategoryBLL(new CategoryStub()), new ProductBLL(new ProductStub()));

            var list = new List<Category>();
            var cat = new Category()
            {
                CategoryId = 1,
                Name = "HelloMon"
            };
            list.Add(cat);
            list.Add(cat);
            list.Add(cat);

            var result = (PartialViewResult)controller.CategoryMenu();
            var resultList = (List<Category>)result.Model;

            Assert.AreEqual(result.ViewName, "");

            for (var i = 0; i < resultList.Count; i++)
            {
                Assert.AreEqual(list[i].CategoryId, resultList[i].CategoryId);
                Assert.AreEqual(list[i].Name, resultList[i].Name);
            }
        }
    }
}
