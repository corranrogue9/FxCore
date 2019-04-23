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
        /// Gets the single of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the single of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void SingleNullSequence()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Single());
        }

        /// <summary>
        /// Gets the single of a sequence matching a null predicate
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the single of a sequence matching a null predicate")]
        [Priority(1)]
        [TestMethod]
        public void SingleNullPredicate()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3 }.Single(null));
        }

        /// <summary>
        /// Gets the single of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the single of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void SingleOrDefaultNullSequence()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.SingleOrDefault());
        }

        /// <summary>
        /// Gets the single of a sequence matching a null predicate
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the single of a sequence matching a null predicate")]
        [Priority(1)]
        [TestMethod]
        public void SingleOrDefaultNullPredicate()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3 }.SingleOrDefault(null));
        }
    }
}
