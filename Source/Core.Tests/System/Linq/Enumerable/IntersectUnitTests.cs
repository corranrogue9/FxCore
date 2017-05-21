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
        /// Gets the intersection of two sequences
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the intersection of two sequences")]
        [Priority(1)]
        [TestMethod]
        public void Intersect()
        {
            CollectionAssert.AreEqual(new[] { 2, 5, 8 }, new[] { 2, 4, 5, 6, 8, 9 }.Intersect(new[] { 2, 3, 5, 8, 10 }).ToList());
        }

        /// <summary>
        /// Gets the intersection of two sequences where duplicate values are present
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the intersection of two sequences where duplicate values are present")]
        [Priority(1)]
        [TestMethod]
        public void IntersectDuplicateElements()
        {
            CollectionAssert.AreEqual(new[] { 2, 5, 8 }, new[] { 2, 4, 2, 5, 6, 2, 8, 9, 8 }.Intersect(new[] { 2, 3, 2, 5, 8, 10 }).ToList());
        }

        /// <summary>
        /// Gets the intersection of two sequences where the first sequence is empty
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the intersection of two sequences where the first sequence is empty")]
        [Priority(1)]
        [TestMethod]
        public void IntersectEmptyFirst()
        {
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), Enumerable.Empty<int>().Intersect(new[] { 2, 3, 2, 5, 8, 10 }).ToList());
        }

        /// <summary>
        /// Gets the intersection of two sequences where the second sequence is empty
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the intersection of two sequences where the second sequence is empty")]
        [Priority(1)]
        [TestMethod]
        public void IntersectEmptySecond()
        {
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), new[] { 2, 4, 2, 5, 6, 2, 8, 9, 8 }.Intersect(Enumerable.Empty<int>()).ToList());
        }

        /// <summary>
        /// Gets the intersection of two sequences where both sequences are empty
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the intersection of two sequences where both sequences are empty")]
        [Priority(1)]
        [TestMethod]
        public void IntersectBothEmpty()
        {
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), Enumerable.Empty<int>().Intersect(Enumerable.Empty<int>()).ToList());
        }

        /// <summary>
        /// Gets the intersection of two sequences where sequences contain values that are equal by case insensitivity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the intersection of two sequences where sequences contain values that are equal by case insensitivity")]
        [Priority(1)]
        [TestMethod]
        public void IntersectCaseSensitive()
        {
            CollectionAssert.AreEqual(new[] { "fdsa" }, new[] { "asdf", "fdsa", "qwer" }.Intersect(new[] { "ASDF", "fdsa", "rewq" }).ToList());
        }
        
        /// <summary>
        /// Gets the intersection of two sequences
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the intersection of two sequences")]
        [Priority(1)]
        [TestMethod]
        public void IntersectComparer()
        {
            CollectionAssert.AreEqual(
                new[] { "asdf", "fdsa", "qwer" },
                new[] { "asdf", "rewq", "fdsa", "zxcv", "qwer", "vcxz" }.Intersect(new[] { "asdf", "yuio", "fdsa", "qwer", "oiuy" }, StringComparer.Ordinal).ToList());
        }

        /// <summary>
        /// Gets the intersection of two sequences where duplicate values are present
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the intersection of two sequences where duplicate values are present")]
        [Priority(1)]
        [TestMethod]
        public void IntersectComparerDuplicateElements()
        {
            CollectionAssert.AreEqual(
                new[] { "asdf", "fdsa", "qwer" },
                new[] { "asdf", "rewq", "fdsa", "fdsa", "qwer", "vcxz" }.Intersect(new[] { "asdf", "asdf", "fdsa", "qwer", "oiuy" }, StringComparer.Ordinal).ToList());
        }

        /// <summary>
        /// Gets the intersection of two sequences where the first sequence is empty
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the intersection of two sequences where the first sequence is empty")]
        [Priority(1)]
        [TestMethod]
        public void IntersectComparerEmptyFirst()
        {
            CollectionAssert.AreEqual(
                Enumerable.Empty<string>().ToList(),
                Enumerable.Empty<string>().Intersect(new[] { "asdf", "yuio", "fdsa", "qwer", "oiuy" }, StringComparer.Ordinal).ToList());
        }

        /// <summary>
        /// Gets the intersection of two sequences where the second sequence is empty
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the intersection of two sequences where the second sequence is empty")]
        [Priority(1)]
        [TestMethod]
        public void IntersectComparerEmptySecond()
        {
            CollectionAssert.AreEqual(
                Enumerable.Empty<string>().ToList(),
                new[] { "asdf", "rewq", "fdsa", "zxcv", "qwer", "vcxz" }.Intersect(Enumerable.Empty<string>(), StringComparer.Ordinal).ToList());
        }

        /// <summary>
        /// Gets the intersection of two sequences where both sequences are empty
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the intersection of two sequences where both sequences are empty")]
        [Priority(1)]
        [TestMethod]
        public void IntersectComparerBothEmpty()
        {
            CollectionAssert.AreEqual(
                Enumerable.Empty<string>().ToList(),
                Enumerable.Empty<string>().Intersect(Enumerable.Empty<string>(), StringComparer.Ordinal).ToList());
        }

        /// <summary>
        /// Gets the intersection of two sequences where sequences contain values that are equal by case insensitivity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the intersection of two sequences where sequences contain values that are equal by case insensitivity")]
        [Priority(1)]
        [TestMethod]
        public void IntersectComparerCaseSensitive()
        {
            CollectionAssert.AreEqual(new[] { "fdsa" }, new[] { "asdf", "fdsa", "qwer" }.Intersect(new[] { "ASDF", "fdsa", "rewq" }, StringComparer.Ordinal).ToList());
        }

        /// <summary>
        /// Gets the intersection of two sequences where sequences contain values that are equal by case insensitivity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the intersection of two sequences where sequences contain values that are equal by case insensitivity")]
        [Priority(1)]
        [TestMethod]
        public void IntersectComparerCaseInsensitive()
        {
            CollectionAssert.AreEqual(
                new[] { "asdf", "fdsa" },
                new[] { "asdf", "fdsa", "qwer" }.Intersect(new[] { "ASDF", "fdsa", "rewq" }, StringComparer.OrdinalIgnoreCase).ToList());
        }
        
        /// <summary>
        /// Gets the intersection of two sequences where the comparer is null
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the intersection of two sequences where the comparer is null")]
        [Priority(1)]
        [TestMethod]
        public void IntersectComparerNullComparer()
        {
            CollectionAssert.AreEqual(
                new[] { "asdf", "fdsa", "qwer" },
                new[] { "asdf", "rewq", "fdsa", "zxcv", "qwer", "vcxz" }.Intersect(new[] { "asdf", "yuio", "fdsa", "qwer", "oiuy" }, null).ToList());
        }
    }
}
