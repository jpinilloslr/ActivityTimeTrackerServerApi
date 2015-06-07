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
    public class FilterRuleControllerTest
    {
        private readonly MockAttUow _mockUow = new MockAttUow();

        private FilterRuleController GetTarget()
        {
            return new FilterRuleController(_mockUow);;
        }

        [TestMethod]
        public void TestGetAll()
        {
            var target = GetTarget();
            var result = target.Get();
            Assert.AreEqual(result.Count(), 3);
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
            var entry = new FilterRule()
            {
               Name = "Filter99",
               Id = 99,
               Description = "Desc99",
               Expression = "",
               ActivityConcepts = new List<ActivityConcept>()
            };            
            var target = GetTarget();
            var count = _mockUow.FilterRules.GetAll().Count();
            var response = target.Post(entry);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Assert.AreEqual(count + 1, _mockUow.FilterRules.GetAll().Count());
        }

        [TestMethod]
        public void TestUpdate()
        {
            var entry = new FilterRule()
            {
                Name = "Filter1Updates",
                Id = 1,
                Description = "Desc1",
                Expression = "",
                ActivityConcepts = new List<ActivityConcept>()
            };

            var target = GetTarget();
            var response = target.Post(entry);
            var updated = _mockUow.FilterRules.GetById(entry.Id);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Accepted);
            Assert.AreEqual(updated.Name, "Filter1Updates");
        }

        [TestMethod]
        public void TestDelete()
        {
            var target = GetTarget();
            var count = _mockUow.FilterRules.GetAll().Count();
            var response = target.Delete(1);
            var entry = _mockUow.FilterRules.GetById(1);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Accepted);
            Assert.AreEqual(count - 1, _mockUow.FilterRules.GetAll().Count());
            Assert.IsNull(entry);
        }
    }
}
