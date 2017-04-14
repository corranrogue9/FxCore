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
        /// Determines if there are any elements in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if there are any elements in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void AnyEmpty()
        {
            Assert.AreEqual(false, Enumerable.Empty<string>().Any());
        }

        /// <summary>
        /// Determines if there are any elements in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if there are any elements in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void AnyPredicateEmpty()
        {
            Assert.AreEqual(false, Enumerable.Empty<string>().Any(val => true));
        }

        /// <summary>
        /// Determines if there are any elements in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if there are any elements in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void AnySingle()
        {
            Assert.AreEqual(true, new[] { 1 }.Any());
        }

        /// <summary>
        /// Determines if there are any elements in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if there are any elements in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void AnySingleFalsePredicate()
        {
            Assert.AreEqual(false, new[] { 1 }.Any(val => false));
        }

        /// <summary>
        /// Determines if there are any elements in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if there are any elements in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void AnySingleTruePredicate()
        {
            Assert.AreEqual(true, new[] { 1 }.Any(val => true)); 
        }

        /// <summary>
        /// Determines if there are any elements in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if there are any elements in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void Any()
        {
            Assert.AreEqual(true, new[] { 1, 2, 3, 4, 5, 6 }.Any());
        }

        /// <summary>
        /// Determines if there are any elements in a sequence that match a condition
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if there are any elements in a sequence that match a condition")]
        [Priority(1)]
        [TestMethod]
        public void AnyPredicateTrue()
        {
            Assert.AreEqual(true, new[] { 1, 2, 3, 4, 5, 6 }.Any(val => val > 4));
        }

        /// <summary>
        /// Determines if there are any elements in a sequence that match a condition
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if there are any elements in a sequence that match a condition")]
        [Priority(1)]
        [TestMethod]
        public void AnyPredicateFalse()
        {
            Assert.AreEqual(false, new[] { 1, 2, 3, 4, 5, 6 }.Any(val => val < 0));
        }
    }
}
