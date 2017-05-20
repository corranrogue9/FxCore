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
        /// Determines if a null sequence contains an element
        /// </summary>
        [TestCategory("Failure")]
        [Description("Determines if a null sequence contains an element")]
        [Priority(1)]
        [TestMethod]
        public void ContainsNullSequence()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Contains("hello"));
        }

        /// <summary>
        /// Determines if a null sequence contains an element
        /// </summary>
        [TestCategory("Failure")]
        [Description("Determines if a null sequence contains an element")]
        [Priority(1)]
        [TestMethod]
        public void ContainsComparerNullSequence()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Contains("hello", StringComparer.Ordinal));
        }
    }
}
