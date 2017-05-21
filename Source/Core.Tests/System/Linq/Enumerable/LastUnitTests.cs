namespace System.Linq
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class EnumerableUnitTests
    {
        /// <summary>
        /// Gets the last element of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the last element of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void Last()
        {
            Assert.AreEqual(3, new[] { 1, 2, 3 }.Select(value => value).Last());
        }

        /// <summary>
        /// Gets the last element of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the last element of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void LastList()
        {
            Assert.AreEqual(10, new OtherList().Last());
        }

        /// <summary>
        /// Gets the last element of a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the last element of a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void LastSingle()
        {
            Assert.AreEqual(1, new[] { 1 }.Last());
        }

        /// <summary>
        /// Gets the last element of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the last element of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void LastPredicate()
        {
            Assert.AreEqual(2, new[] { 1, 2, 3 }.Last(val => val <= 2));
        }

        /// <summary>
        /// Gets the last element of a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the last element of a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void LastPredicateSingle()
        {
            Assert.AreEqual(1, new[] { 1 }.Last(val => val <= 2));
        }

        /// <summary>
        /// Gets the last element of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the last element of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void LastOrDefault()
        {
            Assert.AreEqual(3, new[] { 1, 2, 3 }.Select(value => value).LastOrDefault());
        }

        /// <summary>
        /// Gets the last element of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the last element of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void LastOrDefaultList()
        {
            Assert.AreEqual(10, new OtherList().LastOrDefault());
        }

        /// <summary>
        /// Gets the last element of a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the last element of a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void LastOrDefaultSingle()
        {
            Assert.AreEqual(1, new[] { 1 }.Select(value => value).LastOrDefault());
        }

        /// <summary>
        /// Gets the last element of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the last element of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void LastOrDefaultPredicate()
        {
            Assert.AreEqual(2, new[] { 1, 2, 3 }.LastOrDefault(val => val <= 2));
        }

        /// <summary>
        /// Gets the last element of a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the last element of a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void LastOrDefaultPredicateSingle()
        {
            Assert.AreEqual(1, new[] { 1 }.LastOrDefault(val => val <= 2));
        }
    }
}
