using Microsoft.VisualStudio.TestTools.UnitTesting;
using bisection;
namespace bisectionTest
{
    [TestClass]
    public class UnitTest1
    {
        int[] s = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        [TestMethod]
        public void Test5()
        {
            Assert.AreEqual(true, bisection.Utility.Search(s, 5));
        }
        [TestMethod]
        public void Test10()
        {
            Assert.AreEqual(true, bisection.Utility.Search(s, 10));
        }
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(true, bisection.Utility.Search(s, 2));
        }
        [TestMethod]
        public void Test11()
        {
            Assert.AreEqual(false, bisection.Utility.Search(s,11));
        }
    }
}
