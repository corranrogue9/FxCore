namespace System.Collections.Generic
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="ReadOnlyCollection{T}"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class ReadOnlyCollectionUnitTests
    {
        /// <summary>
        /// Ensures that a readonly collection has the same count as its delegate
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that a readonly collection has the same count as its delegate")]
        [TestMethod]
        public void CollectionCount()
        {
            var collection = new List<string>();
            var readonlyCollection = new ReadOnlyCollection<string>(collection);

            Assert.AreEqual(collection.Count, readonlyCollection.Count);

            collection.Add("hello");
            Assert.AreEqual(collection.Count, readonlyCollection.Count);

            collection.Add("hello");
            Assert.AreEqual(collection.Count, readonlyCollection.Count);

            collection.Add("hello");
            Assert.AreEqual(collection.Count, readonlyCollection.Count);
        }

        /// <summary>
        /// Ensures that enumerating a readonly collection has the same results as enumerating into its delegate
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that enumerating a readonly collection has the same results as enumerating into its delegate")]
        [TestMethod]
        public void CollectionGenericEnumeration()
        {
            var collection = new List<string>();
            var readonlyCollection = new ReadOnlyCollection<string>(collection);

            foreach (var element in readonlyCollection)
            {
                Assert.Fail("there are no elements in the list yet");
            }

            collection.Add("first");
            collection.Add("second");
            collection.Add("third");
            collection.Add("fourth");

            using (var collectionEnumerator = collection.GetEnumerator())
            using (var readonlyCollectionEnumerator = readonlyCollection.GetEnumerator())
            {
                while (collectionEnumerator.MoveNext() && readonlyCollectionEnumerator.MoveNext())
                {
                    Assert.AreEqual(collectionEnumerator.Current, readonlyCollectionEnumerator.Current);
                }
            }
        }

        /// <summary>
        /// Ensures that enumerating a readonly collection has the same results as enumerating into its delegate
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that enumerating a readonly collection has the same results as enumerating into its delegate")]
        [TestMethod]
        public void CollectionEnumeration()
        {
            var collection = new List<string>();
            var readonlyCollection = new ReadOnlyCollection<string>(collection);

            foreach (var element in readonlyCollection)
            {
                Assert.Fail("there are no elements in the list yet");
            }

            collection.Add("first");
            collection.Add("second");
            collection.Add("third");
            collection.Add("fourth");

            var collectionEnumerator = ((IEnumerable)collection).GetEnumerator();
            var readonlyCollectionEnumerator = ((IEnumerable)readonlyCollection).GetEnumerator();
            while (collectionEnumerator.MoveNext() && readonlyCollectionEnumerator.MoveNext())
            {
                Assert.AreEqual(collectionEnumerator.Current, readonlyCollectionEnumerator.Current);
            }
        }
    }
}
