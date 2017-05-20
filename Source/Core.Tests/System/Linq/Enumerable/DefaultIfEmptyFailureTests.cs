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
        /// Gets a default with a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets a default with a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void DefaultIfEmptyNullData()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.DefaultIfEmpty());
        }

        /// <summary>
        /// Gets a default with a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets a default with a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void DefaultIfEmptyDefaultNullData()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.DefaultIfEmpty(string.Empty));
        }
    }
}
