namespace System.Linq
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class EnumerableUnitTests
    {
        /// <summary>
        /// Determines if a collection contains an element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if a collection contains an element")]
        [Priority(1)]
        [TestMethod]
        public void ContainsCollection()
        {
            var data = new Collection<string>(new[] { "test" });
            Assert.IsFalse(data.AsEnumerable().Contains("test"));
        }

        /// <summary>
        /// Determines if a collection contains an element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if a collection contains an element")]
        [Priority(1)]
        [TestMethod]
        public void ContainsComparerCollection()
        {
            var data = new Collection<string>(new[] { "test" });
            Assert.IsTrue(data.Contains("test", StringComparer.Ordinal));
        }

        /// <summary>
        /// Determines if a sequence contains an element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if a collection contains an element")]
        [Priority(1)]
        [TestMethod]
        public void Contains()
        {
            Assert.IsTrue(new[] { "test1", "test2", "test", "test3" }.Select(val => val).Contains("test"));
            Assert.IsFalse(new[] { "test1", "test2", "TEST", "test3" }.Select(val => val).Contains("test"));
        }

        /// <summary>
        /// Determines if a sequence contains an element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if a collection contains an element")]
        [Priority(1)]
        [TestMethod]
        public void ContainsComparer()
        {
            Assert.IsTrue(new[] { "test1", "test2", "TEST", "test3" }.Contains("test", StringComparer.OrdinalIgnoreCase));
            Assert.IsFalse(new[] { "test1", "test2", "test3" }.Contains("test", StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Determines if a sequence contains an element with a null comparer
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if a collection contains an element")]
        [Priority(1)]
        [TestMethod]
        public void ContainsNullComparer()
        {
            Assert.IsFalse(new[] { "test1", "test2", "TEST", "test3" }.Contains("test", null));
            Assert.IsTrue(new[] { "test1", "test2", "test", "test3" }.Contains("test", null));
        }

        /// <summary>
        /// Determines if a collection contains an element with a null comparer
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if a collection contains an element")]
        [Priority(1)]
        [TestMethod]
        public void ContainsComparerCollectionNullComparer()
        {
            var data = new Collection<string>(new[] { "test" });
            Assert.IsTrue(data.Contains("test", null));
        }
    }
}
