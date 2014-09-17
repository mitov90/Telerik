namespace GenericStackUnitTests
{
    using GenericStack;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GenericStackTests
    {
        [TestMethod]
        public void TestGenericStackConstructor()
        {
            var stack = new GenericStack<string>();
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void TestGenericStackPush()
        {
            var stack = new GenericStack<string>();
            stack.Push("1. John");
            stack.Push("2. Nicholas");
            stack.Push("3. Mary");
            stack.Push("4. George");

            Assert.AreEqual(4, stack.Count);
        }

        [TestMethod]
        public void TestGenericStackPeek()
        {
            var stack = new GenericStack<string>();
            stack.Push("1. John");
            stack.Push("2. Nicholas");
            stack.Push("3. Mary");
            stack.Push("4. George");

            Assert.AreEqual("4. George", stack.Peek());
        }

        [TestMethod]
        public void TestGenericStackPop()
        {
            var stack = new GenericStack<string>();
            stack.Push("1. John");
            stack.Push("2. Nicholas");
            stack.Push("3. Mary");
            stack.Push("4. George");

            Assert.AreEqual("4. George", stack.Pop());
            Assert.AreEqual(3, stack.Count);
        }

        [TestMethod]
        public void TestGenericStackToString()
        {
            var stack = new GenericStack<string>();
            stack.Push("1. John");
            stack.Push("2. Nicholas");
            stack.Push("3. Mary");
            stack.Push("4. George");

            Assert.AreEqual("4. George, 3. Mary, 2. Nicholas, 1. John", stack.ToString());
        }

        [TestMethod]
        public void TestGenericStackContains()
        {
            var stack = new GenericStack<string>();
            stack.Push("1. John");
            stack.Push("2. Nicholas");
            stack.Push("3. Mary");
            stack.Push("4. George");
            stack.Push("5. Michael");

            Assert.IsTrue(stack.Contains("5. Michael"));
        }

        [TestMethod]
        public void TestGenericStackClear()
        {
            var stack = new GenericStack<string>();
            stack.Push("1. John");
            stack.Push("2. Nicholas");
            stack.Push("3. Mary");
            stack.Push("4. George");
            stack.Push("5. Michael");

            Assert.AreEqual(5, stack.Count);

            stack.Clear();

            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void TestGenericStackPopReferenceType()
        {
            var stack = new GenericStack<int[]>();
            stack.Push(new[] { 1, 1, 1 });
            stack.Push(new[] { 2, 2, 2 });
            stack.Push(new[] { 3, 3, 3 });
            stack.Push(new[] { 4, 4, 4 });
            stack.Push(new[] { 5, 5, 5 });
            stack.Push(new[] { 6, 6, 6 });

            Assert.AreEqual(6, stack.Count);

            CollectionAssert.AreEqual(new[] { 6, 6, 6 }, stack.Pop());
        }
    }
}
