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
        /// Converts a sequence to an array
        /// </summary>
        [TestCategory("Unit")]
        [Description("Converts a sequence to an array")]
        [Priority(1)]
        [TestMethod]
        public void ToArray()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, Enumerable.Range(1, 4).ToArray());
        }

        /// <summary>
        /// Converts an empty sequence to an array
        /// </summary>
        [TestCategory("Unit")]
        [Description("Converts an empty sequence to an array")]
        [Priority(1)]
        [TestMethod]
        public void ToArrayEmpty()
        {
            CollectionAssert.AreEqual(new int[0], Enumerable.Empty<int>().ToArray());
        }

        /// <summary>
        /// Converts a sequence to an array
        /// </summary>
        [TestCategory("Unit")]
        [Description("Converts a sequence to an array")]
        [Priority(1)]
        [TestMethod]
        public void ToArrayDifferentInstances()
        {
            var original = new[] { 1, 2, 3, 4 };
            var result = original.ToArray();
            CollectionAssert.AreEqual(original, result);
            Assert.IsFalse(original == result);
        }
    }
}
