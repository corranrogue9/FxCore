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
        /// Gets the single of a sequence with no elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the single of a sequence with no elements")]
        [Priority(1)]
        [TestMethod]
        public void SingleNoElements()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<int>().Single());
        }

        /// <summary>
        /// Gets the single of a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the single of a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void SingleOneElement()
        {
            Assert.AreEqual(1, new[] { 1 }.Single());
        }
        
        /// <summary>
        /// Gets the single of a sequence with two elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the single of a sequence with two elements")]
        [Priority(1)]
        [TestMethod]
        public void SingleTwoElements()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => new[] { 1, 2 }.Single());
        }

        /// <summary>
        /// Gets the single of a sequence with no elements that match a predicate
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the single of a sequence with no elements that match a predicate")]
        [Priority(1)]
        [TestMethod]
        public void SinglePredicateNoElements()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => new[] { 1, 3, 5 }.Single(val => val % 2 == 0));
        }

        /// <summary>
        /// Gets the single of a sequence with one element that matches a predicate
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the single of a sequence with one element that matches a predicate")]
        [Priority(1)]
        [TestMethod]
        public void SinglePredicateOneElement()
        {
            Assert.AreEqual(4, new[] { 1, 3, 4, 5 }.Single(val => val % 2 == 0));
        }

        /// <summary>
        /// Gets the single of a sequence with two elements that match a predicate
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the single of a sequence with two elements that match a predicate")]
        [Priority(1)]
        [TestMethod]
        public void SinglePredicateTwoElements()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => new[] { 1, 2, 3, 4, 5 }.Single(val => val % 2 == 0));
        }

        /// <summary>
        /// Gets the single of a sequence with no elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the single of a sequence with no elements")]
        [Priority(1)]
        [TestMethod]
        public void SingleOrDefaultNoElements()
        {
            Assert.AreEqual(0, Enumerable.Empty<int>().SingleOrDefault());
        }

        /// <summary>
        /// Gets the single of a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the single of a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void SingleOrDefaultOneElement()
        {
            Assert.AreEqual(1, new[] { 1 }.SingleOrDefault());
        }

        /// <summary>
        /// Gets the single of a sequence with two elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the single of a sequence with two elements")]
        [Priority(1)]
        [TestMethod]
        public void SingleOrDefaultTwoElements()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => new[] { 1, 2 }.SingleOrDefault());
        }

        /// <summary>
        /// Gets the single of a sequence with no elements that match a predicate
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the single of a sequence with no elements that match a predicate")]
        [Priority(1)]
        [TestMethod]
        public void SingleOrDefaultPredicateNoElements()
        {
            Assert.AreEqual(0, new[] { 1, 3, 5 }.SingleOrDefault(val => val % 2 == 0));
        }

        /// <summary>
        /// Gets the single of a sequence with one element that matches a predicate
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the single of a sequence with one element that matches a predicate")]
        [Priority(1)]
        [TestMethod]
        public void SingleOrDefaultPredicateOneElement()
        {
            Assert.AreEqual(4, new[] { 1, 3, 4, 5 }.SingleOrDefault(val => val % 2 == 0));
        }

        /// <summary>
        /// Gets the single of a sequence with two elements that match a predicate
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the single of a sequence with two elements that match a predicate")]
        [Priority(1)]
        [TestMethod]
        public void SingleOrDefaultPredicateTwoElements()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => new[] { 1, 2, 3, 4, 5 }.SingleOrDefault(val => val % 2 == 0));
        }
    }
}
