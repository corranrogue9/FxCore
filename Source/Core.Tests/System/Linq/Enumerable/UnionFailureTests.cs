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
        /// Unions a null sequence with another sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Unions a null sequence with another sequence")]
        [Priority(1)]
        [TestMethod]
        public void UnionNullFirst()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Union(new[] { 2, 5, 6, -1 }).ToList());
        }

        /// <summary>
        /// Unions a sequence with a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Unions a sequence with a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void UnionSecondNull()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3, 4, 5 }.Union(data).ToList());
        }

        /// <summary>
        /// Unions a null sequence with another sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Unions a null sequence with another sequence")]
        [Priority(1)]
        [TestMethod]
        public void UnionComparerNullFirst()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Union(new[] { 2, 5, 6, -1 }, EqualityComparer<int>.Default).ToList());
        }

        /// <summary>
        /// Unions a sequence with a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Unions a sequence with a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void UnionComparerSecondNull()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3, 4, 5 }.Union(data, EqualityComparer<int>.Default).ToList());
        }
    }
}
