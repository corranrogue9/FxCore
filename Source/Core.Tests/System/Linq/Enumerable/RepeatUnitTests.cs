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
        /// Repeats a value
        /// </summary>
        [TestCategory("Unit")]
        [Description("Repeats a value")]
        [Priority(1)]
        [TestMethod]
        public void Repeat()
        {
            CollectionAssert.AreEqual(new[] { 10, 10, 10, 10, 10 }, Enumerable.Repeat(10, 5).ToList());
        }

        /// <summary>
        /// Repeats a value no times
        /// </summary>
        [TestCategory("Unit")]
        [Description("Repeats a value no times")]
        [Priority(1)]
        [TestMethod]
        public void RepeatEmpty()
        {
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), Enumerable.Repeat(10, 0).ToList());
        }

        /// <summary>
        /// Repeats a value a single time
        /// </summary>
        [TestCategory("Unit")]
        [Description("Repeats a value a single time")]
        [Priority(1)]
        [TestMethod]
        public void RepeatSingle()
        {
            CollectionAssert.AreEqual(new[] { 10 }, Enumerable.Repeat(10, 1).ToList());
        }
    }
}
