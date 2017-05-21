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
        /// Gets the intersection of two sequences where the first is null
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the intersection of two sequences where the first is null")]
        [Priority(1)]
        [TestMethod]
        public void IntersectNullFirst()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Intersect(new[] { 2, 3, 2, 5, 8, 10 }));
        }

        /// <summary>
        /// Gets the intersection of two sequences where the second is null
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the intersection of two sequences where the second is null")]
        [Priority(1)]
        [TestMethod]
        public void IntersectNullSecond()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 2, 4, 2, 5, 6, 2, 8, 9, 8 }.Intersect(data));
        }

        /// <summary>
        /// Gets the intersection of two sequences where the first is null
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the intersection of two sequences where the first is null")]
        [Priority(1)]
        [TestMethod]
        public void IntersectComparerNullFirst()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Intersect(new[] { "asdf", "yuio", "fdsa", "qwer", "oiuy" }, StringComparer.Ordinal));
        }

        /// <summary>
        /// Gets the intersection of two sequences where the second is null
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the intersection of two sequences where the second is null")]
        [Priority(1)]
        [TestMethod]
        public void IntersectComparerNullSecond()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { "asdf", "rewq", "fdsa", "zxcv", "qwer", "vcxz" }.Intersect(data, StringComparer.Ordinal));
        }
    }
}
