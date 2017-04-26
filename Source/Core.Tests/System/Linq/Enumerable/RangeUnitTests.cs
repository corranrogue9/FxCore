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
        /// Gets a range
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets a range")]
        [Priority(1)]
        [TestMethod]
        public void Range()
        {
            CollectionAssert.AreEqual(new[] { 10, 11, 12, 13, 14 }, Enumerable.Range(10, 5).ToList());
        }

        /// <summary>
        /// Gets an empty range
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets an empty range")]
        [Priority(1)]
        [TestMethod]
        public void RangeEmpty()
        {
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), Enumerable.Range(10, 0).ToList());
        }

        /// <summary>
        /// Gets a range with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets a range with a single element")]
        [Priority(1)]
        [TestMethod]
        public void RangeSingle()
        {
            CollectionAssert.AreEqual(new[] { 10 }, Enumerable.Range(10, 1).ToList());
        }
    }
}
