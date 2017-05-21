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
        /// Gets the elements of the specified base type
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the elements of the specified base type")]
        [Priority(1)]
        [TestMethod]
        public void OfTypeBase()
        {
            Assert.AreEqual(4, new[] { new Base(), new Derived(), new Derived(), new Base() }.OfType<Base>().Count());
        }

        /// <summary>
        /// Gets the elements of the specified derived type
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the elements of the specified derived type")]
        [Priority(1)]
        [TestMethod]
        public void OfTypeDerived()
        {
            Assert.AreEqual(2, new[] { new Base(), new Derived(), new Derived(), new Base() }.OfType<Derived>().Count());
        }

        /// <summary>
        /// Gets the elements of the specified type when none are in the sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the elements of the specified type when none are in the sequence")]
        [Priority(1)]
        [TestMethod]
        public void OfTypeNone()
        {
            Assert.AreEqual(0, new[] { new Base(), new Derived(), new Derived(), new Base() }.OfType<string>().Count());
        }

        /// <summary>
        /// Gets the elements of the specified type when there are null elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the elements of the specified type when there are null elements")]
        [Priority(1)]
        [TestMethod]
        public void OfTypeNull()
        {
            Assert.AreEqual(4, new[] { new Base(), new Derived(), null, new Derived(), new Base() }.OfType<Base>().Count());
        }

        /// <summary>
        /// Gets the elements of the specified type when there are null elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the elements of the specified type when there are null elements")]
        [Priority(1)]
        [TestMethod]
        public void OfTypeNullObject()
        {
            Assert.AreEqual(4, new[] { new Base(), new Derived(), null, new Derived(), new Base() }.OfType<object>().Count());
        }
    }
}
