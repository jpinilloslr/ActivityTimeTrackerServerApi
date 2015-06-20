using ATTServerApi.Data.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATTServerApi.Services.Test
{
    [TestClass]
    public class MeasuresGeneratorTest
    {

        private MeasuresGenerator GetTarget()
        {
            return new MeasuresGenerator(new MockAttUow(), new MockActivityQueryExecuter());
        }

        [TestMethod]
        public void TestMeasuresGenerator()
        {
            var target = GetTarget();
            Assert.AreEqual(target.Measures.Count, 3);
            Assert.AreEqual(target.Measures[0].Time, 12.0);
        }
    }
}
