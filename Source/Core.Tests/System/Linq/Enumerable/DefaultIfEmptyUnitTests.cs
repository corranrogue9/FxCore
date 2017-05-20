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
        /// Gets a default with an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets a default with an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void DefaultIfEmptyEmpty()
        {
            var data = Enumerable.Empty<string>().DefaultIfEmpty();
            CollectionAssert.AreEqual(new string[] { null }, data.ToList());
        }

        /// <summary>
        /// Gets a default with a non-empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets a default with a non-empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void DefaultIfEmpty()
        {
            var data = new[] { 1, 2, 3 }.DefaultIfEmpty();
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, data.ToList());
        }

        /// <summary>
        /// Gets a default with an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets a default with an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void DefaultIfEmptyDefaultEmpty()
        {
            var data = Enumerable.Empty<string>().DefaultIfEmpty(string.Empty);
            CollectionAssert.AreEqual(new[] { string.Empty }, data.ToList());
        }

        /// <summary>
        /// Gets a default with a non-empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets a default with a non-empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void DefaultIfEmptyDefault()
        {
            var data = new[] { 1, 2, 3 }.DefaultIfEmpty(10);
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, data.ToList());
        }
    }
}
