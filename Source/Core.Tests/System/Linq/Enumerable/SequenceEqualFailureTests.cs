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
        /// Checks equality of two sequences when the first is null
        /// </summary>
        [TestCategory("Failure")]
        [Description("Checks equality of two sequences when the first is null")]
        [Priority(1)]
        [TestMethod]
        public void SequenceEqualNullFirst()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.SequenceEqual(new[] { 1, 2, 3 }));
        }

        /// <summary>
        /// Checks equality of two sequences when the second is null
        /// </summary>
        [TestCategory("Failure")]
        [Description("Checks equality of two sequences when the second is null")]
        [Priority(1)]
        [TestMethod]
        public void SequenceEqualNullSecond()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3 }.SequenceEqual(data));
        }

        /// <summary>
        /// Checks equality of two sequences when the first is null
        /// </summary>
        [TestCategory("Failure")]
        [Description("Checks equality of two sequences when the first is null")]
        [Priority(1)]
        [TestMethod]
        public void SequenceEqualComparerNullFirst()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.SequenceEqual(new[] { 1, 2, 3 }, null));
        }

        /// <summary>
        /// Checks equality of two sequences when the second is null
        /// </summary>
        [TestCategory("Failure")]
        [Description("Checks equality of two sequences when the second is null")]
        [Priority(1)]
        [TestMethod]
        public void SequenceEqualComparerNullSecond()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3 }.SequenceEqual(data), null);
        }
    }
}
