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
        /// Selects a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Selects a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void SelectNull()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Select(value => value * 2));
        }

        /// <summary>
        /// Selects with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Selects with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void SelectNullSelector()
        {
            Func<int, int> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3, 4 }.Select(selector));
        }

        /// <summary>
        /// Selects a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Selects a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void SelectIndexNull()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Select((value, index) => value * 2));
        }

        /// <summary>
        /// Selects with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Selects with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void SelectIndexNullSelector()
        {
            Func<int, int, int> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3, 4 }.Select(selector));
        }
        
        /// <summary>
        /// Selects elements in a sequence that is massive
        /// </summary>
        [TestCategory("Failure")]
        [Description("Selects elements in a sequence that is massive")]
        [Priority(1)]
        [TestMethod]
        public void SelectIndexOverflow()
        {
            ExceptionAssert.Throws<OverflowException>(
                () => Enumerable.Repeat(0, int.MaxValue).Concat(Enumerable.Repeat(0, 2)).Select((value, index) => value).LongCount());
        }
    }
}
