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
        /// Determines if there are any elements in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Determines if any elements match a condition in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void AnyNullData()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Any());
        }

        /// <summary>
        /// Determines if there are any elements that match a condition in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Determines if there are any elements that match a condition in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void AnyNullPredicate()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<string>().Any(null));
        }
    }
}
