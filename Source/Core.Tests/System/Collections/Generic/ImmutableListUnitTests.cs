namespace System.Collections.Generic
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="ImmutableList{T}"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class ImmutableListUnitTests
    {
        /// <summary>
        /// Ensures that an immutable list retains its count even after its initializer has been updated
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that an immutable list retains its count even after its initializer has been updated")]
        [TestMethod]
        public void ListCountEmpty()
        {
            var list = new List<string>();
            var immutableList = new ImmutableList<string>(list);

            Assert.AreEqual(0, immutableList.Count);

            list.Add("hello");
            Assert.AreEqual(0, immutableList.Count);

            list.Add("hello");
            Assert.AreEqual(0, immutableList.Count);

            list.Add("hello");
            Assert.AreEqual(0, immutableList.Count);
        }

        /// <summary>
        /// Ensures that an immutable list retains its count even after its initializer has been updated
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that an immutable list retains its count even after its initializer has been updated")]
        [TestMethod]
        public void ListCount()
        {
            var list = new List<string>();
            list.Add("hello");
            var immutableList = new ImmutableList<string>(list);

            Assert.AreEqual(1, immutableList.Count);

            list.Add("hello");
            Assert.AreEqual(1, immutableList.Count);

            list.Add("hello");
            Assert.AreEqual(1, immutableList.Count);

            list.Add("hello");
            Assert.AreEqual(1, immutableList.Count);
        }

        /// <summary>
        /// Ensures that indexing into an immutable list retains its content event after the initializer has been updated
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that indexing into an immutable list retains its content event after the initializer has been updated")]
        [TestMethod]
        public void ListIndexingEmpty()
        {
            var list = new List<string>();
            var immutableList = new ImmutableList<string>(list);

            list.Add("first");
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => { var value = immutableList[0]; });

            list.Add("second");
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => { var value = immutableList[0]; });
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => { var value = immutableList[1]; });

            list.Add("third");
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => { var value = immutableList[0]; });
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => { var value = immutableList[1]; });
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => { var value = immutableList[2]; });

            list.Add("fourth");
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => { var value = immutableList[0]; });
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => { var value = immutableList[1]; });
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => { var value = immutableList[2]; });
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => { var value = immutableList[3]; });
        }

        /// <summary>
        /// Ensures that indexing into an immutable list retains its content event after the initializer has been updated
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that indexing into an immutable list retains its content event after the initializer has been updated")]
        [TestMethod]
        public void ListIndexing()
        {
            var list = new List<string>();
            list.Add("first");
            var immutableList = new ImmutableList<string>(list);

            Assert.AreEqual(list[0], immutableList[0]);
            Assert.AreEqual("first", immutableList[0]);

            list.Add("second");
            Assert.AreEqual(list[0], immutableList[0]);
            Assert.AreEqual("first", immutableList[0]);
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => { var value = immutableList[1]; });

            list.Add("third");
            Assert.AreEqual(list[0], immutableList[0]);
            Assert.AreEqual("first", immutableList[0]);
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => { var value = immutableList[1]; });
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => { var value = immutableList[2]; });

            list.Add("fourth");
            Assert.AreEqual(list[0], immutableList[0]);
            Assert.AreEqual("first", immutableList[0]);
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => { var value = immutableList[1]; });
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => { var value = immutableList[2]; });
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => { var value = immutableList[3]; });
        }

        /// <summary>
        /// Ensures that enumerating an immutable list has the same results as enumerating into its initializer
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that enumerating an immutable list has the same results as enumerating into its initializer")]
        [TestMethod]
        public void ListGenericEnumeration()
        {
            var list = new List<string>();
            list.Add("first");
            list.Add("second");
            list.Add("third");
            list.Add("fourth");
            var immutableList = new ImmutableList<string>(list);

            using (var listEnumerator = list.GetEnumerator())
            using (var immutableListEnumerator = immutableList.GetEnumerator())
            {
                while (immutableListEnumerator.MoveNext() && listEnumerator.MoveNext())
                {
                    Assert.AreEqual(listEnumerator.Current, immutableListEnumerator.Current);
                }

                Assert.IsFalse(listEnumerator.MoveNext());
                Assert.IsFalse(immutableListEnumerator.MoveNext());
            }
        }

        /// <summary>
        /// Ensures that enumerating an immutable list has the same results as enumerating into its initializer after the initializer has been modified
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that enumerating an immutable list has the same results as enumerating into its initializer after the initializer has been modified")]
        [TestMethod]
        public void ListGenericEnumerationModified()
        {
            var list = new List<string>();
            list.Add("first");
            list.Add("second");
            list.Add("third");
            list.Add("fourth");
            var immutableList = new ImmutableList<string>(list);

            list.Add("fifth");

            using (var listEnumerator = list.GetEnumerator())
            using (var immutableListEnumerator = immutableList.GetEnumerator())
            {
                while (immutableListEnumerator.MoveNext() && listEnumerator.MoveNext())
                {
                    Assert.AreEqual(listEnumerator.Current, immutableListEnumerator.Current);
                }

                Assert.IsTrue(listEnumerator.MoveNext());
                Assert.IsFalse(immutableListEnumerator.MoveNext());
            }
        }

        /// <summary>
        /// Ensures that enumerating an immutable list has the same results as enumerating into its initializer
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that enumerating an immutable list has the same results as enumerating into its initializer")]
        [TestMethod]
        public void ListEnumeration()
        {
            var list = new List<string>();
            list.Add("first");
            list.Add("second");
            list.Add("third");
            list.Add("fourth");
            var immutableList = new ImmutableList<string>(list);

            var listEnumerator = ((IEnumerable)list).GetEnumerator();
            var immutableListEnumerator = ((IEnumerable)immutableList).GetEnumerator();
            while (immutableListEnumerator.MoveNext() && listEnumerator.MoveNext())
            {
                Assert.AreEqual(listEnumerator.Current, immutableListEnumerator.Current);
            }

            Assert.IsFalse(listEnumerator.MoveNext());
            Assert.IsFalse(immutableListEnumerator.MoveNext());
        }

        /// <summary>
        /// Ensures that enumerating an immutable list has the same results as enumerating into its initializer after the initializer has been modified
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that enumerating an immutable list has the same results as enumerating into its initializer after the initializer has been modified")]
        [TestMethod]
        public void ListEnumerationModified()
        {
            var list = new List<string>();
            list.Add("first");
            list.Add("second");
            list.Add("third");
            list.Add("fourth");
            var immutableList = new ImmutableList<string>(list);

            list.Add("fifth");

            var listEnumerator = ((IEnumerable)list).GetEnumerator();
            var immutableListEnumerator = ((IEnumerable)immutableList).GetEnumerator();
            while (immutableListEnumerator.MoveNext() && listEnumerator.MoveNext())
            {
                Assert.AreEqual(listEnumerator.Current, immutableListEnumerator.Current);
            }

            Assert.IsTrue(listEnumerator.MoveNext());
            Assert.IsFalse(immutableListEnumerator.MoveNext());
        }
    }
}
