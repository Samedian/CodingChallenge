using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CodingChallengeDAL;
using CodingChallengeBAL;

namespace MockTest
{
    [TestClass]
    public class UnitTest1
    {
        private static Mock<IGetDataDAL> mock = new Mock<IGetDataDAL>();
        private static GetDataBAL _getDataBAL;
        =
        [ClassInitialize]
        public static void BeforeClass(TestContext testContext)
        {
            _getDataBAL = new GetDataBAL(mock.Object);
        }

        [TestMethod]
        public void TestMethod1()
        {

            mock.Setup(x => x.CountByTechnology(It.IsAny<int>())).Returns(5);
            var result = _getDataBAL.CountByTechnology(It.IsAny<int>());

            Assert.AreEqual(result==5, true);

        }

    }
}
