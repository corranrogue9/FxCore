namespace System.Collections.Generic
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="ImmutableDictionary{TKey, TValue}"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class ImmutableDictionaryUnitTests
    {
        /// <summary>
        /// Ensures that an immutable dictionary retains its count even after its initializer has been updated
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that an immutable dictionary retains its count even after its initializer has been updated")]
        [TestMethod]
        public void CountEmpty()
        {
            var dictionary = new Dictionary<string, string>();
            var immutableDictionary = new ImmutableDictionary<string, string>(dictionary);

            Assert.AreEqual(0, immutableDictionary.Count);

            dictionary.Add("first key", "first value");
            Assert.AreEqual(0, immutableDictionary.Count);

            dictionary.Add("second key", "second value");
            Assert.AreEqual(0, immutableDictionary.Count);
        }

        /// <summary>
        /// Ensures that an immutable dictionary retains its count even after its initializer has been updated
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that an immutable dictionary retains its count even after its initializer has been updated")]
        [TestMethod]
        public void Count()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("first key", "first value");
            var immutableDictionary = new ImmutableDictionary<string, string>(dictionary);

            Assert.AreEqual(1, immutableDictionary.Count);

            dictionary.Add("second key", "second value");
            Assert.AreEqual(1, immutableDictionary.Count);

            dictionary.Add("third key", "third value");
            Assert.AreEqual(1, immutableDictionary.Count);
        }

        /// <summary>
        /// Ensures that the keys of an immutable dictionary remain the same even after the initializer has changed
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that the keys of an immutable dictionary remain the same even after the initializer has changed")]
        [TestMethod]
        public void Keys()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("first key", "first value");
            var immutableDictionary = new ImmutableDictionary<string, string>(dictionary);

            CollectionAssert.AreEqual(new[] { "first key" }, immutableDictionary.Keys.ToList());

            dictionary.Add("second key", "second value");
            CollectionAssert.AreEqual(new[] { "first key" }, immutableDictionary.Keys.ToList());
        }

        /// <summary>
        /// Ensures that the keys of an immutable dictionary remain the same even after the initializer has changed
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that the keys of an immutable dictionary remain the same even after the initializer has changed")]
        [TestMethod]
        public void KeysEmpty()
        {
            var dictionary = new Dictionary<string, string>();
            var immutableDictionary = new ImmutableDictionary<string, string>(dictionary);

            Assert.IsFalse(immutableDictionary.Keys.Any());

            dictionary.Add("first key", "first value");
            Assert.IsFalse(immutableDictionary.Keys.Any());

            dictionary.Add("second key", "second value");
            Assert.IsFalse(immutableDictionary.Keys.Any());
        }

        /// <summary>
        /// Ensures that the values of an immutable dictionary remain the same even after the initializer has changed
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that the values of an immutable dictionary remain the same even after the initializer has changed")]
        [TestMethod]
        public void Values()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("first key", "first value");
            var immutableDictionary = new ImmutableDictionary<string, string>(dictionary);

            CollectionAssert.AreEqual(new[] { "first value" }, immutableDictionary.Values.ToList());

            dictionary.Add("second key", "second value");
            CollectionAssert.AreEqual(new[] { "first value" }, immutableDictionary.Values.ToList());
        }

        /// <summary>
        /// Ensures that the values of an immutable dictionary remain the same even after the initializer has changed
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that the values of an immutable dictionary remain the same even after the initializer has changed")]
        [TestMethod]
        public void ValuesEmpty()
        {
            var dictionary = new Dictionary<string, string>();
            var immutableDictionary = new ImmutableDictionary<string, string>(dictionary);

            Assert.IsFalse(immutableDictionary.Values.Any());

            dictionary.Add("first key", "first value");
            Assert.IsFalse(immutableDictionary.Values.Any());

            dictionary.Add("second key", "second value");
            Assert.IsFalse(immutableDictionary.Values.Any());
        }

        /// <summary>
        /// Ensures that indexing into an immutable dictionary remains the same even after its initializer has changed
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that indexing into an immutable dictionary remains the same even after its initializer has changed")]
        [TestMethod]
        public void IndexingEmpty()
        {
            var dictionary = new Dictionary<string, string>();
            var immutableDictionary = new ImmutableDictionary<string, string>(dictionary);

            dictionary.Add("first key", "first value");
            ExceptionAssert.Throws<KeyNotFoundException>(() => { var value = immutableDictionary["first key"]; });

            dictionary.Add("second key", "second value");
            ExceptionAssert.Throws<KeyNotFoundException>(() => { var value = immutableDictionary["first key"]; });
            ExceptionAssert.Throws<KeyNotFoundException>(() => { var value = immutableDictionary["second key"]; });
        }

        /// <summary>
        /// Ensures that indexing into an immutable dictionary remains the same even after its initializer has changed
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that indexing into an immutable dictionary remains the same even after its initializer has changed")]
        [TestMethod]
        public void Indexing()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("first key", "first value");
            var immutableDictionary = new ImmutableDictionary<string, string>(dictionary);

            Assert.AreEqual(dictionary["first key"], immutableDictionary["first key"]);
            Assert.AreEqual("first value", immutableDictionary["first key"]);

            dictionary.Add("second key", "second value");
            Assert.AreEqual(dictionary["first key"], immutableDictionary["first key"]);
            Assert.AreEqual("first value", immutableDictionary["first key"]);
            ExceptionAssert.Throws<KeyNotFoundException>(() => { var value = immutableDictionary["second key"]; });
        }

        /// <summary>
        /// Ensures that an immutable dictionary contains the same keys even after its initializer has changed
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that an immutable dictionary contains the same keys even after its initializer has changed")]
        [TestMethod]
        public void ContainsKeyEmpty()
        {
            var dictionary = new Dictionary<string, string>();
            var immutableDictionary = new ImmutableDictionary<string, string>(dictionary);

            Assert.IsFalse(immutableDictionary.ContainsKey("first key"));
            dictionary.Add("first key", "first value");
            Assert.IsFalse(immutableDictionary.ContainsKey("first key"));

            Assert.IsFalse(immutableDictionary.ContainsKey("first key"));
            Assert.IsFalse(immutableDictionary.ContainsKey("second key"));
            dictionary.Add("second key", "second value");
            Assert.IsFalse(immutableDictionary.ContainsKey("first key"));
            Assert.IsFalse(immutableDictionary.ContainsKey("second key"));
        }

        /// <summary>
        /// Ensures that an immutable dictionary contains the same keys even after its initializer has changed
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that an immutable dictionary contains the same keys even after its initializer has changed")]
        [TestMethod]
        public void ContainsKey()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("first key", "first value");
            var immutableDictionary = new ImmutableDictionary<string, string>(dictionary);

            Assert.IsTrue(immutableDictionary.ContainsKey("first key"));

            Assert.IsFalse(immutableDictionary.ContainsKey("second key"));
            dictionary.Add("second key", "second value");
            Assert.IsTrue(immutableDictionary.ContainsKey("first key"));
            Assert.IsFalse(immutableDictionary.ContainsKey("second key"));
        }

        /// <summary>
        /// Ensures that an immutable dictionary contains the same keys and values even after its initializer has changed
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that an immutable dictionary contains the same keys and values even after its initializer has changed")]
        [TestMethod]
        public void TryGetValueEmpty()
        {
            var dictionary = new Dictionary<string, string>();
            var immutableDictionary = new ImmutableDictionary<string, string>(dictionary);
            string value;

            Assert.IsFalse(immutableDictionary.TryGetValue("first key", out value));
            dictionary.Add("first key", "first value");
            Assert.IsFalse(immutableDictionary.TryGetValue("first key", out value));
            Assert.AreNotEqual("first value", value);

            Assert.IsFalse(immutableDictionary.TryGetValue("second key", out value));
            dictionary.Add("second key", "second value");
            Assert.IsFalse(immutableDictionary.TryGetValue("second key", out value));
            Assert.AreNotEqual("second value", value);
        }

        /// <summary>
        /// Ensures that an immutable dictionary contains the same keys and values even after its initializer has changed
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that an immutable dictionary contains the same keys and values even after its initializer has changed")]
        [TestMethod]
        public void TryGetValue()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("first key", "first value");
            var immutableDictionary = new ImmutableDictionary<string, string>(dictionary);
            string value;

            Assert.IsTrue(immutableDictionary.TryGetValue("first key", out value));
            Assert.AreEqual("first value", value);

            Assert.IsFalse(immutableDictionary.TryGetValue("second key", out value));
            dictionary.Add("second key", "second value");
            Assert.IsFalse(immutableDictionary.TryGetValue("second key", out value));
            Assert.AreNotEqual("second value", value);
        }

        /// <summary>
        /// Ensures that an immutable dictionary properly retrieves values with a non-default comparer
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that an immutable dictionary properly retrieves values with a non-default comparer")]
        [TestMethod]
        public void TryGetValueComparer()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("first key", "first value");
            var immutableDictionary = new ImmutableDictionary<string, string>(dictionary, StringComparer.OrdinalIgnoreCase);
            string value;

            Assert.IsTrue(immutableDictionary.TryGetValue("FIRST KEY", out value));
            Assert.AreEqual("first value", value);

            Assert.IsFalse(immutableDictionary.TryGetValue("second key", out value));
        }

        /// <summary>
        /// Ensures that enumerating an immutable dictionary has the same results as enumerating into its initializer
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that enumerating an immutable dictionary has the same results as enumerating into its initializer")]
        [TestMethod]
        public void GenericEnumeration()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("first key", "first value");
            dictionary.Add("second key", "second value");
            dictionary.Add("third key", "third value");
            dictionary.Add("fourth key", "fourt value");
            var immutableDictionary = new ImmutableDictionary<string, string>(dictionary);
            
            using (var dictionaryEnumerator = dictionary.GetEnumerator())
            using (var immutableDictionaryEnumerator = immutableDictionary.GetEnumerator())
            {
                while (immutableDictionaryEnumerator.MoveNext() && dictionaryEnumerator.MoveNext())
                {
                    Assert.AreEqual(dictionaryEnumerator.Current, immutableDictionaryEnumerator.Current);
                }

                Assert.IsFalse(dictionaryEnumerator.MoveNext());
                Assert.IsFalse(immutableDictionaryEnumerator.MoveNext());
            }
        }

        /// <summary>
        /// Ensures that enumerating an immutable dictionary has the same results as enumerating into its initializer after the initializer has been modified
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that enumerating an immutable dictionary has the same results as enumerating into its initializer after the initializer has been modified")]
        [TestMethod]
        public void GenericEnumerationModified()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("first key", "first value");
            dictionary.Add("second key", "second value");
            dictionary.Add("third key", "third value");
            dictionary.Add("fourth key", "fourt value");
            var immutableDictionary = new ImmutableDictionary<string, string>(dictionary);

            dictionary.Add("fifth key", "fifth value");

            using (var dictionaryEnumerator = dictionary.GetEnumerator())
            using (var immutableDictionaryEnumerator = immutableDictionary.GetEnumerator())
            {
                while (immutableDictionaryEnumerator.MoveNext() && dictionaryEnumerator.MoveNext())
                {
                    Assert.AreEqual(dictionaryEnumerator.Current, immutableDictionaryEnumerator.Current);
                }

                Assert.IsTrue(dictionaryEnumerator.MoveNext());
                Assert.IsFalse(immutableDictionaryEnumerator.MoveNext());
            }
        }

        /// <summary>
        /// Ensures that enumerating an immutable dictionary has the same results as enumerating into its initializer
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that enumerating an immutable dictionary has the same results as enumerating into its initializer")]
        [TestMethod]
        public void Enumeration()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("first key", "first value");
            dictionary.Add("second key", "second value");
            dictionary.Add("third key", "third value");
            dictionary.Add("fourth key", "fourt value");
            var immutableDictionary = new ImmutableDictionary<string, string>(dictionary);

            var dictionaryEnumerator = ((IEnumerable)dictionary).GetEnumerator();
            var immutableDictionaryEnumerator = ((IEnumerable)immutableDictionary).GetEnumerator();
            while (immutableDictionaryEnumerator.MoveNext() && dictionaryEnumerator.MoveNext())
            {
                Assert.AreEqual(dictionaryEnumerator.Current, immutableDictionaryEnumerator.Current);
            }

            Assert.IsFalse(dictionaryEnumerator.MoveNext());
            Assert.IsFalse(immutableDictionaryEnumerator.MoveNext());
        }

        /// <summary>
        /// Ensures that enumerating an immutable dictionary has the same results as enumerating into its initializer after the initializer has been modified
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that enumerating an immutable dictionary has the same results as enumerating into its initializer after the initializer has been modified")]
        [TestMethod]
        public void EnumerationModified()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("first key", "first value");
            dictionary.Add("second key", "second value");
            dictionary.Add("third key", "third value");
            dictionary.Add("fourth key", "fourt value");
            var immutableDictionary = new ImmutableDictionary<string, string>(dictionary);

            dictionary.Add("fifth key", "fifth value");

            var dictionaryEnumerator = ((IEnumerable)dictionary).GetEnumerator();
            var immutableDictionaryEnumerator = ((IEnumerable)immutableDictionary).GetEnumerator();
            while (immutableDictionaryEnumerator.MoveNext() && dictionaryEnumerator.MoveNext())
            {
                Assert.AreEqual(dictionaryEnumerator.Current, immutableDictionaryEnumerator.Current);
            }

            Assert.IsTrue(dictionaryEnumerator.MoveNext());
            Assert.IsFalse(immutableDictionaryEnumerator.MoveNext());
        }
    }
}
