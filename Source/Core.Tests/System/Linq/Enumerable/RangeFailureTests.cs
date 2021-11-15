namespace System.Linq
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class EnumerableFailureTests
    {
        /// <summary>
        /// Gets a range with a negative count
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets a range with a negative count")]
        [Priority(1)]
        [TestMethod]
        public void RangeNegative()
        {
            new RangeFailureTests().RangeNegative(Enumerable.Range);
        }

        /// <summary>
        /// Gets a range that will go out of bounds of an integer
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets a range that will go out of bounds of an integer")]
        [Priority(1)]
        [TestMethod]
        public void RangeMassive()
        {
            new RangeFailureTests().RangeMassive(Enumerable.Range);
        }
    }
}
