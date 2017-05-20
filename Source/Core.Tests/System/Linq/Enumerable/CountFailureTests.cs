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
        /// Counts the number of elements in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Counts the number of elements in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void CountNullData()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Count());
        }

        /// <summary>
        /// Counts the number of elements in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Counts the number of elements in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void CountPredicateNullData()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Count(value => true)); //// TODO singleton
        }

        /// <summary>
        /// Counts the number of elements in a sequence with a null predicate
        /// </summary>
        [TestCategory("Failure")]
        [Description("Counts the number of elements in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void CountPredicateNullPredicate()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<string>().Count(null));
        }

        /// <summary>
        /// Counts the number of elements in an extremely large sequence
        /// </summary>
        [TestCategory("Failure"), TestCategory("LongRunning")]
        [Description("Counts the number of elements in an extremely large sequence")]
        [Priority(1)]
        [TestMethod]
        public void CountMassive()
        {
            ExceptionAssert.Throws<OverflowException>(() => Enumerable.Repeat(0, int.MaxValue).Concat(Enumerable.Repeat(0, int.MaxValue)).Count());
        }

        /// <summary>
        /// Counts the number of elements in an extremely large sequence
        /// </summary>
        [TestCategory("Failure"), TestCategory("LongRunning")]
        [Description("Counts the number of elements in an extremely large sequence")]
        [Priority(1)]
        [TestMethod]
        public void CountPredicateMassive()
        {
            //// TODO singleton
            ExceptionAssert.Throws<OverflowException>(() => Enumerable.Repeat(0, int.MaxValue).Concat(Enumerable.Repeat(0, int.MaxValue)).Count(value => true));
        }
    }
}
