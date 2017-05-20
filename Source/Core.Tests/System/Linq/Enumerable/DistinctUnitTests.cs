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
        /// Gets the distinct values of a sequence with a null comparer
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the distinct values of a sequence with a null comparer")]
        [Priority(1)]
        [TestMethod]
        public void DistinctComparerNullComparer()
        {
            var distinct = Enumerable.Empty<string>().Distinct(null);

            CollectionAssert.AreEqual(Enumerable.Empty<string>().ToList(), distinct.ToList());
        }

        /// <summary>
        /// Gets the distinct values of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the distinct values of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void Distinct()
        {
            var data = new[] { "test1", "test2", "test1", "test3", "test1", "test5", "TEST5" };

            var distinct = data.Distinct();

            CollectionAssert.AreEqual(new[] { "test1", "test2", "test3", "test5", "TEST5" }, distinct.ToList());
        }

        /// <summary>
        /// Gets the distinct values of a sequence using the default comparer
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the distinct values of a sequence using the default comparer")]
        [Priority(1)]
        [TestMethod]
        public void DistinctDefaultComparer()
        {
            var data = new[] { "test1", "test2", "test1", "test3", "test1", "test5", "TEST5" };

            var distinct = data.Distinct(null);

            CollectionAssert.AreEqual(new[] { "test1", "test2", "test3", "test5", "TEST5" }, distinct.ToList());
        }

        /// <summary>
        /// Gets the distinct values of a sequence using a non-default comparer
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the distinct values of a sequence using a non-default comparer")]
        [Priority(1)]
        [TestMethod]
        public void DistinctComparer()
        {
            var data = new[] { "test1", "test2", "test1", "test3", "test1", "test5", "TEST5" };

            var distinct = data.Distinct(StringComparer.OrdinalIgnoreCase);

            CollectionAssert.AreEqual(new[] { "test1", "test2", "test3", "test5" }, distinct.ToList());
        }
    }
}
