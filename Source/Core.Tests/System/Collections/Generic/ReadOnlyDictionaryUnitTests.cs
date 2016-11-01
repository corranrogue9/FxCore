namespace System.Collections.Generic
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="ReadOnlyDictionary{TKey, TValue}"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class ReadOnlyDictionaryUnitTests
    {
        /// <summary>
        /// Ensures that the count of a read-only dictionary is consistent with its initializer
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that the count of a read-only dictionary is consistent with its initializer")]
        [TestMethod]
        public void Count()
        {
            var dictionary = new Dictionary<string, string>();
            var readOnlyDictionary = new ReadOnlyDictionary<string, string>(dictionary);

            Assert.AreEqual(0, readOnlyDictionary.Count);
            Assert.AreEqual(dictionary.Count, readOnlyDictionary.Count);

            dictionary.Add("first key", "first value");
            Assert.AreEqual(1, readOnlyDictionary.Count);
            Assert.AreEqual(dictionary.Count, readOnlyDictionary.Count);

            dictionary.Add("second key", "second value");
            Assert.AreEqual(2, readOnlyDictionary.Count);
            Assert.AreEqual(dictionary.Count, readOnlyDictionary.Count);
        }

        /// <summary>
        /// Ensures that the keys of a read-only dictionary are consistent with its initializer
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that the keys of a read-only dictionary are consistent with its initializer")]
        [TestMethod]
        public void Keys()
        {
            var dictionary = new Dictionary<string, string>();
            var readOnlyDictionary = new ReadOnlyDictionary<string, string>(dictionary);

            CollectionAssert.AreEqual(dictionary.Keys, readOnlyDictionary.Keys.ToList());

            dictionary.Add("first key", "first value");
            CollectionAssert.AreEqual(dictionary.Keys, readOnlyDictionary.Keys.ToList());

            dictionary.Add("second key", "second value");
            CollectionAssert.AreEqual(dictionary.Keys, readOnlyDictionary.Keys.ToList());
        }

        /// <summary>
        /// Ensures that the values of a read-only dictionary are consistent with its initializer
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that the values of a read-only dictionary are consistent with its initializer")]
        [TestMethod]
        public void Values()
        {
            var dictionary = new Dictionary<string, string>();
            var readOnlyDictionary = new ReadOnlyDictionary<string, string>(dictionary);

            CollectionAssert.AreEqual(dictionary.Values, readOnlyDictionary.Values.ToList());

            dictionary.Add("first key", "first value");
            CollectionAssert.AreEqual(dictionary.Values, readOnlyDictionary.Values.ToList());

            dictionary.Add("second key", "second value");
            CollectionAssert.AreEqual(dictionary.Values, readOnlyDictionary.Values.ToList());
        }

        /// <summary>
        /// Ensures that indexing into read-only dictionary is consistent with its initializer
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that indexing into read-only dictionary is consistent with its initializer")]
        [TestMethod]
        public void Indexing()
        {
            var dictionary = new Dictionary<string, string>();
            var readOnlyDictionary = new ReadOnlyDictionary<string, string>(dictionary);

            ExceptionAssert.Throws<KeyNotFoundException>(() => { var value = readOnlyDictionary["first key"]; });
            dictionary.Add("first key", "first value");
            Assert.AreEqual("first value", readOnlyDictionary["first key"]);

            ExceptionAssert.Throws<KeyNotFoundException>(() => { var value = readOnlyDictionary["second key"]; });
            dictionary.Add("second key", "second value");
            Assert.AreEqual("second value", readOnlyDictionary["second key"]);
        }

        /// <summary>
        /// Ensures that a read-only dictionary contains the same keys as its initializer
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that a read-only dictionary contains the same keys as its initializer")]
        [TestMethod]
        public void ContainsKey()
        {
            var dictionary = new Dictionary<string, string>();
            var readOnlyDictionary = new ReadOnlyDictionary<string, string>(dictionary);

            Assert.IsFalse(readOnlyDictionary.ContainsKey("first key"));
            dictionary.Add("first key", "first value");
            Assert.IsTrue(readOnlyDictionary.ContainsKey("first key"));
            Assert.AreEqual(dictionary.ContainsKey("first key"), readOnlyDictionary.ContainsKey("first key"));

            Assert.IsFalse(readOnlyDictionary.ContainsKey("second key"));
            dictionary.Add("second key", "second value");
            Assert.IsTrue(readOnlyDictionary.ContainsKey("second key"));
            Assert.AreEqual(dictionary.ContainsKey("second key"), readOnlyDictionary.ContainsKey("second key"));
        }

        /// <summary>
        /// Ensures that a read-only dictionary contains the same keys and values as its initializer
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that a read-only dictionary contains the same keys and values as its initializer")]
        [TestMethod]
        public void TryGetValue()
        {
            var dictionary = new Dictionary<string, string>();
            var readOnlyDictionary = new ReadOnlyDictionary<string, string>(dictionary);
            string value;

            Assert.IsFalse(readOnlyDictionary.TryGetValue("first key", out value));
            dictionary.Add("first key", "first value");
            Assert.IsTrue(readOnlyDictionary.TryGetValue("first key", out value));
            Assert.AreEqual("first value", value);

            Assert.IsFalse(readOnlyDictionary.TryGetValue("second key", out value));
            dictionary.Add("second key", "second value");
            Assert.IsTrue(readOnlyDictionary.TryGetValue("second key", out value));
            Assert.AreEqual("second value", value);
        }

        /// <summary>
        /// Ensures that enumerating a readonly dictionary has the same results as enumerating into its initializer
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that enumerating a readonly dictionary has the same results as enumerating into its initializer")]
        [TestMethod]
        public void GenericEnumeration()
        {
            var dictionary = new Dictionary<string, string>();
            var readonlyDictionary = new ReadOnlyDictionary<string, string>(dictionary);

            foreach (var element in readonlyDictionary)
            {
                Assert.Fail("there are no elements in the list yet");
            }

            dictionary.Add("first key", "first value");
            dictionary.Add("second key", "second value");
            dictionary.Add("third key", "third value");
            dictionary.Add("fourth key", "fourt value");

            using (var dictionaryEnumerator = dictionary.GetEnumerator())
            using (var readonlyDictionaryEnumerator = readonlyDictionary.GetEnumerator())
            {
                while (dictionaryEnumerator.MoveNext() && readonlyDictionaryEnumerator.MoveNext())
                {
                    Assert.AreEqual(dictionaryEnumerator.Current, readonlyDictionaryEnumerator.Current);
                }
            }
        }

        /// <summary>
        /// Ensures that enumerating a readonly dictionary has the same results as enumerating into its initializer
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that enumerating a readonly dictionary has the same results as enumerating into its initializer")]
        [TestMethod]
        public void Enumeration()
        {
            var dictionary = new Dictionary<string, string>();
            var readonlyDictionary = new ReadOnlyDictionary<string, string>(dictionary);

            foreach (var element in readonlyDictionary)
            {
                Assert.Fail("there are no elements in the list yet");
            }

            dictionary.Add("first key", "first value");
            dictionary.Add("second key", "second value");
            dictionary.Add("third key", "third value");
            dictionary.Add("fourth key", "fourt value");

            var dictionaryEnumerator = ((IEnumerable)dictionary).GetEnumerator();
            var readonlyDictionaryEnumerator = ((IEnumerable)readonlyDictionary).GetEnumerator();
            while (dictionaryEnumerator.MoveNext() && readonlyDictionaryEnumerator.MoveNext())
            {
                Assert.AreEqual(dictionaryEnumerator.Current, readonlyDictionaryEnumerator.Current);
            }
        }
    }
}
