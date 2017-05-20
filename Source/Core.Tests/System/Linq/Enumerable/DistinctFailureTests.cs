namespace System.Linq
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class EnumerableFailureTests
    {
        /// <summary>
        /// Gets the distinct values of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the distinct values of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void DistinctNullData()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Distinct());
        }

        /// <summary>
        /// Gets the distinct values of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the distinct values of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void DistinctComparerNullData()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Distinct(StringComparer.Ordinal));
        }
    }
}
