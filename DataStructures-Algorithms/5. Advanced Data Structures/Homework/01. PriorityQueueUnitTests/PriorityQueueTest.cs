namespace PriorityQueueUnitTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PriorityQueueTest
    {
        [TestMethod]
        public void TestPriorityQueue()
        {
            const int OperationsCount = 100000;

            var rand = new Random(0);

            var queue = new PriorityQueue<double>();

            for (var op = 0; op < OperationsCount; ++op)
            {
                var opType = rand.Next(0, 2);

                if (opType == 0)
                {
                    // Enqueue
                    var item = (100.0 - 1.0) * rand.NextDouble() + 1.0;
                    queue.Enqueue(item);

                    Assert.IsTrue(queue.IsConsistent(), "Test fails after enqueue operation # " + op);
                }
                else
                {
                    // Dequeue
                    if (queue.Count > 0)
                    {
                        var item = queue.Dequeue();
                        Assert.IsTrue(queue.IsConsistent(), "Test fails after dequeue operation # " + op);
                    }
                }
            }
        }
    }
}