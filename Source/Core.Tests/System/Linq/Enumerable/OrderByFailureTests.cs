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
        /// Orders the elements of a sequence with a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Orders the elements of a sequence with a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void OrderByNullSequence()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.OrderBy(value => value));
        }

        /// <summary>
        /// Orders the elements of a sequence with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Orders the elements of a sequence with a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void OrderByNullSelector()
        {
            Func<int, int> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3 }.OrderBy(selector));
        }

        /// <summary>
        /// Orders the elements of a sequence with a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Orders the elements of a sequence with a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void OrderByComparerNullSequence()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.OrderBy(value => value, Comparer<string>.Default));
        }

        /// <summary>
        /// Orders the elements of a sequence with a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Orders the elements of a sequence with a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void OrderByComparerNullSelector()
        {
            Func<int, int> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3 }.OrderBy(selector, Comparer<int>.Default));
        }

        /// <summary>
        /// Orders the elements of a sequence with a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Orders the elements of a sequence with a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void OrderByDescendingNullSequence()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.OrderByDescending(value => value));
        }

        /// <summary>
        /// Orders the elements of a sequence with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Orders the elements of a sequence with a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void OrderByDescendingNullSelector()
        {
            Func<int, int> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3 }.OrderByDescending(selector));
        }

        /// <summary>
        /// Orders the elements of a sequence with a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Orders the elements of a sequence with a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void OrderByDescendingComparerNullSequence()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.OrderByDescending(value => value, Comparer<string>.Default));
        }

        /// <summary>
        /// Orders the elements of a sequence with a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Orders the elements of a sequence with a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void OrderByDescendingComparerNullSelector()
        {
            Func<int, int> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3 }.OrderByDescending(selector, Comparer<int>.Default));
        }
    }
}
