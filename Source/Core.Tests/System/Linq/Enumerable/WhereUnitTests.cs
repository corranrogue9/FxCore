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
        /// Gets the elements in a sequence that meet a condition
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the elements in a sequence that meet a condition")]
        [Priority(1)]
        [TestMethod]
        public void Where()
        {
            CollectionAssert.AreEqual(new[] { 2, 8, 10 }, new[] { 2, 5, 7, 8, 10 }.Where(value => value % 2 == 0).ToList());
        }

        /// <summary>
        /// Gets the elements in a sequence that meet a condition
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the elements in a sequence that meet a condition")]
        [Priority(1)]
        [TestMethod]
        public void WhereNone()
        {
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), new[] { 2, 5, 7, 8, 10 }.Where(value => value > 10).ToList());
        }

        /// <summary>
        /// Gets the elements in a sequence that meet a condition
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the elements in a sequence that meet a condition")]
        [Priority(1)]
        [TestMethod]
        public void WhereAll()
        {
            CollectionAssert.AreEqual(new[] { 2, 5, 7, 8, 10 }, new[] { 2, 5, 7, 8, 10 }.Where(value => value > 0).ToList());
        }

        /// <summary>
        /// Gets the elements in an empty sequence that meet a condition
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the elements in an empty sequence that meet a condition")]
        [Priority(1)]
        [TestMethod]
        public void WhereEmpty()
        {
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), Enumerable.Empty<int>().Where(value => value > 0).ToList());
        }

        /// <summary>
        /// Gets the elements in a massive sequence that meet a condition
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the elements in a sequence that meet a null condition")]
        [Priority(1)]
        [TestMethod]
        public void WhereOverflow()
        {
            //// TODO singleton
            Enumerable.Repeat(0, int.MaxValue).Concat(Enumerable.Repeat(0, 2)).Where(value => true).LongCount();
        }

        /// <summary>
        /// Gets the elements in a sequence that meet a condition
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the elements in a sequence that meet a condition")]
        [Priority(1)]
        [TestMethod]
        public void WhereIndex()
        {
            CollectionAssert.AreEqual(new[] { 2, 8, 10 }, new[] { 2, 5, 7, 8, 10 }.Where((value, index) => value % 2 == 0).ToList());
        }

        /// <summary>
        /// Gets the elements in a sequence that meet a condition
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the elements in a sequence that meet a condition")]
        [Priority(1)]
        [TestMethod]
        public void WhereIndexNone()
        {
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), new[] { 2, 5, 7, 8, 10 }.Where((value, index) => value > 10).ToList());
        }

        /// <summary>
        /// Gets the elements in a sequence that meet a condition
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the elements in a sequence that meet a condition")]
        [Priority(1)]
        [TestMethod]
        public void WhereIndexAll()
        {
            CollectionAssert.AreEqual(new[] { 2, 5, 7, 8, 10 }, new[] { 2, 5, 7, 8, 10 }.Where((value, index) => value > 0).ToList());
        }

        /// <summary>
        /// Gets the elements in an empty sequence that meet a condition
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the elements in an empty sequence that meet a condition")]
        [Priority(1)]
        [TestMethod]
        public void WhereIndexEmpty()
        {
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), Enumerable.Empty<int>().Where((value, index) => value > 0).ToList());
        }
    }
}
