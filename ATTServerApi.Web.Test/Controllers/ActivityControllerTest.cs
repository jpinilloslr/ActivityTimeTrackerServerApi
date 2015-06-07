using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ATTServerApi.Data.Mocks;
using ATTServerApi.Model;
using ATTServerApi.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATTServerApi.Web.Test.Controllers
{
    [TestClass]
    public class ActivityControllerTest
    {
        private readonly MockAttUow _mockUow = new MockAttUow();

        private ActivityController GetTarget()
        {
            return new ActivityController(_mockUow); ;
        }

        [TestMethod]
        public void TestGetAll()
        {
            var target = GetTarget();
            var result = target.Get();
            Assert.AreEqual(result.Count(), 6);
        }

        [TestMethod]
        public void TestGetLasts()
        {
            var target = GetTarget();
            var result = target.GetLasts(2);
            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public void TestGetById()
        {
            var target = GetTarget();
            var result = target.Get(1);
            Assert.AreEqual(result.Id, 1);
        }

        [TestMethod]
        public void TestCreate()
        {
            var activities = new List<Activity>
            {
                new Activity()
                {
                    Id = 99,
                    Date = DateTime.Now,
                    Life = 123.0,
                    ModuleFilename = "Module99",
                    ProcessName = "Process99",
                    WindowText = "Text99"
                }
            };
            var target = GetTarget();
            var count = _mockUow.Activities.GetAll().Count();
            var response = target.Post(activities);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Assert.AreEqual(count + 1, _mockUow.Activities.GetAll().Count());
        }
       
    }
}
