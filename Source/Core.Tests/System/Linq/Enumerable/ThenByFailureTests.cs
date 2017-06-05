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
        public void ThenByNullSequence()
        {
            IOrderedEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.ThenBy(value => value));
        }

        /// <summary>
        /// Orders the elements of a sequence with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Orders the elements of a sequence with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void ThenByNullSelector()
        {
            Func<int, int> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3 }.OrderBy(value => value).ThenBy(selector));
        }

        /// <summary>
        /// Orders the elements of a sequence with a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Orders the elements of a sequence with a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void ThenByComparerNullSequence()
        {
            IOrderedEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.ThenBy(value => value, Comparer<string>.Default));
        }

        /// <summary>
        /// Orders the elements of a sequence with a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Orders the elements of a sequence with a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void ThenByComparerNullSelector()
        {
            Func<int, int> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3 }.OrderBy(value => value).ThenBy(selector, Comparer<int>.Default));
        }
        
        /// <summary>
        /// Orders the elements of a sequence with a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Orders the elements of a sequence with a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void ThenByDescendingNullSequence()
        {
            IOrderedEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.ThenByDescending(value => value));
        }

        /// <summary>
        /// Orders the elements of a sequence with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Orders the elements of a sequence with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void ThenByDescendingNullSelector()
        {
            Func<int, int> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3 }.OrderBy(value => value).ThenByDescending(selector));
        }

        /// <summary>
        /// Orders the elements of a sequence with a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Orders the elements of a sequence with a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void ThenByDescendingComparerNullSequence()
        {
            IOrderedEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.ThenByDescending(value => value, Comparer<string>.Default));
        }

        /// <summary>
        /// Orders the elements of a sequence with a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Orders the elements of a sequence with a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void ThenByDescendingComparerNullSelector()
        {
            Func<int, int> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3 }.OrderBy(value => value).ThenByDescending(selector, Comparer<int>.Default));
        }
    }
}
