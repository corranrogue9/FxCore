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
        /// Skips elements in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Skips elements in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void Skip()
        {
            CollectionAssert.AreEqual(new[] { 4, 5, 6, 7 }, new[] { 1, 2, 3, 4, 5, 6, 7 }.Skip(3).ToList());
        }

        /// <summary>
        /// Skips no elements in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Skips no elements in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void SkipNone()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7 }, new[] { 1, 2, 3, 4, 5, 6, 7 }.Skip(0).ToList());
        }

        /// <summary>
        /// Skips all elements in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Skips all elements in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void SkipAll()
        {
            CollectionAssert.AreEqual(new[] { 7 }, new[] { 1, 2, 3, 4, 5, 6, 7 }.Skip(6).ToList());
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), new[] { 1, 2, 3, 4, 5, 6, 7 }.Skip(7).ToList());
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), new[] { 1, 2, 3, 4, 5, 6, 7 }.Skip(8).ToList());
        }

        /// <summary>
        /// Skips a negative number of elements in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Skips a negative number of elements in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void SkipNegative()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7 }, new[] { 1, 2, 3, 4, 5, 6, 7 }.Skip(-1).ToList());
        }

        /// <summary>
        /// Skips elements in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Skips elements in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void SkipWhile()
        {
            CollectionAssert.AreEqual(new[] { 4, 5, 6, 7 }, new[] { 1, 2, 3, 4, 5, 6, 7 }.SkipWhile(value => 6 % value == 0).ToList());
        }

        /// <summary>
        /// Skips no elements in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Skips no elements in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void SkipWhileNone()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7 }, new[] { 1, 2, 3, 4, 5, 6, 7 }.SkipWhile(value => value < 0).ToList());
        }

        /// <summary>
        /// Skips all elements in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Skips all elements in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void SkipWhileAll()
        {
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), new[] { 1, 2, 3, 4, 5, 6, 7 }.SkipWhile(value => value > 0).ToList());
        }

        /// <summary>
        /// Skips elements in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Skips elements in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void SkipWhileIndex()
        {
            CollectionAssert.AreEqual(new[] { 5, 6, 7 }, new[] { 1, 2, 3, 4, 5, 6, 7 }.SkipWhile((value, index) => 6 % value == 0 || index % 2 == 1).ToList());
        }

        /// <summary>
        /// Skips no elements in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Skips no elements in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void SkipWhileIndexNone()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7 }, new[] { 1, 2, 3, 4, 5, 6, 7 }.SkipWhile((value, index) => index < 0 && value > 0).ToList());
        }

        /// <summary>
        /// Skips all elements in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Skips all elements in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void SkipWhileIndexAll()
        {
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), new[] { 1, 2, 3, 4, 5, 6, 7 }.SkipWhile((value, index) => index < 3 || value > 3).ToList());
        }

        /// <summary>
        /// Skips elements in a massive sequence
        /// </summary>
        [TestCategory("Unit"), TestCategory("LongRunning")]
        [Description("Skips elements in a massive sequence")]
        [Priority(1)]
        [TestMethod]
        public void SkipWhileOverflow()
        {
            Enumerable.Repeat(0, int.MaxValue).Concat(Enumerable.Repeat(0, 2)).SkipWhile(value => true).LongCount();
        }
    }
}
