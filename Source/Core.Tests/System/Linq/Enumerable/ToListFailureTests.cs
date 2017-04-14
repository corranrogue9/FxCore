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
        /// Creates a list from a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a list from a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToListNullSequence()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.ToList());
        }
    }
}
