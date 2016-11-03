namespace System.Collections.Generic
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="ImmutableDictionary{TKey, TValue}"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class ImmutableDictionaryFailureTests
    {
        /// <summary>
        /// Constructs a new immutable dictionary from a null dictionary
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Constructs a new immutable dictionary from a null dictionary")]
        [TestMethod]
        public void ConstructWithNullDictionary()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => new ImmutableDictionary<string, string>(null));
        }

        /// <summary>
        /// Constructs a new immutable dictionary from a dictionary with duplicate keys
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Constructs a new immutable dictionary from a dictionary with duplicate keys")]
        [TestMethod]
        public void ConstructWithDuplicateKeys()
        {
            var dictionary = new[] { new KeyValuePair<string, string>("key", "value1"), new KeyValuePair<string, string>("key", "value2") };
            ExceptionAssert.Throws<ArgumentException>(() => new ImmutableDictionary<string, string>(dictionary));
        }

        /// <summary>
        /// Constructs a new immutable dictionary from a null dictionary
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Constructs a new immutable dictionary from a null dictionary")]
        [TestMethod]
        public void ConstructWithNullDictionaryComparer()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => new ImmutableDictionary<string, string>(null, StringComparer.Ordinal));
        }

        /// <summary>
        /// Constructs a new immutable dictionary from a null comparer
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Constructs a new immutable dictionary from a null comparer")]
        [TestMethod]
        public void ConstructWithNullComparer()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => new ImmutableDictionary<string, string>(Enumerable.Empty<KeyValuePair<string, string>>(), null));
        }

        /// <summary>
        /// Constructs a new immutable dictionary from a null dictionary
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Constructs a new immutable dictionary from a null dictionary")]
        [TestMethod]
        public void ConstructWithDuplicateKeysComparer()
        {
            var dictionary = new[] { new KeyValuePair<string, string>("KEY", "value1"), new KeyValuePair<string, string>("key", "value2") };
            ExceptionAssert.Throws<ArgumentException>(() => new ImmutableDictionary<string, string>(dictionary, StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Indexes into a immutable dictionary using a null key
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Indexes into a immutable dictionary using a null key")]
        [TestMethod]
        public void IndexNullKey()
        {
            var dictionary = new ImmutableDictionary<string, string>(new Dictionary<string, string>());
            ExceptionAssert.Throws<ArgumentNullException>(() => { var value = dictionary[null]; });
        }

        /// <summary>
        /// Indexes into a immutable dictionary using a key that doesn't exist
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Indexes into a immutable dictionary using a key that doesn't exist")]
        [TestMethod]
        public void IndexMissingKey()
        {
            var dictionary = new ImmutableDictionary<string, string>(new Dictionary<string, string>());
            ExceptionAssert.Throws<KeyNotFoundException>(() => { var value = dictionary["test"]; });
        }

        /// <summary>
        /// Gets a value of a immutable dictionary using a null key
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Gets a value of a immutable dictionary using a null key")]
        [TestMethod]
        public void TryGetValueNullKey()
        {
            var dictionary = new ImmutableDictionary<string, string>(new Dictionary<string, string>());
            string value;
            ExceptionAssert.Throws<ArgumentNullException>(() => dictionary.TryGetValue(null, out value));
        }
    }
}
