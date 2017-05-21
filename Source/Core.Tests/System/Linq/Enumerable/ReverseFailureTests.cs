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
        /// Reverses a sequence that is null
        /// </summary>
        [TestCategory("Failure")]
        [Description("Reverses a sequence that is null")]
        [Priority(1)]
        [TestMethod]
        public void ReverseNull()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Reverse());
        }
    }
}
