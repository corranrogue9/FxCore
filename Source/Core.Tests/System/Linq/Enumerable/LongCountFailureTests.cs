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
        public void LongCountNullData()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.LongCount());
        }

        /// <summary>
        /// Counts the number of elements in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Counts the number of elements in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongCountPredicateNullData()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.LongCount(value => true));
        }

        /// <summary>
        /// Counts the number of elements in a sequence with a null predicate
        /// </summary>
        [TestCategory("Failure")]
        [Description("Counts the number of elements in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongCountPredicateNullPredicate()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<string>().LongCount(null));
        }

        /// <summary>
        /// Counts the number of elements in an extremely large sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Counts the number of elements in an extremely large sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongCountMassive()
        {
            //// TODO singletons
            var big = Enumerable.Repeat(Enumerable.Repeat(0, int.MaxValue), int.MaxValue).SelectMany(val => val);
            //// TODO this takes too long to run...
            //// ExceptionAssert.Throws<OverflowException>(() => big.Concat(big).Concat(big).LongCount());
        }

        /// <summary>
        /// Counts the number of elements in an extremely large sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Counts the number of elements in an extremely large sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongCountPredicateMassive()
        {
            //// TODO singletons
            var big = Enumerable.Repeat(Enumerable.Repeat(0, int.MaxValue), int.MaxValue).SelectMany(val => val);
            //// TODO this takes too long to run...
            //// ExceptionAssert.Throws<OverflowException>(() => big.Concat(big).Concat(big).LongCount(value => true));
        }
    }
}
