using Microsoft.VisualStudio.TestTools.UnitTesting;
using ex6a;
namespace ex6aTest
{
    [TestClass]
    public class UnitTest1
    {
        private static int[] a = { 0, 2, 4, 6, 8, 10 };
        private static int[] b = { 1, 3, 5, 7, 9 };
        private static int[] c = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 9 };
        [TestMethod]
        public void ArrayA_CountSumMean_Test()
        {
            Assert.AreEqual(5, ArrayEx.Mean(a));
        }
        [TestMethod]
        public void ArrayB_CountSumMean_Test()
        {
            Assert.AreEqual(5, ArrayEx.Mean(b));
        }
        [TestMethod]
        public void ArrayC_CountSumMean_Test()
        {
            Assert.AreEqual(4, ArrayEx.Mean(c));
        }
        [TestMethod]
        public void ArrayA_Reverse_Test()
        {
            int[] reverse = {10, 8, 6, 4, 2, 0};
            CollectionAssert.AreEqual(reverse, ArrayEx.Reverse(a));
        }
        [TestMethod]
        public void ArrayB_Reverse_Test()
        {
            int[] reverse = {9,7,5,3,1};
            CollectionAssert.AreEqual(reverse, ArrayEx.Reverse(b));
        }
        [TestMethod]
        public void ArrayC_Reverse_Test()
        {
            int[] reverse = { 9,5,3,5,6,2,9,5,1,4,1,3};
            CollectionAssert.AreEqual(reverse, ArrayEx.Reverse(c));
        }
        [TestMethod]
        public void ArrayA_Shift_Test()
        {
            int[] Shift = { 2 , 4 , 6 , 8 , 10 , 0};
            CollectionAssert.AreEqual(Shift, ArrayEx.Shift(a,5,"left"));
        }
        [TestMethod]
        public void ArrayB_Shift_Test()
        {
            int[] Shift = {9,1,3,5,7};
            CollectionAssert.AreEqual(Shift, ArrayEx.Shift(b,-1,"right"));
        }
        [TestMethod]
        public void ArrayC_Shift_Test()
        {
            int[] Shift = { 6, 5, 3, 5, 9, 3, 1, 4, 1, 5, 9, 2 };
            CollectionAssert.AreEqual(Shift, ArrayEx.Shift(c,5,"left"));
        }
        [TestMethod]
        public void ArrayC_Sort_Test()
        { //3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 9
            int[] sort = { 1,1,2,3,3,4,5,5,5,6,9,9 };
            CollectionAssert.AreEqual(sort, ArrayEx.Sort(c));
        }
    }
}
