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
        public void SelectManyNullSequence()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.SelectMany(value => value));
        }

        /// <summary>
        /// Selects with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Selects with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void SelectManyNullSelector()
        {
            Func<string, IEnumerable<char>> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { "test", "value" }.SelectMany(selector));
        }

        /// <summary>
        /// Selects a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Selects a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void SelectManyIndexNullSequence()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.SelectMany((value, index) => value));
        }

        /// <summary>
        /// Selects with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Selects with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void SelectManyIndexNullSelector()
        {
            Func<string, int, IEnumerable<char>> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { "test", "value" }.SelectMany(selector));
        }

        /// <summary>
        /// Selects elements in a sequence that is massive
        /// </summary>
        [TestCategory("Failure"), TestCategory("LongRunning")]
        [Description("Selects elements in a sequence that is massive")]
        [Priority(1)]
        [TestMethod]
        public void SelectManyIndexOverflow()
        {
            ExceptionAssert.Throws<OverflowException>(
                () => Enumerable.Repeat("t", int.MaxValue).Concat(Enumerable.Repeat("t", 2)).SelectMany((value, index) => value).LongCount());
        }

        /// <summary>
        /// Selects a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Selects a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void SelectManyResultNullSequence()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.SelectMany(val1 => val1.AsEnumerable(), (val1, val2) => val2.ToString()));
        }

        /// <summary>
        /// Selects with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Selects with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void SelectManyResultNullCollectionSelector()
        {
            Func<string, IEnumerable<char>> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { "test", "value" }.SelectMany(selector, (val1, val2) => val2.ToString()));
        }

        /// <summary>
        /// Selects with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Selects with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void SelectManyResultNullResultSelector()
        {
            Func<string, char, string> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { "test", "value" }.SelectMany(val1 => val1.AsEnumerable(), selector));
        }

        /// <summary>
        /// Selects a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Selects a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void SelectManyResultIndexNullSequence()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.SelectMany((val1, index) => val1.AsEnumerable(), (val1, val2) => val2.ToString()));
        }

        /// <summary>
        /// Selects with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Selects with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void SelectManyResultIndexNullCollectionSelector()
        {
            Func<string, int, IEnumerable<char>> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { "test", "value" }.SelectMany(selector, (val1, val2) => val2.ToString()));
        }

        /// <summary>
        /// Selects with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Selects with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void SelectManyResultIndexNullResultSelector()
        {
            Func<string, char, string> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { "test", "value" }.SelectMany((val1, index) => val1.AsEnumerable(), selector));
        }

        /// <summary>
        /// Selects elements in a sequence that is massive
        /// </summary>
        [TestCategory("Failure"), TestCategory("LongRunning")]
        [Description("Selects elements in a sequence that is massive")]
        [Priority(1)]
        [TestMethod]
        public void SelectManyResultIndexOverflow()
        {
            ExceptionAssert.Throws<OverflowException>(
                () => Enumerable.Repeat("t", int.MaxValue).Concat(Enumerable.Repeat("t", 2)).SelectMany((value, index) => value, (val1, val2) => val2.ToString()).LongCount());
        }
    }
}
