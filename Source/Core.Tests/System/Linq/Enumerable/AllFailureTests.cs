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
        /// Determines if all elements match a condition in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Determines if all elements match a condition in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void AllNullData()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.All(val => false)); 
        }

        /// <summary>
        /// Determines if all elements match a null condition
        /// </summary>
        [TestCategory("Failure")]
        [Description("Determines if all elements match a null condition")]
        [Priority(1)]
        [TestMethod]
        public void AllNullPredicate()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<string>().All(null));
        }
    }
}
