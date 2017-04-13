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
        /// Ensures that all elements of an empty sequence meet a condition
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that all elements of an empty sequence meet a condition")]
        [Priority(1)]
        [TestMethod]
        public void AllEmpty()
        {
            Assert.AreEqual(true, Enumerable.Empty<string>().All(val => false)); 
        }

        /// <summary>
        /// Ensures that if all elements match a condition, true is returned
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if all elements match a condition, true is returned")]
        [Priority(1)]
        [TestMethod]
        public void AllTrue()
        {
            Assert.AreEqual(true, new[] { 1, 2, 3, 4, 5 }.All(val => val > 0));
        }

        /// <summary>
        /// Ensures that if only some elements match a condition, false is returned
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if only some elements match a condition, false is returned")]
        [Priority(1)]
        [TestMethod]
        public void AllFalse()
        {
            Assert.AreEqual(false, new[] { 1, 2, 3, 4, 5 }.All(val => val < 4));
        }
    }
}
