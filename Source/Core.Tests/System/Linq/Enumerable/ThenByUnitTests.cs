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
        /// Orders the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void ThenBy()
        {
            CollectionAssert.AreEqual(
                new[] { Tuple.Create(1, 2), Tuple.Create(2, 5), Tuple.Create(3, 9), Tuple.Create(4, 2), Tuple.Create(4, 5) },
                new[] { Tuple.Create(2, 5), Tuple.Create(4, 5), Tuple.Create(1, 2), Tuple.Create(4, 2), Tuple.Create(3, 9) }.OrderBy(value => value.Item1).ThenBy(value => value.Item2).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence and ensure that they are stable
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence and ensure that they are stable")]
        [Priority(1)]
        [TestMethod]
        public void ThenByStable()
        {
            CollectionAssert.AreEqual(
                new[] { Tuple.Create(1, 2, 6), Tuple.Create(2, 5, 2), Tuple.Create(2, 5, 1), Tuple.Create(3, 9, 6), Tuple.Create(4, 2, 6), Tuple.Create(4, 5, 6) },
                new[] { Tuple.Create(2, 5, 2), Tuple.Create(4, 5, 6), Tuple.Create(2, 5, 1), Tuple.Create(1, 2, 6), Tuple.Create(4, 2, 6), Tuple.Create(3, 9, 6) }.OrderBy(value => value.Item1).ThenBy(value => value.Item2).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void ThenByNested()
        {
            CollectionAssert.AreEqual(
                new[] { Tuple.Create(1, 2, 6), Tuple.Create(2, 5, 1), Tuple.Create(2, 5, 2), Tuple.Create(3, 9, 6), Tuple.Create(4, 2, 6), Tuple.Create(4, 5, 6) },
                new[] { Tuple.Create(2, 5, 2), Tuple.Create(4, 5, 6), Tuple.Create(2, 5, 1), Tuple.Create(1, 2, 6), Tuple.Create(4, 2, 6), Tuple.Create(3, 9, 6) }.OrderBy(value => value.Item1).ThenBy(value => value.Item2).ThenBy(value => value.Item3).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void ThenByComparer()
        {
            CollectionAssert.AreEqual(
                new[] { Tuple.Create(1, 2), Tuple.Create(2, 5), Tuple.Create(3, 9), Tuple.Create(4, 2), Tuple.Create(4, 5) },
                new[] { Tuple.Create(2, 5), Tuple.Create(4, 5), Tuple.Create(1, 2), Tuple.Create(4, 2), Tuple.Create(3, 9) }.OrderBy(value => value.Item1).ThenBy(value => value.Item2, Comparer<int>.Default).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence and ensure that they are stable
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence and ensure that they are stable")]
        [Priority(1)]
        [TestMethod]
        public void ThenByComparerStable()
        {
            CollectionAssert.AreEqual(
                new[] { Tuple.Create(1, 2, 6), Tuple.Create(2, 5, 2), Tuple.Create(2, 5, 1), Tuple.Create(3, 9, 6), Tuple.Create(4, 2, 6), Tuple.Create(4, 5, 6) },
                new[] { Tuple.Create(2, 5, 2), Tuple.Create(4, 5, 6), Tuple.Create(2, 5, 1), Tuple.Create(1, 2, 6), Tuple.Create(4, 2, 6), Tuple.Create(3, 9, 6) }.OrderBy(value => value.Item1).ThenBy(value => value.Item2, Comparer<int>.Default).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void ThenByComparerNested()
        {
            CollectionAssert.AreEqual(
                new[] { Tuple.Create(1, 2, 6), Tuple.Create(2, 5, 1), Tuple.Create(2, 5, 2), Tuple.Create(3, 9, 6), Tuple.Create(4, 2, 6), Tuple.Create(4, 5, 6) },
                new[] { Tuple.Create(2, 5, 2), Tuple.Create(4, 5, 6), Tuple.Create(2, 5, 1), Tuple.Create(1, 2, 6), Tuple.Create(4, 2, 6), Tuple.Create(3, 9, 6) }.OrderBy(value => value.Item1).ThenBy(value => value.Item2, Comparer<int>.Default).ThenBy(value => value.Item3, Comparer<int>.Default).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence with a null comparer
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence with a null comparer")]
        [Priority(1)]
        [TestMethod]
        public void ThenByComparerNullComparer()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, new[] { 2, 4, 1, 3 }.OrderBy(value => value).ThenBy(value => value, null).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void ThenByComparerNonDefault()
        {
            CollectionAssert.AreEqual(
                new[] { Tuple.Create("a", "b"), Tuple.Create("b", "e"), Tuple.Create("c", "i"), Tuple.Create("d", "E"), Tuple.Create("d", "b") },
                new[] { Tuple.Create("b", "e"), Tuple.Create("d", "E"), Tuple.Create("a", "b"), Tuple.Create("d", "b"), Tuple.Create("c", "i") }.OrderBy(value => value.Item1).ThenBy(value => value.Item2, StringComparer.Ordinal).ToList());
            CollectionAssert.AreEqual(
                new[] { Tuple.Create("a", "b"), Tuple.Create("b", "e"), Tuple.Create("c", "i"), Tuple.Create("d", "b"), Tuple.Create("d", "E") },
                new[] { Tuple.Create("b", "e"), Tuple.Create("d", "E"), Tuple.Create("a", "b"), Tuple.Create("d", "b"), Tuple.Create("c", "i") }.OrderBy(value => value.Item1).ThenBy(value => value.Item2, StringComparer.OrdinalIgnoreCase).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void ThenByDescending()
        {
            CollectionAssert.AreEqual(
                new[] { Tuple.Create(1, 2), Tuple.Create(2, 5), Tuple.Create(3, 9), Tuple.Create(4, 5), Tuple.Create(4, 2) },
                new[] { Tuple.Create(2, 5), Tuple.Create(4, 5), Tuple.Create(1, 2), Tuple.Create(4, 2), Tuple.Create(3, 9) }.OrderBy(value => value.Item1).ThenByDescending(value => value.Item2).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence and ensure that they are stable
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence and ensure that they are stable")]
        [Priority(1)]
        [TestMethod]
        public void ThenByDescendingStable()
        {
            CollectionAssert.AreEqual(
                new[] { Tuple.Create(1, 2, 6), Tuple.Create(2, 5, 2), Tuple.Create(2, 5, 1), Tuple.Create(3, 9, 6), Tuple.Create(4, 5, 6), Tuple.Create(4, 2, 6) },
                new[] { Tuple.Create(2, 5, 2), Tuple.Create(4, 5, 6), Tuple.Create(2, 5, 1), Tuple.Create(1, 2, 6), Tuple.Create(4, 2, 6), Tuple.Create(3, 9, 6) }.OrderBy(value => value.Item1).ThenByDescending(value => value.Item2).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void ThenByDescendingNested()
        {
            CollectionAssert.AreEqual(
                new[] { Tuple.Create(1, 2, 6), Tuple.Create(2, 5, 2), Tuple.Create(2, 5, 1), Tuple.Create(3, 9, 6), Tuple.Create(4, 5, 6), Tuple.Create(4, 2, 6) },
                new[] { Tuple.Create(2, 5, 2), Tuple.Create(4, 5, 6), Tuple.Create(2, 5, 1), Tuple.Create(1, 2, 6), Tuple.Create(4, 2, 6), Tuple.Create(3, 9, 6) }.OrderBy(value => value.Item1).ThenByDescending(value => value.Item2).ThenByDescending(value => value.Item3).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void ThenByDescendingComparer()
        {
            CollectionAssert.AreEqual(
                new[] { Tuple.Create(1, 2), Tuple.Create(2, 5), Tuple.Create(3, 9), Tuple.Create(4, 5), Tuple.Create(4, 2) },
                new[] { Tuple.Create(2, 5), Tuple.Create(4, 5), Tuple.Create(1, 2), Tuple.Create(4, 2), Tuple.Create(3, 9) }.OrderBy(value => value.Item1).ThenByDescending(value => value.Item2, Comparer<int>.Default).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence and ensure that they are stable
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence and ensure that they are stable")]
        [Priority(1)]
        [TestMethod]
        public void ThenByDescendingComparerStable()
        {
            CollectionAssert.AreEqual(
                new[] { Tuple.Create(1, 2, 6), Tuple.Create(2, 5, 2), Tuple.Create(2, 5, 1), Tuple.Create(3, 9, 6), Tuple.Create(4, 5, 6), Tuple.Create(4, 2, 6) },
                new[] { Tuple.Create(2, 5, 2), Tuple.Create(4, 5, 6), Tuple.Create(2, 5, 1), Tuple.Create(1, 2, 6), Tuple.Create(4, 2, 6), Tuple.Create(3, 9, 6) }.OrderBy(value => value.Item1).ThenByDescending(value => value.Item2, Comparer<int>.Default).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void ThenByDescendingComparerNested()
        {
            CollectionAssert.AreEqual(
                new[] { Tuple.Create(1, 2, 6), Tuple.Create(2, 5, 2), Tuple.Create(2, 5, 1), Tuple.Create(3, 9, 6), Tuple.Create(4, 5, 6), Tuple.Create(4, 2, 6) },
                new[] { Tuple.Create(2, 5, 2), Tuple.Create(4, 5, 6), Tuple.Create(2, 5, 1), Tuple.Create(1, 2, 6), Tuple.Create(4, 2, 6), Tuple.Create(3, 9, 6) }.OrderBy(value => value.Item1).ThenByDescending(value => value.Item2, Comparer<int>.Default).ThenByDescending(value => value.Item3, Comparer<int>.Default).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence with a null comparer
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence with a null comparer")]
        [Priority(1)]
        [TestMethod]
        public void ThenByDescendingComparerNullComparer()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, new[] { 2, 4, 1, 3 }.OrderBy(value => value).ThenByDescending(value => value, null).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void ThenByDescendingComparerNonDefault()
        {
            CollectionAssert.AreEqual(
                new[] { Tuple.Create("a", "b"), Tuple.Create("b", "e"), Tuple.Create("c", "i"), Tuple.Create("d", "b"), Tuple.Create("d", "E") },
                new[] { Tuple.Create("b", "e"), Tuple.Create("d", "E"), Tuple.Create("a", "b"), Tuple.Create("d", "b"), Tuple.Create("c", "i") }.OrderBy(value => value.Item1).ThenByDescending(value => value.Item2, StringComparer.Ordinal).ToList());
            CollectionAssert.AreEqual(
                new[] { Tuple.Create("a", "b"), Tuple.Create("b", "e"), Tuple.Create("c", "i"), Tuple.Create("d", "E"), Tuple.Create("d", "b") },
                new[] { Tuple.Create("b", "e"), Tuple.Create("d", "E"), Tuple.Create("a", "b"), Tuple.Create("d", "b"), Tuple.Create("c", "i") }.OrderBy(value => value.Item1).ThenByDescending(value => value.Item2, StringComparer.OrdinalIgnoreCase).ToList());
        }
    }
}
