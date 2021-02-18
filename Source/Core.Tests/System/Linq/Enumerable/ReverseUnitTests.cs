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
        /// Reverses a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Reverses a sequence")]
        [Priority(1)]
        [TestMethod]
        public void Reverse()
        {
            //// TODO fix that this calls the new methods in .net 4.6
            CollectionAssert.AreEqual(new[] { 5, 4, 3, 2, 1 }, new[] { 1, 2, 3, 4, 5 }.Reverse().ToList());
        }

        /// <summary>
        /// Reverses a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Reverses a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void ReverseSinge()
        {
            CollectionAssert.AreEqual(new[] { 5 }, new[] { 5 }.Reverse().ToList());
        }

        /// <summary>
        /// Reverses a sequence that is empty
        /// </summary>
        [TestCategory("Unit")]
        [Description("Reverses a sequence that is empty")]
        [Priority(1)]
        [TestMethod]
        public void ReverseEmpty()
        {
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), Enumerable.Empty<int>().Reverse().ToList());
        }
    }
}
