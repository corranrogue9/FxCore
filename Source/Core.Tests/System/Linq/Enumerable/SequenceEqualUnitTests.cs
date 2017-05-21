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
        /// Checks equality of two equal sequences
        /// </summary>
        [TestCategory("Unit")]
        [Description("Checks equality of two equal sequences")]
        [Priority(1)]
        [TestMethod]
        public void SequenceEqual()
        {
            Assert.IsTrue(new[] { 1, 2, 3 }.SequenceEqual(new[] { 1, 2, 3 }));
        }

        /// <summary>
        /// Checks equality of two empty sequences
        /// </summary>
        [TestCategory("Unit")]
        [Description("Checks equality of two empty sequences")]
        [Priority(1)]
        [TestMethod]
        public void SequenceEqualEmpty()
        {
            Assert.IsTrue(Enumerable.Empty<int>().SequenceEqual(Enumerable.Empty<int>()));
        }

        /// <summary>
        /// Checks equality of two sequences when the first contains more elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Checks equality of two sequences when the first contains more elements")]
        [Priority(1)]
        [TestMethod]
        public void SequenceEqualFirstLarger()
        {
            Assert.IsFalse(new[] { 1, 2, 3, 4 }.SequenceEqual(new[] { 1, 2, 3 }));
        }

        /// <summary>
        /// Checks equality of two sequences when the second contains more elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Checks equality of two sequences when the second contains more elements")]
        [Priority(1)]
        [TestMethod]
        public void SequenceEqualSecondLarger()
        {
            Assert.IsFalse(new[] { 1, 2, 3 }.SequenceEqual(new[] { 1, 2, 3, 4 }));
        }

        /// <summary>
        /// Checks equality of two sequences when the first is empty
        /// </summary>
        [TestCategory("Unit")]
        [Description("Checks equality of two sequences when the first is empty")]
        [Priority(1)]
        [TestMethod]
        public void SequenceEqualFirstEmpty()
        {
            Assert.IsFalse(Enumerable.Empty<int>().SequenceEqual(new[] { 1, 2, 3 }));
        }

        /// <summary>
        /// Checks equality of two sequences when the second is empty
        /// </summary>
        [TestCategory("Unit")]
        [Description("Checks equality of two sequences when the second is empty")]
        [Priority(1)]
        [TestMethod]
        public void SequenceEqualSecondEmpty()
        {
            Assert.IsFalse(new[] { 1, 2, 3 }.SequenceEqual(Enumerable.Empty<int>()));
        }

        /// <summary>
        /// Checks equality of two sequences with case sensitivity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Checks equality of two sequences with case sensitivity")]
        [Priority(1)]
        [TestMethod]
        public void SequenceEqualCaseSensitive()
        {
            Assert.IsTrue(new[] { "asdf", "fdsa" }.SequenceEqual(new[] { "asdf", "fdsa" }));
            Assert.IsFalse(new[] { "ASDF", "fdsa" }.SequenceEqual(new[] { "asdf", "fdsa" }));
        }
        
        /// <summary>
        /// Checks equality of two equal sequences
        /// </summary>
        [TestCategory("Unit")]
        [Description("Checks equality of two equal sequences")]
        [Priority(1)]
        [TestMethod]
        public void SequenceEqualComparer()
        {
            Assert.IsTrue(new[] { 1, 2, 3 }.SequenceEqual(new[] { 1, 2, 3 }, null));
        }

        /// <summary>
        /// Checks equality of two empty sequences
        /// </summary>
        [TestCategory("Unit")]
        [Description("Checks equality of two empty sequences")]
        [Priority(1)]
        [TestMethod]
        public void SequenceEqualComparerEmpty()
        {
            Assert.IsTrue(Enumerable.Empty<int>().SequenceEqual(Enumerable.Empty<int>(), null));
        }

        /// <summary>
        /// Checks equality of two sequences when the first contains more elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Checks equality of two sequences when the first contains more elements")]
        [Priority(1)]
        [TestMethod]
        public void SequenceEqualComparerFirstLarger()
        {
            Assert.IsFalse(new[] { 1, 2, 3, 4 }.SequenceEqual(new[] { 1, 2, 3 }, null));
        }

        /// <summary>
        /// Checks equality of two sequences when the second contains more elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Checks equality of two sequences when the second contains more elements")]
        [Priority(1)]
        [TestMethod]
        public void SequenceEqualComparerSecondLarger()
        {
            Assert.IsFalse(new[] { 1, 2, 3 }.SequenceEqual(new[] { 1, 2, 3, 4 }, null));
        }

        /// <summary>
        /// Checks equality of two sequences when the first is empty
        /// </summary>
        [TestCategory("Unit")]
        [Description("Checks equality of two sequences when the first is empty")]
        [Priority(1)]
        [TestMethod]
        public void SequenceEqualComparerFirstEmpty()
        {
            Assert.IsFalse(Enumerable.Empty<int>().SequenceEqual(new[] { 1, 2, 3 }, null));
        }

        /// <summary>
        /// Checks equality of two sequences when the second is empty
        /// </summary>
        [TestCategory("Unit")]
        [Description("Checks equality of two sequences when the second is empty")]
        [Priority(1)]
        [TestMethod]
        public void SequenceEqualComparerSecondEmpty()
        {
            Assert.IsFalse(new[] { 1, 2, 3 }.SequenceEqual(Enumerable.Empty<int>(), null));
        }

        /// <summary>
        /// Checks equality of two sequences with case sensitivity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Checks equality of two sequences with case sensitivity")]
        [Priority(1)]
        [TestMethod]
        public void SequenceEqualComparerCaseSensitive()
        {
            Assert.IsTrue(new[] { "asdf", "fdsa" }.SequenceEqual(new[] { "asdf", "fdsa" }, null));
            Assert.IsFalse(new[] { "ASDF", "fdsa" }.SequenceEqual(new[] { "asdf", "fdsa" }, null));
        }

        /// <summary>
        /// Checks equality of two sequences with case insensitivity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Checks equality of two sequences with case insensitivity")]
        [Priority(1)]
        [TestMethod]
        public void SequenceEqualComparerCaseInsensitive()
        {
            Assert.IsTrue(new[] { "asdf", "fdsa" }.SequenceEqual(new[] { "asdf", "fdsa" }, StringComparer.OrdinalIgnoreCase));
            Assert.IsTrue(new[] { "ASDF", "fdsa" }.SequenceEqual(new[] { "asdf", "fdsa" }, StringComparer.OrdinalIgnoreCase));
        }
    }
}
