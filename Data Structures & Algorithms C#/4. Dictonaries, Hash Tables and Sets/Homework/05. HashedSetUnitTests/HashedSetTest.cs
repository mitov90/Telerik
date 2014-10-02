namespace HashedSetUnitTests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///     Uses the methods testing the Set class in
    ///     Wintellect's Power Collections for .NET.
    ///     http://powercollections.codeplex.com/
    /// </summary>
    [TestClass]
    public class HashedSetTest
    {
        [TestMethod]
        public void RandomAddDelete()
        {
            const int SIZE = 50000;
            var present = new bool[SIZE];
            var rand = new Random();
            var set1 = new HashedSet<int>();
            bool b;

            // Add and delete values at random.
            for (var i = 0; i < SIZE * 10; ++i)
            {
                var v = rand.Next(SIZE);
                if (present[v])
                {
                    Assert.IsTrue(set1.Contains(v));
                    b = set1.Remove(v);
                    Assert.IsTrue(b);
                    present[v] = false;
                }
                else
                {
                    Assert.IsFalse(set1.Contains(v));
                    b = set1.Add(v);
                    Assert.IsTrue(b);
                    present[v] = true;
                }
            }

            var count = 0;
            foreach (var x in present)
            {
                if (x)
                {
                    ++count;
                }
            }

            Assert.AreEqual(count, set1.Count);

            // Make sure the set has all the correct values, not in order.
            foreach (var v in set1)
            {
                Assert.IsTrue(present[v]);
                present[v] = false;
            }

            // Make sure all were found.
            count = 0;
            foreach (var x in present)
            {
                if (x)
                {
                    ++count;
                }
            }

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void Add()
        {
            var set1 = new HashedSet<string>(StringComparer.InvariantCultureIgnoreCase);
            bool b;

            b = set1.Add("hello");
            Assert.IsTrue(b);
            b = set1.Add("foo");
            Assert.IsTrue(b);
            b = set1.Add(string.Empty);
            Assert.IsTrue(b);
            b = set1.Add("HELLO");
            Assert.IsFalse(b);
            b = set1.Add("foo");
            Assert.IsFalse(b);
            b = set1.Add("Hello");
            Assert.IsFalse(b);
            b = set1.Add("Eric");
            Assert.IsTrue(b);
        }

        [TestMethod]
        public void CountAndClear()
        {
            var set1 = new HashedSet<string>(StringComparer.InvariantCultureIgnoreCase);

            Assert.AreEqual(0, set1.Count);
            set1.Add("hello");
            Assert.AreEqual(1, set1.Count);
            set1.Add("foo");
            Assert.AreEqual(2, set1.Count);
            set1.Add(string.Empty);
            Assert.AreEqual(3, set1.Count);
            set1.Add("HELLO");
            Assert.AreEqual(3, set1.Count);
            set1.Add("foo");
            Assert.AreEqual(3, set1.Count);
            set1.Add("Hello");
            Assert.AreEqual(3, set1.Count);
            set1.Add("Eric");
            Assert.AreEqual(4, set1.Count);
            set1.Clear();
            Assert.AreEqual(0, set1.Count);

            var found = false;
            foreach (var s in set1)
            {
                found = true;
            }

            Assert.IsFalse(found);
        }

        [TestMethod]
        public void Remove()
        {
            var set1 = new HashedSet<string>(StringComparer.InvariantCultureIgnoreCase);
            bool b;

            b = set1.Remove("Eric");
            Assert.IsFalse(b);
            b = set1.Add("hello");
            Assert.IsTrue(b);
            b = set1.Add("foo");
            Assert.IsTrue(b);
            b = set1.Add(string.Empty);
            Assert.IsTrue(b);
            b = set1.Remove("HELLO");
            Assert.IsTrue(b);
            b = set1.Remove("hello");
            Assert.IsFalse(b);
            b = set1.Add("Hello");
            Assert.IsTrue(b);
            b = set1.Add("Eric");
            Assert.IsTrue(b);
            b = set1.Add("Eric");
            Assert.IsFalse(b);
            b = set1.Remove("eRic");
            Assert.IsTrue(b);
            b = set1.Remove("eRic");
            Assert.IsFalse(b);
            set1.Clear();
            b = set1.Remove(string.Empty);
            Assert.IsFalse(b);
        }

        [TestMethod]
        public void CustomIComparer()
        {
            var set1 = new HashedSet<int>(new ModularComparer(5));
            bool b;

            b = set1.Add(4);
            Assert.IsTrue(b);
            b = set1.Add(11);
            Assert.IsTrue(b);
            b = set1.Add(9);
            Assert.IsFalse(b);
            b = set1.Add(15);
            Assert.IsTrue(b);

            Assert.IsTrue(set1.Contains(25));
            Assert.IsTrue(set1.Contains(26));
            Assert.IsFalse(set1.Contains(27));
        }

        [TestMethod]
        public void ComparerProperty()
        {
            IEqualityComparer<int> comparer1 = new ModularComparer(5);
            var set1 = new HashedSet<int>(comparer1);
            Assert.AreSame(comparer1, set1.Comparer);
            var set2 = new HashedSet<decimal>();
            Assert.AreSame(EqualityComparer<decimal>.Default, set2.Comparer);
            var set3 = new HashedSet<string>(StringComparer.InvariantCultureIgnoreCase);
            Assert.AreSame(StringComparer.InvariantCultureIgnoreCase, set3.Comparer);
        }

        [TestMethod]
        public void ToArray()
        {
            string[] expectedArray = { "Foo", "Eric", "Clapton", "hello", "goodbye", "C#" };
            var set1 = new HashedSet<string>();

            var a1 = set1.ToArray();
            Assert.IsNotNull(a1);
            Assert.AreEqual(0, a1.Length);

            foreach (var s in expectedArray)
            {
                set1.Add(s);
            }

            var actualArray = set1.ToArray();

            Array.Sort(expectedArray);
            Array.Sort(actualArray);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestMethod]
        public void Subset()
        {
            var set1 = new HashedSet<int>(new[] { 1, 3, 6, 7, 8, 9, 10 });
            var set2 = new HashedSet<int>();
            var set3 = new HashedSet<int>(new[] { 3, 8, 9 });
            var set4 = new HashedSet<int>(new[] { 3, 8, 9 });
            var set5 = new HashedSet<int>(new[] { 1, 2, 6, 8, 9, 10 });

            Assert.IsTrue(set1.IsSupersetOf(set2));
            Assert.IsTrue(set2.IsSubsetOf(set1));
            Assert.IsTrue(set1.IsProperSupersetOf(set2));
            Assert.IsTrue(set2.IsProperSubsetOf(set1));

            Assert.IsTrue(set1.IsSupersetOf(set3));
            Assert.IsTrue(set3.IsSubsetOf(set1));
            Assert.IsTrue(set1.IsProperSupersetOf(set3));
            Assert.IsTrue(set3.IsProperSubsetOf(set1));

            Assert.IsFalse(set3.IsSupersetOf(set1));
            Assert.IsFalse(set1.IsSubsetOf(set3));
            Assert.IsFalse(set3.IsProperSupersetOf(set1));
            Assert.IsFalse(set1.IsProperSubsetOf(set3));

            Assert.IsFalse(set1.IsSupersetOf(set5));
            Assert.IsFalse(set5.IsSupersetOf(set1));
            Assert.IsFalse(set1.IsSubsetOf(set5));
            Assert.IsFalse(set5.IsSubsetOf(set1));
            Assert.IsFalse(set1.IsProperSupersetOf(set5));
            Assert.IsFalse(set5.IsProperSupersetOf(set1));
            Assert.IsFalse(set1.IsProperSubsetOf(set5));
            Assert.IsFalse(set5.IsProperSubsetOf(set1));

            Assert.IsTrue(set3.IsSupersetOf(set4));
            Assert.IsTrue(set3.IsSubsetOf(set4));
            Assert.IsFalse(set3.IsProperSupersetOf(set4));
            Assert.IsFalse(set3.IsProperSubsetOf(set4));

            Assert.IsTrue(set1.IsSupersetOf(set1));
            Assert.IsTrue(set1.IsSubsetOf(set1));
            Assert.IsFalse(set1.IsProperSupersetOf(set1));
            Assert.IsFalse(set1.IsProperSubsetOf(set1));
        }

        [TestMethod]
        public void IsEqualTo()
        {
            var set1 = new HashedSet<int>(new[] { 6, 7, 1, 11, 9, 3, 8 });
            var set2 = new HashedSet<int>();
            var set3 = new HashedSet<int>();
            var set4 = new HashedSet<int>(new[] { 9, 11, 1, 3, 6, 7, 8, 14 });
            var set5 = new HashedSet<int>(new[] { 3, 6, 7, 11, 14, 8, 9 });
            var set6 = new HashedSet<int>(new[] { 1, 3, 6, 7, 8, 10, 11 });
            var set7 = new HashedSet<int>(new[] { 9, 1, 8, 3, 7, 6, 11 });

            Assert.IsTrue(set1.IsEqualTo(set1));
            Assert.IsTrue(set2.IsEqualTo(set2));

            Assert.IsTrue(set2.IsEqualTo(set3));
            Assert.IsTrue(set3.IsEqualTo(set2));

            Assert.IsTrue(set1.IsEqualTo(set7));
            Assert.IsTrue(set7.IsEqualTo(set1));

            Assert.IsFalse(set1.IsEqualTo(set2));
            Assert.IsFalse(set2.IsEqualTo(set1));

            Assert.IsFalse(set1.IsEqualTo(set4));
            Assert.IsFalse(set4.IsEqualTo(set1));

            Assert.IsFalse(set1.IsEqualTo(set5));
            Assert.IsFalse(set5.IsEqualTo(set1));

            Assert.IsFalse(set1.IsEqualTo(set6));
            Assert.IsFalse(set6.IsEqualTo(set1));

            Assert.IsFalse(set5.IsEqualTo(set6));
            Assert.IsFalse(set6.IsEqualTo(set5));

            Assert.IsFalse(set5.IsEqualTo(set7));
            Assert.IsFalse(set7.IsEqualTo(set5));
        }

        [TestMethod]
        public void IsDisjointFrom()
        {
            var set1 = new HashedSet<int>(new[] { 6, 7, 1, 11, 9, 3, 8 });
            var set2 = new HashedSet<int>();
            var set3 = new HashedSet<int>();
            var set4 = new HashedSet<int>(new[] { 9, 1, 8, 3, 7, 6, 11 });
            var set5 = new HashedSet<int>(new[] { 17, 3, 12, 10 });
            var set6 = new HashedSet<int>(new[] { 19, 14, 0, 2 });

            Assert.IsFalse(set1.IsDisjointFrom(set1));
            Assert.IsTrue(set2.IsDisjointFrom(set2));

            Assert.IsTrue(set1.IsDisjointFrom(set2));
            Assert.IsTrue(set2.IsDisjointFrom(set1));

            Assert.IsTrue(set2.IsDisjointFrom(set3));
            Assert.IsTrue(set3.IsDisjointFrom(set2));

            Assert.IsFalse(set1.IsDisjointFrom(set4));
            Assert.IsFalse(set4.IsDisjointFrom(set1));

            Assert.IsFalse(set1.IsDisjointFrom(set5));
            Assert.IsFalse(set5.IsDisjointFrom(set1));

            Assert.IsTrue(set1.IsDisjointFrom(set6));
            Assert.IsTrue(set6.IsDisjointFrom(set1));

            Assert.IsTrue(set5.IsDisjointFrom(set6));
            Assert.IsTrue(set6.IsDisjointFrom(set5));
        }

        [TestMethod]
        public void Intersection()
        {
            int[] oddNumbers = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25 };
            int[] digits = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var setOdds = new HashedSet<int>(oddNumbers);
            var setDigits = new HashedSet<int>(digits);

            setOdds.IntersectWith(setDigits);

            int[] expectedArray = { 1, 3, 5, 7, 9 };

            var actualArray = setOdds.ToArray();
            Array.Sort(actualArray);
            CollectionAssert.AreEqual(expectedArray, actualArray);

            setOdds = new HashedSet<int>(oddNumbers);

            setDigits.IntersectWith(setOdds);

            actualArray = setDigits.ToArray();
            Array.Sort(actualArray);
            CollectionAssert.AreEqual(expectedArray, actualArray);

            setOdds.IntersectWith(setOdds);
            Assert.AreEqual(oddNumbers.Length, setOdds.Count);
        }

        [TestMethod]
        public void Union()
        {
            int[] oddNumbers = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25 };
            int[] digits = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var setOdds = new HashedSet<int>(oddNumbers);
            var setDigits = new HashedSet<int>(digits);

            setOdds.UnionWith(setDigits);

            int[] expectedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 13, 15, 17, 19, 21, 23, 25 };

            var actualArray = setOdds.ToArray();
            Array.Sort(actualArray);
            CollectionAssert.AreEqual(expectedArray, actualArray);

            setOdds = new HashedSet<int>(oddNumbers);

            setDigits.UnionWith(setOdds);

            actualArray = setDigits.ToArray();
            Array.Sort(actualArray);
            CollectionAssert.AreEqual(expectedArray, actualArray);

            setOdds.UnionWith(setOdds);
            Assert.AreEqual(oddNumbers.Length, setOdds.Count);
        }

        [TestMethod]
        public void SymmetricDifference()
        {
            int[] oddNumbers = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25 };
            int[] digits = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var setOdds = new HashedSet<int>(oddNumbers);
            var setDigits = new HashedSet<int>(digits);

            setOdds.SymmetricExceptWith(setDigits);

            int[] expectedArray = { 2, 4, 6, 8, 11, 13, 15, 17, 19, 21, 23, 25 };

            var actualArray = setOdds.ToArray();
            Array.Sort(actualArray);
            CollectionAssert.AreEqual(expectedArray, actualArray);

            setOdds = new HashedSet<int>(oddNumbers);

            setDigits.SymmetricExceptWith(setOdds);

            actualArray = setDigits.ToArray();
            Array.Sort(actualArray);
            CollectionAssert.AreEqual(expectedArray, actualArray);

            setOdds.SymmetricExceptWith(setOdds);
            Assert.AreEqual(0, setOdds.Count);
        }

        [TestMethod]
        public void Difference()
        {
            int[] oddNumbers = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25 };
            int[] digits = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var setOdds = new HashedSet<int>(oddNumbers);
            var setDigits = new HashedSet<int>(digits);

            setOdds.ExceptWith(setDigits);

            int[] expectedArray1 = { 11, 13, 15, 17, 19, 21, 23, 25 };

            var actualArray = setOdds.ToArray();
            Array.Sort(actualArray);
            CollectionAssert.AreEqual(expectedArray1, actualArray);

            setOdds = new HashedSet<int>(oddNumbers);

            setDigits.ExceptWith(setOdds);

            int[] expectedArray2 = { 2, 4, 6, 8 };

            actualArray = setDigits.ToArray();
            Array.Sort(actualArray);
            CollectionAssert.AreEqual(expectedArray2, actualArray);

            setOdds.ExceptWith(setOdds);
            Assert.AreEqual(0, setOdds.Count);
        }
    }
}