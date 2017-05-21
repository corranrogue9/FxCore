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
        /// Gets the last element of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the last element of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void LastNull()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Last());
        }

        /// <summary>
        /// Gets the last element of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the last element of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void LastEmpty()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<int>().Last());
        }

        /// <summary>
        /// Gets the last element of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the last element of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void LastPredicateNull()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Last(val => val <= 2));
        }

        /// <summary>
        /// Gets the last element of a sequence with a null predicate
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the last element of a sequence with a null predicate")]
        [Priority(1)]
        [TestMethod]
        public void LastPredicateNullPredicate()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3 }.Last(null));
        }

        /// <summary>
        /// Gets the last element of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the last element of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void LastPredicateEmpty()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<int>().Last(val => val <= 2));
        }

        /// <summary>
        /// Gets the last element of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the last element of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void LastPredicateNoMatches()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => new[] { 1, 2, 3 }.Last(val => val < 0));
        }

        /// <summary>
        /// Gets the last element of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the last element of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void LastOrDefaultNull()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.LastOrDefault());
        }

        /// <summary>
        /// Gets the last element of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the last element of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void LastOrDefaultEmpty()
        {
            Assert.AreEqual(0, Enumerable.Empty<int>().LastOrDefault());
        }

        /// <summary>
        /// Gets the last element of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the last element of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void LastOrDefaultPredicateNull()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.LastOrDefault(val => val <= 2));
        }

        /// <summary>
        /// Gets the last element of a sequence with a null predicate
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the last element of a sequence with a null predicate")]
        [Priority(1)]
        [TestMethod]
        public void LastOrDefaultPredicateNullPredicate()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3 }.LastOrDefault(null));
        }

        /// <summary>
        /// Gets the last element of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the last element of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void LastOrDefaultPredicateEmpty()
        {
            Assert.AreEqual(0, Enumerable.Empty<int>().LastOrDefault(val => val <= 2));
        }

        /// <summary>
        /// Gets the last element of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the last element of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void LastOrDefaultPredicateNoMatches()
        {
            Assert.AreEqual(0, new[] { 1, 2, 3 }.LastOrDefault(val => val < 0));
        }
    }
}
