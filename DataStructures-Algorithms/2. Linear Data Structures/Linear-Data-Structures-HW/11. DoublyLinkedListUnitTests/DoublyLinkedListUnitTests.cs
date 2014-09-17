namespace DoublyLinkedListUnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DoublyLinkedListUnitTests
    {
        [TestMethod]
        public void TestDoublyLinkedListConstructor()
        {
            var list = new DoublyLinkedList<string>();
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void TestDoublyLinkedListAdd()
        {
            var list = new DoublyLinkedList<string> { "One", "Two", "Three" };

            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void TestDoublyLinkedListIndexer()
        {
            var list = new DoublyLinkedList<string> { "One", "Two", "Three" };
            list[0] = "Zero";

            var array = new string[list.Count];
            list.CopyTo(array);
            Assert.AreEqual("Zero, Two, Three", string.Join(", ", array));
        }

        [TestMethod]
        public void TestDoublyLinkedListRemoveAt()
        {
            var list = new DoublyLinkedList<string> { "One", "Two", "Three" };
            list[0] = "Zero";
            list.RemoveAt(1);

            var array = new string[list.Count];
            list.CopyTo(array);
            Assert.AreEqual("Zero, Three", string.Join(", ", array));
        }

        [TestMethod]
        public void TestDoublyLinkedListForEach()
        {
            var list = new DoublyLinkedList<string> { "One", "Two", "Three" };
            list[0] = "Zero";

            var array = new string[list.Count];
            var index = 0;

            foreach (var item in list)
            {
                array[index] = item;
                index++;
            }

            Assert.AreEqual("Zero, Two, Three", string.Join(", ", array));
        }

        [TestMethod]
        public void TestDoublyLinkedListInsertInsertInTheMiddle()
        {
            var list = new DoublyLinkedList<string> { "One", "Two", "Three" };
            list[0] = "Zero";
            list.Insert(1, "Ten");

            var array = new string[list.Count];
            list.CopyTo(array);
            Assert.AreEqual("Zero, Ten, Two, Three", string.Join(", ", array));
        }

        [TestMethod]
        public void TestDoublyLinkedListInsertInsertAtTheEnd()
        {
            var list = new DoublyLinkedList<string> { "One", "Two", "Three" };
            list[0] = "Zero";
            list.Insert(3, "Ten");

            var array = new string[list.Count];
            list.CopyTo(array);
            Assert.AreEqual("Zero, Two, Three, Ten", string.Join(", ", array));
        }

        [TestMethod]
        public void TestDoublyLinkedListInsertInsertAtTheBeginning()
        {
            var list = new DoublyLinkedList<string> { "One", "Two", "Three" };
            list[0] = "Zero";
            list.Insert(0, "Ten");

            var array = new string[list.Count];
            list.CopyTo(array);
            Assert.AreEqual("Ten, Zero, Two, Three", string.Join(", ", array));
        }

        [TestMethod]
        public void TestDoublyLinkedListRemove()
        {
            var list = new DoublyLinkedList<string> { "One", "Two", "Three" };
            list[0] = "Zero";
            list.Remove("Three");

            var array = new string[list.Count];
            list.CopyTo(array);
            Assert.AreEqual("Zero, Two", string.Join(", ", array));
        }

        [TestMethod]
        public void TestDoublyLinkedListIndexOf()
        {
            var list = new DoublyLinkedList<string> { "One", "Two", "Three" };
            list[0] = "Zero";
            list.Insert(2, "Four");

            Assert.AreEqual(3, list.IndexOf("Three"));
        }
    }
}
