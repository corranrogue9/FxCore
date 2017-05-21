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
        /// Takes elements in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Takes elements in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void TakeNullSequence()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Take(3));
        }

        /// <summary>
        /// Takes elements in a sequence that is massive
        /// </summary>
        [TestCategory("Failure"), TestCategory("LongRunning")]
        [Description("Takes elements in a sequence that is massive")]
        [Priority(1)]
        [TestMethod]
        public void TakeWhileOverflow()
        {
            Enumerable.Repeat(0, int.MaxValue).Concat(Enumerable.Repeat(0, 2)).TakeWhile(value => true).LongCount(); //// TODO singleton
        }

        /// <summary>
        /// Takes elements in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Takes elements in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void TakeWhileNullSequence()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.TakeWhile(value => true)); //// TODO singleton
        }

        /// <summary>
        /// Takes elements in a sequence with a null predicate
        /// </summary>
        [TestCategory("Failure")]
        [Description("Takes elements in a sequence with a null predicate")]
        [Priority(1)]
        [TestMethod]
        public void TakeWhileNullPredicate()
        {
            Func<int, bool> predicate = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3, 4, 5, 6, 7 }.TakeWhile(predicate));
        }

        /// <summary>
        /// Takes elements in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Takes elements in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void TakeWhileIndexNullSequence()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.TakeWhile((value, index) => true)); //// TODO singleton
        }

        /// <summary>
        /// Takes elements in a sequence with a null predicate
        /// </summary>
        [TestCategory("Failure")]
        [Description("Takes elements in a sequence with a null predicate")]
        [Priority(1)]
        [TestMethod]
        public void TakeWhileIndexNullPredicate()
        {
            Func<int, int, bool> predicate = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3, 4, 5, 6, 7 }.TakeWhile(predicate));
        }

        /// <summary>
        /// Takes elements in a sequence that is massive
        /// </summary>
        [TestCategory("Failure")]
        [Description("Takes elements in a sequence that is massive")]
        [Priority(1)]
        [TestMethod]
        public void TakeWhileIndexOverflow()
        {
            ExceptionAssert.Throws<OverflowException>(
                () => Enumerable.Repeat(0, int.MaxValue).Concat(Enumerable.Repeat(0, 2)).TakeWhile((value, index) => true).LongCount()); //// TODO singleton
        }
    }
}
