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
        /// Gets the first element of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the first element of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void FirstNullData()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.First());
        }

        /// <summary>
        /// Gets the first element of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the first element of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void FirstEmptyData()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<string>().First());
        }

        /// <summary>
        /// Gets the first element of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the first element of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void FirstPredicateNullData()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.First(val => true)); //// TODO singelton
        }

        /// <summary>
        /// Gets the first element of a sequence with a null predicate
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the first element of a sequence with a null predicate")]
        [Priority(1)]
        [TestMethod]
        public void FirstPredicateNullPredicate()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3, 4 }.First(null));
        }

        /// <summary>
        /// Gets the first element of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the first element of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void FirstPredicateEmptyData()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => new[] { 1, 2, 3 }.First(val => val < 0));
        }

        /// <summary>
        /// Gets the first element of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the first element of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void FirstOrDefaultNullData()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.FirstOrDefault());
        }

        /// <summary>
        /// Gets the first element of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the first element of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void FirstOrDefaultPredicateNullData()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.FirstOrDefault(val => true)); //// TODO singelton
        }

        /// <summary>
        /// Gets the first element of a sequence with a null predicate
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the first element of a sequence with a null predicate")]
        [Priority(1)]
        [TestMethod]
        public void FirstOrDefaultPredicateNullPredicate()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3, 4 }.FirstOrDefault(null));
        }

        /// <summary>
        /// Gets the first element of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the first element of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void FirstOrDefaultPredicateEmptyData()
        {
            Assert.AreEqual(0, new[] { 1, 2, 3 }.FirstOrDefault(val => val < 0));
        }
    }
}
