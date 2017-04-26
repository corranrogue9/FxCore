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
        /// Gets an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void Empty()
        {
            foreach (var element in Enumerable.Empty<int>())
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// Ensures two empty sequences are the same
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures two empty sequences are the same")]
        [Priority(1)]
        [TestMethod]
        public void EmptyEquality()
        {
            var first = Enumerable.Empty<int>();
            var second = Enumerable.Empty<int>();
            Assert.IsTrue(first == second);
        }

        /// <summary>
        /// Gets an empty sequence as an array
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets an empty sequence as an array")]
        [Priority(1)]
        [TestMethod]
        public void EmptyArray()
        {
            var empty = Enumerable.Empty<int>() as int[];
            Assert.IsNotNull(empty);
            Assert.AreEqual(0, empty.Length);
        }
    }
}
