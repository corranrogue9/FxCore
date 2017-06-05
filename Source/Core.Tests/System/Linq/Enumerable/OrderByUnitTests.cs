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
        public void OrderBy()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, new[] { 2, 4, 1, 3 }.OrderBy(value => value).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void OrderByNulls()
        {
            CollectionAssert.AreEqual(new[] { null, "a", "b", "c", "d" }, new[] { "b", null, "d", "a", "c" }.OrderBy(value => value).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence and ensures they are stable
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence and ensures they are stable")]
        [Priority(1)]
        [TestMethod]
        public void OrderByStable()
        {
            CollectionAssert.AreEqual(
                new[] { null, Tuple.Create("a", 3), Tuple.Create("b", 1), Tuple.Create("c", 5), Tuple.Create("c", 4), Tuple.Create("d", 2) }, 
                new[] { Tuple.Create("b", 1), null, Tuple.Create("d", 2), Tuple.Create("c", 5), Tuple.Create("a", 3), Tuple.Create("c", 4) }.OrderBy(value => value == null ? null : value.Item1).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void OrderByComparer()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, new[] { 2, 4, 1, 3 }.OrderBy(value => value, Comparer<int>.Default).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void OrderByComparerNulls()
        {
            CollectionAssert.AreEqual(new[] { null, "a", "b", "c", "d" }, new[] { "b", null, "d", "a", "c" }.OrderBy(value => value, Comparer<string>.Default).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence and ensures they are stable
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence and ensures they are stable")]
        [Priority(1)]
        [TestMethod]
        public void OrderByComparerStable()
        {
            CollectionAssert.AreEqual(
                new[] { null, Tuple.Create("a", 3), Tuple.Create("b", 1), Tuple.Create("c", 5), Tuple.Create("c", 4), Tuple.Create("d", 2) },
                new[] { Tuple.Create("b", 1), null, Tuple.Create("d", 2), Tuple.Create("c", 5), Tuple.Create("a", 3), Tuple.Create("c", 4) }.OrderBy(value => value == null ? null : value.Item1, Comparer<string>.Default).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence with a null comparer
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence with a null comparer")]
        [Priority(1)]
        [TestMethod]
        public void OrderByComparerNullComparer()
        {
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, new[] { 2, 4, 1, 3 }.OrderBy(value => value, null).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void OrderByComparerNonDefault()
        {
            CollectionAssert.AreEqual(new[] { "B", "a", "c" }, new[] { "B", "c", "a" }.OrderBy(value => value, StringComparer.Ordinal).ToList());
            CollectionAssert.AreEqual(new[] { "a", "B", "c" }, new[] { "B", "c", "a" }.OrderBy(value => value, StringComparer.OrdinalIgnoreCase).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void OrderByDescending()
        {
            CollectionAssert.AreEqual(new[] { 4, 3, 2, 1 }, new[] { 2, 4, 1, 3 }.OrderByDescending(value => value).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void OrderByDescendingNulls()
        {
            CollectionAssert.AreEqual(new[] { "d", "c", "b", "a", null }, new[] { "b", null, "d", "a", "c" }.OrderByDescending(value => value).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence and ensures they are stable
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence and ensures they are stable")]
        [Priority(1)]
        [TestMethod]
        public void OrderByDescendingStable()
        {
            CollectionAssert.AreEqual(
                new[] { Tuple.Create("d", 2), Tuple.Create("c", 4), Tuple.Create("c", 5), Tuple.Create("b", 1), Tuple.Create("a", 3), null },
                new[] { Tuple.Create("b", 1), null, Tuple.Create("d", 2), Tuple.Create("c", 4), Tuple.Create("a", 3), Tuple.Create("c", 5) }.OrderByDescending(value => value == null ? null : value.Item1).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void OrderByDescendingComparer()
        {
            CollectionAssert.AreEqual(new[] { 4, 3, 2, 1 }, new[] { 2, 4, 1, 3 }.OrderByDescending(value => value, Comparer<int>.Default).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void OrderByDescendingComparerNulls()
        {
            CollectionAssert.AreEqual(new[] { "d", "c", "b", "a", null }, new[] { "b", null, "d", "a", "c" }.OrderByDescending(value => value, Comparer<string>.Default).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence and ensures they are stable
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence and ensures they are stable")]
        [Priority(1)]
        [TestMethod]
        public void OrderByDescendingComparerStable()
        {
            CollectionAssert.AreEqual(
                new[] { Tuple.Create("d", 2), Tuple.Create("c", 4), Tuple.Create("c", 5), Tuple.Create("b", 1), Tuple.Create("a", 3), null },
                new[] { Tuple.Create("b", 1), null, Tuple.Create("d", 2), Tuple.Create("c", 4), Tuple.Create("a", 3), Tuple.Create("c", 5) }.OrderByDescending(value => value == null ? null : value.Item1, Comparer<string>.Default).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence with a null comparer
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence with a null comparer")]
        [Priority(1)]
        [TestMethod]
        public void OrderByDescendingComparerNullComparer()
        {
            CollectionAssert.AreEqual(new[] { 4, 3, 2, 1 }, new[] { 2, 4, 1, 3 }.OrderByDescending(value => value, null).ToList());
        }

        /// <summary>
        /// Orders the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Orders the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void OrderByDescendingComparerNonDefault()
        {
            CollectionAssert.AreEqual(new[] { "c", "a", "B" }, new[] { "B", "c", "a" }.OrderByDescending(value => value, StringComparer.Ordinal).ToList());
            CollectionAssert.AreEqual(new[] { "c", "B", "a" }, new[] { "B", "c", "a" }.OrderByDescending(value => value, StringComparer.OrdinalIgnoreCase).ToList());
        }
    }
}
