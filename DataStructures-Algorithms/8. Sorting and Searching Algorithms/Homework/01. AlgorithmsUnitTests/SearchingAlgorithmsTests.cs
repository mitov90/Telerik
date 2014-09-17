namespace AlgorithmsUnitTests
{
    using Algorithms;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SearchingAlgorithmsTests
    {
        [TestMethod]
        public void TestLinearSearch_ItemNotFound()
        {
            int[] numbers = { 1, 76, -205, 17, 90, 22 };
            SortableCollection<int> collection = new SortableCollection<int>(numbers);
            bool numberFound = collection.LinearSearch(8);

            Assert.AreEqual(false, numberFound);
        }

        [TestMethod]
        public void TestLinearSearch_ItemFound()
        {
            int[] numbers = { 11, 54, -7, 19, -22 };
            SortableCollection<int> collection = new SortableCollection<int>(numbers);
            bool numberFound = collection.LinearSearch(-7);

            Assert.AreEqual(true, numberFound);
        }

        [TestMethod]
        public void TestBinarySearch_ItemNotFound()
        {
            int[] sortedNumbers = { 1, 5, 7, 9, 22 };
            SortableCollection<int> collection = new SortableCollection<int>(sortedNumbers);
            bool numberFound = collection.BinarySearch(8);

            Assert.AreEqual(false, numberFound);
        }

        [TestMethod]
        public void TestBinarySearch_ItemLessThanMinimum()
        {
            int[] sortedNumbers = { 1, 5, 7, 9, 22 };
            SortableCollection<int> collection = new SortableCollection<int>(sortedNumbers);
            bool numberFound = collection.BinarySearch(-5);

            Assert.AreEqual(false, numberFound);
        }

        [TestMethod]
        public void TestBinarySearch_ItemGreaterThanMaximum()
        {
            int[] sortedNumbers = { 1, 5, 7, 9, 22 };
            SortableCollection<int> collection = new SortableCollection<int>(sortedNumbers);
            bool numberFound = collection.BinarySearch(30);

            Assert.AreEqual(false, numberFound);
        }

        [TestMethod]
        public void TestBinarySearch_ItemFound()
        {
            int[] sortedNumbers = { 1, 5, 7, 9, 22 };
            SortableCollection<int> collection = new SortableCollection<int>(sortedNumbers);
            bool numberFound = collection.BinarySearch(5);

            Assert.AreEqual(true, numberFound);
        }

        [TestMethod]
        public void TestBinarySearch_ItemEqualToMinimum()
        {
            int[] sortedNumbers = { 1, 5, 7, 9, 22 };
            SortableCollection<int> collection = new SortableCollection<int>(sortedNumbers);
            bool numberFound = collection.BinarySearch(1);

            Assert.AreEqual(true, numberFound);
        }

        [TestMethod]
        public void TestBinarySearch_ItemEqualToMaximum()
        {
            int[] sortedNumbers = { 1, 5, 7, 9, 22 };
            SortableCollection<int> collection = new SortableCollection<int>(sortedNumbers);
            bool numberFound = collection.BinarySearch(22);

            Assert.AreEqual(true, numberFound);
        }
    }
}