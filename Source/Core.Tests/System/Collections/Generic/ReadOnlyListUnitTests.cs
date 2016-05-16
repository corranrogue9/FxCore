namespace System.Collections.Generic
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="ReadOnlyList{T}"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class ReadOnlyListUnitTests
    {
        /// <summary>
        /// Ensures that a readonly list has the same count as its delegate
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that a readonly list has the same count as its delegate")]
        [TestMethod]
        public void ListCount()
        {
            var list = new List<string>();
            var readonlyList = new ReadOnlyList<string>(list);

            Assert.AreEqual(list.Count, readonlyList.Count);

            list.Add("hello");
            Assert.AreEqual(list.Count, readonlyList.Count);

            list.Add("hello");
            Assert.AreEqual(list.Count, readonlyList.Count);

            list.Add("hello");
            Assert.AreEqual(list.Count, readonlyList.Count);
        }

        /// <summary>
        /// Ensures that indexing into a readonly list has the same results as indexing into its delegate
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that indexing into a readonly list has the same results as indexing into its delegate")]
        [TestMethod]
        public void ListIndexing()
        {
            var list = new List<string>();
            var readonlyList = new ReadOnlyList<string>(list);

            list.Add("first");
            Assert.AreEqual(list[0], readonlyList[0]);
            Assert.AreEqual("first", readonlyList[0]);

            list.Add("second");
            Assert.AreEqual(list[0], readonlyList[0]);
            Assert.AreEqual(list[1], readonlyList[1]);
            Assert.AreEqual("first", readonlyList[0]);
            Assert.AreEqual("second", readonlyList[1]);

            list.Add("third");
            Assert.AreEqual(list[0], readonlyList[0]);
            Assert.AreEqual(list[1], readonlyList[1]);
            Assert.AreEqual(list[2], readonlyList[2]);
            Assert.AreEqual("first", readonlyList[0]);
            Assert.AreEqual("second", readonlyList[1]);
            Assert.AreEqual("third", readonlyList[2]);

            list.Add("fourth");
            Assert.AreEqual(list[0], readonlyList[0]);
            Assert.AreEqual(list[1], readonlyList[1]);
            Assert.AreEqual(list[2], readonlyList[2]);
            Assert.AreEqual(list[3], readonlyList[3]);
            Assert.AreEqual("first", readonlyList[0]);
            Assert.AreEqual("second", readonlyList[1]);
            Assert.AreEqual("third", readonlyList[2]);
            Assert.AreEqual("fourth", readonlyList[3]);
        }

        /// <summary>
        /// Ensures that enumerating a readonly list has the same results as enumerating into its delegate
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that enumerating a readonly list has the same results as enumerating into its delegate")]
        [TestMethod]
        public void ListGenericEnumeration()
        {
            var list = new List<string>();
            var readonlyList = new ReadOnlyList<string>(list);

            foreach (var element in readonlyList)
            {
                Assert.Fail("there are no elements in the list yet");
            }

            list.Add("first");
            list.Add("second");
            list.Add("third");
            list.Add("fourth");

            using (var listEnumerator = list.GetEnumerator())
            using (var readonlyListEnumerator = readonlyList.GetEnumerator())
            {
                while (listEnumerator.MoveNext() && readonlyListEnumerator.MoveNext())
                {
                    Assert.AreEqual(listEnumerator.Current, readonlyListEnumerator.Current);
                }
            }
        }

        /// <summary>
        /// Ensures that enumerating a readonly list has the same results as enumerating into its delegate
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that enumerating a readonly list has the same results as enumerating into its delegate")]
        [TestMethod]
        public void ListEnumeration()
        {
            var list = new List<string>();
            var readonlyList = new ReadOnlyList<string>(list);

            foreach (var element in readonlyList)
            {
                Assert.Fail("there are no elements in the list yet");
            }

            list.Add("first");
            list.Add("second");
            list.Add("third");
            list.Add("fourth");

            var listEnumerator = ((IEnumerable)list).GetEnumerator();
            var readonlyListEnumerator = ((IEnumerable)readonlyList).GetEnumerator();
            while (listEnumerator.MoveNext() && readonlyListEnumerator.MoveNext())
            {
                Assert.AreEqual(listEnumerator.Current, readonlyListEnumerator.Current);
            }
        }
    }
}
