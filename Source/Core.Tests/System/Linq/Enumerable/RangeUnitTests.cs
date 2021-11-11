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
            new RangeUnitTests().Range((start, count) => Enumerable.Range(start, count));
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
            new RangeUnitTests().RangeEmpty((start, count) => Enumerable.Range(start, count));
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
            new RangeUnitTests().RangeEmpty((start, count) => Enumerable.Range(start, count));
        }
    }
}
