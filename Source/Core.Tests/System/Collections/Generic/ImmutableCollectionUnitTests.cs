namespace System.Collections.Generic
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="ImmutableCollection{T}"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class ImmutableCollectionUnitTests
    {
        /// <summary>
        /// Ensures that an immutable collection retains its count event after its initializer has been updated
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that an immutable collection retains its count event after its initializer has been updated")]
        [TestMethod]
        public void CollectionCountEmpty()
        {
            var collection = new List<string>();
            var immutableCollection = new ImmutableCollection<string>(collection);

            Assert.AreEqual(0, immutableCollection.Count);

            collection.Add("hello");
            Assert.AreEqual(0, immutableCollection.Count);

            collection.Add("hello");
            Assert.AreEqual(0, immutableCollection.Count);

            collection.Add("hello");
            Assert.AreEqual(0, immutableCollection.Count);
        }

        /// <summary>
        /// Ensures that an immutable collection retains its count event after its initializer has been updated
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that an immutable collection retains its count event after its initializer has been updated")]
        [TestMethod]
        public void CollectionCount()
        {
            var collection = new List<string>();
            collection.Add("hello");
            var immutableCollection = new ImmutableCollection<string>(collection);

            Assert.AreEqual(1, immutableCollection.Count);

            collection.Add("hello");
            Assert.AreEqual(1, immutableCollection.Count);

            collection.Add("hello");
            Assert.AreEqual(1, immutableCollection.Count);

            collection.Add("hello");
            Assert.AreEqual(1, immutableCollection.Count);
        }

        /// <summary>
        /// Ensures that enumerating an immutable collection has the same results as enumerating into its initializer
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that enumerating an immutable collection has the same results as enumerating into its initializer")]
        [TestMethod]
        public void CollectionGenericEnumeration()
        {
            var collection = new List<string>();
            collection.Add("first");
            collection.Add("second");
            collection.Add("third");
            collection.Add("fourth");
            var immutableCollection = new ImmutableCollection<string>(collection);
            
            using (var collectionEnumerator = collection.GetEnumerator())
            using (var immutableCollectionEnumerator = immutableCollection.GetEnumerator())
            {
                while (immutableCollectionEnumerator.MoveNext() && collectionEnumerator.MoveNext())
                {
                    Assert.AreEqual(collectionEnumerator.Current, immutableCollectionEnumerator.Current);
                }

                Assert.IsFalse(collectionEnumerator.MoveNext());
                Assert.IsFalse(immutableCollectionEnumerator.MoveNext());
            }
        }

        /// <summary>
        /// Ensures that enumerating an immutable collection has the same results as enumerating into its initializer after the initializer has been modified
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that enumerating an immutable collection has the same results as enumerating into its initializer after the initializer has been modified")]
        [TestMethod]
        public void CollectionGenericEnumerationModified()
        {
            var collection = new List<string>();
            collection.Add("first");
            collection.Add("second");
            collection.Add("third");
            collection.Add("fourth");
            var immutableCollection = new ImmutableCollection<string>(collection);

            collection.Add("fifth");

            using (var collectionEnumerator = collection.GetEnumerator())
            using (var immutableCollectionEnumerator = immutableCollection.GetEnumerator())
            {
                while (immutableCollectionEnumerator.MoveNext() && collectionEnumerator.MoveNext())
                {
                    Assert.AreEqual(collectionEnumerator.Current, immutableCollectionEnumerator.Current);
                }

                Assert.IsTrue(collectionEnumerator.MoveNext());
                Assert.IsFalse(immutableCollectionEnumerator.MoveNext());
            }
        }

        /// <summary>
        /// Ensures that enumerating an immutable collection has the same results as enumerating into its initializer
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that enumerating an immutable collection has the same results as enumerating into its initializer")]
        [TestMethod]
        public void CollectionEnumeration()
        {
            var collection = new List<string>();
            collection.Add("first");
            collection.Add("second");
            collection.Add("third");
            collection.Add("fourth");
            var immutableCollection = new ImmutableCollection<string>(collection);

            var collectionEnumerator = ((IEnumerable)collection).GetEnumerator();
            var immutableCollectionEnumerator = ((IEnumerable)immutableCollection).GetEnumerator();
            while (immutableCollectionEnumerator.MoveNext() && collectionEnumerator.MoveNext())
            {
                Assert.AreEqual(collectionEnumerator.Current, immutableCollectionEnumerator.Current);
            }

            Assert.IsFalse(collectionEnumerator.MoveNext());
            Assert.IsFalse(immutableCollectionEnumerator.MoveNext());
        }

        /// <summary>
        /// Ensures that enumerating an immutable collection has the same results as enumerating into its initializer after the initializer has been modified
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that enumerating an immutable collection has the same results as enumerating into its initializer after the initializer has been modified")]
        [TestMethod]
        public void CollectionEnumerationModified()
        {
            var collection = new List<string>();
            collection.Add("first");
            collection.Add("second");
            collection.Add("third");
            collection.Add("fourth");
            var immutableCollection = new ImmutableCollection<string>(collection);

            collection.Add("fifth");

            var collectionEnumerator = ((IEnumerable)collection).GetEnumerator();
            var immutableCollectionEnumerator = ((IEnumerable)immutableCollection).GetEnumerator();
            while (immutableCollectionEnumerator.MoveNext() && collectionEnumerator.MoveNext())
            {
                Assert.AreEqual(collectionEnumerator.Current, immutableCollectionEnumerator.Current);
            }

            Assert.IsTrue(collectionEnumerator.MoveNext());
            Assert.IsFalse(immutableCollectionEnumerator.MoveNext());
        }
    }
}
