namespace SinglyLinkedListUnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SinglyLinkedListTests
    {
        [TestMethod]
        public void TestSinglyLinkedListConstructor()
        {
            var list = new SinglyLinkedList<string>();
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void TestSinglyLinkedListAdd()
        {
            var list = new SinglyLinkedList<string> { "One", "Two", "Three" };

            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void TestSinglyLinkedListIndexer()
        {
            var list = new SinglyLinkedList<string> { "One", "Two", "Three" };
            list[0] = "Zero";

            var array = new string[list.Count];
            list.CopyTo(array);
            Assert.AreEqual("Zero, Two, Three", string.Join(", ", array));
        }

        [TestMethod]
        public void TestSinglyLinkedListRemoveAt()
        {
            var list = new SinglyLinkedList<string> { "One", "Two", "Three" };
            list[0] = "Zero";
            list.RemoveAt(1);

            var array = new string[list.Count];
            list.CopyTo(array);
            Assert.AreEqual("Zero, Three", string.Join(", ", array));
        }

        [TestMethod]
        public void TestSinglyLinkedListForEach()
        {
            var list = new SinglyLinkedList<string> { "One", "Two", "Three" };
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
        public void TestSinglyLinkedListInsertInsertInTheMiddle()
        {
            var list = new SinglyLinkedList<string> { "One", "Two", "Three" };
            list[0] = "Zero";
            list.Insert(1, "Ten");

            var array = new string[list.Count];
            list.CopyTo(array);
            Assert.AreEqual("Zero, Ten, Two, Three", string.Join(", ", array));
        }

        [TestMethod]
        public void TestSinglyLinkedListInsertInsertAtTheEnd()
        {
            var list = new SinglyLinkedList<string> { "One", "Two", "Three" };
            list[0] = "Zero";
            list.Insert(3, "Ten");

            var array = new string[list.Count];
            list.CopyTo(array);
            Assert.AreEqual("Zero, Two, Three, Ten", string.Join(", ", array));
        }

        [TestMethod]
        public void TestSinglyLinkedListInsertInsertAtTheBeginning()
        {
            var list = new SinglyLinkedList<string> { "One", "Two", "Three" };
            list[0] = "Zero";
            list.Insert(0, "Ten");

            var array = new string[list.Count];
            list.CopyTo(array);
            Assert.AreEqual("Ten, Zero, Two, Three", string.Join(", ", array));
        }

        [TestMethod]
        public void TestSinglyLinkedListRemove()
        {
            var list = new SinglyLinkedList<string> { "One", "Two", "Three" };
            list[0] = "Zero";
            list.Remove("Three");

            var array = new string[list.Count];
            list.CopyTo(array);
            Assert.AreEqual("Zero, Two", string.Join(", ", array));
        }

        [TestMethod]
        public void TestSinglyLinkedListIndexOf()
        {
            var list = new SinglyLinkedList<string>();
            list.Add("One");
            list.Add("Two");
            list.Add("Three");
            list[0] = "Zero";
            list.Insert(2, "Four");

            Assert.AreEqual(3, list.IndexOf("Three"));
        }
    }
}