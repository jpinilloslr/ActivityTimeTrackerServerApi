using System.Collections.Generic;
using System.Linq;
using ATTServerApi.Model;
using ATTServerApi.Services.Contracts;
using ATTServerApi.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ATTServerApi.Web.Test.Controllers
{
    [TestClass]
    public class MeasureControllerTest
    {

        private static MeasureController GetTarget()
        {
            var measures = new List<Measure>()
            {
                new Measure() {Name = "Measure1", Time = 5, TimeMonthAccumulation = 2, TimeRestAccumulation = 1, TimeToday = 1},
                new Measure() {Name = "Measure2", Time = 5, TimeMonthAccumulation = 2, TimeRestAccumulation = 1, TimeToday = 1},
                new Measure() {Name = "Measure3", Time = 5, TimeMonthAccumulation = 2, TimeRestAccumulation = 1, TimeToday = 1},
            };

            var measureGenMock = new Mock<IMeasuresGenerator>();
            measureGenMock.Setup(m => m.Measures).Returns(measures);
            return new MeasureController(measureGenMock.Object); ;
        }

        [TestMethod]
        public void TestGetAll()
        {
            var target = GetTarget();
            var result = target.Get();
            Assert.AreEqual(result.Count(), 3);
        }

    }
}
