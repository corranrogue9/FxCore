namespace System.Collections.Generic
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="ReadOnlyDictionary{TKey, TValue}"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class ReadOnlyDictionaryFailureTests
    {
        /// <summary>
        /// Constructs a new read-only dictionary from a null dictionary
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Constructs a new read-only dictionary from a null dictionary")]
        [TestMethod]
        public void ConstructWithNullDictionary()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => new ReadOnlyDictionary<string, string>(null));
        }

        /// <summary>
        /// Indexes into a read-only dictionary using a null key
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Indexes into a read-only dictionary using a null key")]
        [TestMethod]
        public void IndexNullKey()
        {
            var dictionary = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>());
            ExceptionAssert.Throws<ArgumentNullException>(() => { var value = dictionary[null]; });
        }

        /// <summary>
        /// Indexes into a read-only dictionary using a key that doesn't exist
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Indexes into a read-only dictionary using a key that doesn't exist")]
        [TestMethod]
        public void IndexMissingKey()
        {
            var dictionary = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>());
            ExceptionAssert.Throws<KeyNotFoundException>(() => { var value = dictionary["test"]; });
        }

        /// <summary>
        /// Gets a value of a read-only dictionary using a null key
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Gets a value of a read-only dictionary using a null key")]
        [TestMethod]
        public void TryGetValueNullKey()
        {
            var dictionary = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>());
            string value;
            ExceptionAssert.Throws<ArgumentNullException>(() => dictionary.TryGetValue(null, out value));
        }
    }
}
