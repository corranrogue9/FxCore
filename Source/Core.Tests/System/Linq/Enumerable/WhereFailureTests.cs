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
        /// Gets the elements in a null sequence that meet a condition
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the elements in a null sequence that meet a condition")]
        [Priority(1)]
        [TestMethod]
        public void WhereNullSequence()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Where(value => true)); //// TODO singleton
        }

        /// <summary>
        /// Gets the elements in a sequence that meet a null condition
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the elements in a sequence that meet a null condition")]
        [Priority(1)]
        [TestMethod]
        public void WhereNullPredicate()
        {
            Func<int, bool> predicate = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 2, 5, 7, 8, 10 }.Where(predicate));
        }

        /// <summary>
        /// Gets the elements in a null sequence that meet a condition
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the elements in a null sequence that meet a condition")]
        [Priority(1)]
        [TestMethod]
        public void WhereIndexNullSequence()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Where((value, index) => true)); //// TODO singleton
        }

        /// <summary>
        /// Gets the elements in a sequence that meet a null condition
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the elements in a sequence that meet a null condition")]
        [Priority(1)]
        [TestMethod]
        public void WhereIndexNullPredicate()
        {
            Func<int, int, bool> predicate = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 2, 5, 7, 8, 10 }.Where(predicate));
        }

        /// <summary>
        /// Gets the elements in a massive sequence that meet a condition
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the elements in a sequence that meet a null condition")]
        [Priority(1)]
        [TestMethod]
        public void WhereIndexOverflow()
        {
            //// TODO singleton
            ExceptionAssert.Throws<OverflowException>(
                () => Enumerable.Repeat(0, int.MaxValue).Concat(Enumerable.Repeat(0, 2)).Where((value, index) => true).LongCount());
        }
    }
}
