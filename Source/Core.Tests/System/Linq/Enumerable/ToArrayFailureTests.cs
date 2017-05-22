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
        /// Converts a null sequence to an array
        /// </summary>
        [TestCategory("Failure")]
        [Description("Converts a null sequence to an array")]
        [Priority(1)]
        [TestMethod]
        public void ToArrayNullSequence()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.ToArray());
        }
    }
}
