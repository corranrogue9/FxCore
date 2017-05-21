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
        /// Skips elements in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Skips elements in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void SkipNull()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Skip(1));
        }

        /// <summary>
        /// Skips elements in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Skips elements in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void SkipWhileNullSequence()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.SkipWhile(value => true)); //// TODO singleton
        }

        /// <summary>
        /// Skips elements in a sequence with a null predicate
        /// </summary>
        [TestCategory("Failure")]
        [Description("Skips elements in a sequence with a null predicate")]
        [Priority(1)]
        [TestMethod]
        public void SkipWhileNullPredicate()
        {
            Func<int, bool> predicate = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3, 4, 5, 6, 7 }.SkipWhile(predicate));
        }

        /// <summary>
        /// Skips elements in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Skips elements in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void SkipWhileIndexNullSequence()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.SkipWhile((value, index) => true)); //// TODO singleton
        }

        /// <summary>
        /// Skips elements in a sequence with a null predicate
        /// </summary>
        [TestCategory("Failure")]
        [Description("Skips elements in a sequence with a null predicate")]
        [Priority(1)]
        [TestMethod]
        public void SkipWhileIndexNullPredicate()
        {
            Func<int, int, bool> predicate = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3, 4, 5, 6, 7 }.SkipWhile(predicate));
        }

        /// <summary>
        /// Skips elements in a massive sequence
        /// </summary>
        [TestCategory("Failure"), TestCategory("LongRunning")]
        [Description("Skips elements in a massive sequence")]
        [Priority(1)]
        [TestMethod]
        public void SkipWhileIndexOverflow()
        {
            ExceptionAssert.Throws<OverflowException>(() => Enumerable.Repeat(0, int.MaxValue).Concat(Enumerable.Repeat(0, 2)).SkipWhile((value, index) => true).LongCount());
        }
    }
}
