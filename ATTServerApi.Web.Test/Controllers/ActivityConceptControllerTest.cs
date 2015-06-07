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
    public class ActivityConceptControllerTest
    {
        private readonly MockAttUow _mockUow = new MockAttUow();

        private ActivityConceptController GetTarget()
        {
            return new ActivityConceptController(_mockUow);;
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
            var entry = new ActivityConcept()
            {
                Description = "Desc99",
                Id = 99,
                Name = "Name99",
                Rules = new List<FilterRule>()
            };            
            var target = GetTarget();
            var count = _mockUow.ActivityConcepts.GetAll().Count();
            var response = target.Post(entry);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Assert.AreEqual(count + 1, _mockUow.ActivityConcepts.GetAll().Count());
        }

        [TestMethod]
        public void TestUpdate()
        {
            var entry = new ActivityConcept()
            {
                Description = "Desc1",
                Id = 1,
                Name = "Name1Updated",
                Rules = new List<FilterRule>()
            };
            var target = GetTarget();
            var response = target.Post(entry);
            var updated = _mockUow.ActivityConcepts.GetById(entry.Id);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Accepted);
            Assert.AreEqual(updated.Name, "Name1Updated");
        }

        [TestMethod]
        public void TestDelete()
        {
            var target = GetTarget();
            var count = _mockUow.ActivityConcepts.GetAll().Count();
            var response = target.Delete(1);
            var entry = _mockUow.ActivityConcepts.GetById(1);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Accepted);
            Assert.AreEqual(count - 1, _mockUow.ActivityConcepts.GetAll().Count());
            Assert.IsNull(entry);
        }
    }
}
