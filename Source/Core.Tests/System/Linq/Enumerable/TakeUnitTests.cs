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
        /// Takes elements in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Takes elements in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void Take()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, new[] { 1, 2, 3, 4, 5, 6, 7 }.Take(3).ToList());
        }

        /// <summary>
        /// Takes no elements in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Takes no elements in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void TakeNone()
        {
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), new[] { 1, 2, 3, 4, 5, 6, 7 }.Take(0).ToList());
        }

        /// <summary>
        /// Takes all elements in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Takes all elements in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void TakeAll()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 1, 2, 3, 4, 5, 6, 7 }.Take(6).ToList());
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7 }, new[] { 1, 2, 3, 4, 5, 6, 7 }.Take(7).ToList());
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7 }, new[] { 1, 2, 3, 4, 5, 6, 7 }.Take(8).ToList());
        }

        /// <summary>
        /// Takes a negative number of elements in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Takes a negative number of elements in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void TakeNegative()
        {
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), new[] { 1, 2, 3, 4, 5, 6, 7 }.Take(-1).ToList());
        }
        
        /// <summary>
        /// Takes elements in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Takes elements in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void TakeWhile()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, new[] { 1, 2, 3, 4, 5, 6, 7 }.TakeWhile(value => 6 % value == 0).ToList());
        }

        /// <summary>
        /// Takes no elements in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Takes no elements in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void TakeWhileNone()
        {
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), new[] { 1, 2, 3, 4, 5, 6, 7 }.TakeWhile(value => value < 0).ToList());
        }

        /// <summary>
        /// Takes all elements in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Takes all elements in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void TakeWhileAll()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 1, 2, 3, 4, 5, 6, 7 }.TakeWhile(value => value < 7).ToList());
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7 }, new[] { 1, 2, 3, 4, 5, 6, 7 }.TakeWhile(value => value < 8).ToList());
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7 }, new[] { 1, 2, 3, 4, 5, 6, 7 }.TakeWhile(value => value < 9).ToList());
        }
        
        /// <summary>
        /// Takes elements in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Takes elements in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void TakeWhileIndex()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3, 4, 5, 6, 7 }.TakeWhile((value, index) => 6 % value == 0 || index < 4).ToList());
        }

        /// <summary>
        /// Takes no elements in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Takes no elements in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void TakeWhileIndexNone()
        {
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), new[] { 1, 2, 3, 4, 5, 6, 7 }.TakeWhile((value, index) => value == index).ToList());
        }

        /// <summary>
        /// Takes all elements in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Takes all elements in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void TakeWhileIndexAll()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 1, 2, 3, 4, 5, 6, 7 }.TakeWhile((value, index) => value < 6 || index == 5).ToList());
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7 }, new[] { 1, 2, 3, 4, 5, 6, 7 }.TakeWhile((value, index) => value < 7 || index == 6).ToList());
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7 }, new[] { 1, 2, 3, 4, 5, 6, 7 }.TakeWhile((value, index) => value < 8 || index == 7).ToList());
        }
    }
}
