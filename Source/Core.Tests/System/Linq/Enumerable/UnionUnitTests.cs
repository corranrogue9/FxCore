namespace System.Linq
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class EnumerableUnitTests
    {
        /// <summary>
        /// Unions a sequence with another sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Unions a sequence with another sequence")]
        [Priority(1)]
        [TestMethod]
        public void Union()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, -1 }, new[] { 1, 2, 3, 4, 5 }.Union(new[] { 2, 5, 6, -1 }).ToList());
        }

        /// <summary>
        /// Unions an empty sequence with another sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Unions an empty sequence with another sequence")]
        [Priority(1)]
        [TestMethod]
        public void UnionFirstEmpty()
        {
            CollectionAssert.AreEqual(new[] { 2, 5, 6, -1 }, Enumerable.Empty<int>().Union(new[] { 2, 5, 6, -1 }).ToList());
        }

        /// <summary>
        /// Unions a sequence with an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Unions a sequence with an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void UnionSecondEmpty()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4, 5 }.Union(Enumerable.Empty<int>()).ToList());
        }

        /// <summary>
        /// Unions two empty sequences
        /// </summary>
        [TestCategory("Unit")]
        [Description("Unions two empty sequences")]
        [Priority(1)]
        [TestMethod]
        public void UnionEmpty()
        {
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), Enumerable.Empty<int>().Union(Enumerable.Empty<int>()).ToList());
        }
        
        /// <summary>
        /// Unions a sequence with another sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Unions a sequence with another sequence")]
        [Priority(1)]
        [TestMethod]
        public void UnionComparer()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, -1 }, new[] { 1, 2, 3, 4, 5 }.Union(new[] { 2, 5, 6, -1 }, EqualityComparer<int>.Default).ToList());
        }

        /// <summary>
        /// Unions an empty sequence with another sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Unions an empty sequence with another sequence")]
        [Priority(1)]
        [TestMethod]
        public void UnionComparerFirstEmpty()
        {
            CollectionAssert.AreEqual(new[] { 2, 5, 6, -1 }, Enumerable.Empty<int>().Union(new[] { 2, 5, 6, -1 }, EqualityComparer<int>.Default).ToList());
        }

        /// <summary>
        /// Unions a sequence with an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Unions a sequence with an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void UnionComparerSecondEmpty()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4, 5 }.Union(Enumerable.Empty<int>(), EqualityComparer<int>.Default).ToList());
        }

        /// <summary>
        /// Unions two empty sequences
        /// </summary>
        [TestCategory("Unit")]
        [Description("Unions two empty sequences")]
        [Priority(1)]
        [TestMethod]
        public void UnionComparerEmpty()
        {
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), Enumerable.Empty<int>().Union(Enumerable.Empty<int>(), EqualityComparer<int>.Default).ToList());
        }

        /// <summary>
        /// Unions a sequence with another sequence using a null comparer
        /// </summary>
        [TestCategory("Unit")]
        [Description("Unions a sequence with another sequence using a null comparer")]
        [Priority(1)]
        [TestMethod]
        public void UnionComparerNullComparer()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, -1 }, new[] { 1, 2, 3, 4, 5 }.Union(new[] { 2, 5, 6, -1 }, null).ToList());
        }

        /// <summary>
        /// Unions a sequence with another sequence where case-sensitivity does not matter
        /// </summary>
        [TestCategory("Unit")]
        [Description("Unions a sequence with another sequence where case-sensitivity does not matter")]
        [Priority(1)]
        [TestMethod]
        public void UnionComparerDuplicateStrings()
        {
            CollectionAssert.AreEqual(
                new[] { "asdf", "fdsa", "QWER", "zxcv" },
                new[] { "asdf", "fdsa", "QWER" }.Union(new[] { "zxcv", "qwer" }, StringComparer.OrdinalIgnoreCase).ToList());
        }
    }
}
