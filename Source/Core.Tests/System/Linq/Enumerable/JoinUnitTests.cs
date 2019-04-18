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
        /// Joins two sequences with no key duplications
        /// </summary>
        [TestCategory("Unit")]
        [Description("Joins two sequences with no key duplications")]
        [Priority(1)]
        [TestMethod]
        public void Join()
        {
            var outer = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3) };
            var inner = new[] { Tuple.Create("name", 4), Tuple.Create("name3", 5) };
            var join = outer.Join(
                inner,
                tuple => tuple.Item1,
                tuple => tuple.Item1, 
                (outerElement, innerElement) => Tuple.Create(outerElement.Item2, innerElement.Item2));
            CollectionAssert.AreEqual(new[] { Tuple.Create(1, 4), Tuple.Create(3, 5) }, join.ToList());
        }

        /// <summary>
        /// Joins two sequences with key duplications
        /// </summary>
        [TestCategory("Unit")]
        [Description("Joins two sequences with key duplications")]
        [Priority(1)]
        [TestMethod]
        public void JoinWithDuplicates()
        {
            var outer = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3), Tuple.Create("name3", 6) };
            var inner = new[] { Tuple.Create("name", 4), Tuple.Create("name3", 5) };
            var join = outer.Join(
                inner,
                tuple => tuple.Item1,
                tuple => tuple.Item1,
                (outerElement, innerElement) => Tuple.Create(outerElement.Item2, innerElement.Item2));
            CollectionAssert.AreEqual(new[] { Tuple.Create(1, 4), Tuple.Create(3, 5), Tuple.Create(6, 5) }, join.ToList());
        }

        /// <summary>
        /// Joins two sequences with only key duplications
        /// </summary>
        [TestCategory("Unit")]
        [Description("Joins two sequences with only key duplications")]
        [Priority(1)]
        [TestMethod]
        public void JoinOnlyDuplicates()
        {
            var outer = new[] { Tuple.Create("name", 1), Tuple.Create("name", 2), Tuple.Create("name", 3) };
            var inner = new[] { Tuple.Create("name", 4), Tuple.Create("name", 5) };
            var join = outer.Join(
                inner,
                tuple => tuple.Item1,
                tuple => tuple.Item1,
                (outerElement, innerElement) => Tuple.Create(outerElement.Item2, innerElement.Item2));
            CollectionAssert.AreEqual(new[] { Tuple.Create(1, 4), Tuple.Create(1, 5), Tuple.Create(2, 4), Tuple.Create(2, 5), Tuple.Create(3, 4), Tuple.Create(3, 5) }, join.ToList());
        }

        /// <summary>
        /// Joins two sequences with null keys
        /// </summary>
        [TestCategory("Unit")]
        [Description("Joins two sequences with null keys")]
        [Priority(1)]
        [TestMethod]
        public void JoinWithNulls()
        {
            var outer = new[] { Tuple.Create("name", 1), Tuple.Create((string)null, 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3) };
            var inner = new[] { Tuple.Create("name", 4), Tuple.Create((string)null, 5) };
            var join = outer.Join(
                inner,
                tuple => tuple.Item1,
                tuple => tuple.Item1,
                (outerElement, innerElement) => Tuple.Create(outerElement.Item2, innerElement.Item2));
            CollectionAssert.AreEqual(new[] { Tuple.Create(1, 4) }, join.ToList());
        }

        /// <summary>
        /// Joins two sequences with a comparer and no key duplications
        /// </summary>
        [TestCategory("Unit")]
        [Description("Joins two sequences with a comparer and no key duplications")]
        [Priority(1)]
        [TestMethod]
        public void JoinComparer()
        {
            var outer = new[] { Tuple.Create("NAME", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3) };
            var inner = new[] { Tuple.Create("name", 4), Tuple.Create("name3", 5) };
            var join = outer.Join(
                inner,
                tuple => tuple.Item1,
                tuple => tuple.Item1,
                (outerElement, innerElement) => Tuple.Create(outerElement.Item2, innerElement.Item2),
                StringComparer.OrdinalIgnoreCase);
            CollectionAssert.AreEqual(new[] { Tuple.Create(1, 4), Tuple.Create(3, 5) }, join.ToList());
        }

        /// <summary>
        /// Joins two sequences with a comparer and key duplications
        /// </summary>
        [TestCategory("Unit")]
        [Description("Joins two sequences with a comparer and key duplications")]
        [Priority(1)]
        [TestMethod]
        public void JoinComparerWithDuplicates()
        {
            var outer = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3), Tuple.Create("name3", 6) };
            var inner = new[] { Tuple.Create("name", 4), Tuple.Create("name3", 5) };
            var join = outer.Join(
                inner,
                tuple => tuple.Item1,
                tuple => tuple.Item1,
                (outerElement, innerElement) => Tuple.Create(outerElement.Item2, innerElement.Item2),
                StringComparer.OrdinalIgnoreCase);
            CollectionAssert.AreEqual(new[] { Tuple.Create(1, 4), Tuple.Create(3, 5), Tuple.Create(3, 4), Tuple.Create(6, 5) }, join.ToList());
        }

        /// <summary>
        /// Joins two sequences with a comparer and only key duplications
        /// </summary>
        [TestCategory("Unit")]
        [Description("Joins two sequences with a comparer and only key duplications")]
        [Priority(1)]
        [TestMethod]
        public void JoinComparerOnlyDuplicates()
        {
            var outer = new[] { Tuple.Create("name", 1), Tuple.Create("name", 2), Tuple.Create("NAME", 3) };
            var inner = new[] { Tuple.Create("name", 4), Tuple.Create("NAME", 5) };
            var join = outer.Join(
                inner,
                tuple => tuple.Item1,
                tuple => tuple.Item1,
                (outerElement, innerElement) => Tuple.Create(outerElement.Item2, innerElement.Item2),
                StringComparer.OrdinalIgnoreCase);
            CollectionAssert.AreEqual(new[] { Tuple.Create(1, 4), Tuple.Create(1, 5), Tuple.Create(2, 4), Tuple.Create(2, 5), Tuple.Create(3, 4), Tuple.Create(3, 5) }, join.ToList());
        }

        /// <summary>
        /// Joins two sequences with a comparer and null keys
        /// </summary>
        [TestCategory("Unit")]
        [Description("Joins two sequences with a comparer and null keys")]
        [Priority(1)]
        [TestMethod]
        public void JoinComparerWithNulls()
        {
            var outer = new[] { Tuple.Create("name", 1), Tuple.Create((string)null, 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3) };
            var inner = new[] { Tuple.Create("name", 4), Tuple.Create((string)null, 5) };
            var join = outer.Join(
                inner,
                tuple => tuple.Item1,
                tuple => tuple.Item1,
                (outerElement, innerElement) => Tuple.Create(outerElement.Item2, innerElement.Item2),
                StringComparer.OrdinalIgnoreCase);
            CollectionAssert.AreEqual(new[] { Tuple.Create(1, 4), Tuple.Create(3, 4) }, join.ToList());
        }

        /// <summary>
        /// Joins two sequences with a null comparer and no key duplications
        /// </summary>
        [TestCategory("Unit")]
        [Description("Joins two sequences with a null comparer and no key duplications")]
        [Priority(1)]
        [TestMethod]
        public void JoinNullComparer()
        {
            var outer = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3) };
            var inner = new[] { Tuple.Create("name", 4), Tuple.Create("name3", 5) };
            var join = outer.Join(
                inner,
                tuple => tuple.Item1,
                tuple => tuple.Item1,
                (outerElement, innerElement) => Tuple.Create(outerElement.Item2, innerElement.Item2),
                null);
            CollectionAssert.AreEqual(new[] { Tuple.Create(1, 4), Tuple.Create(3, 5) }, join.ToList());
        }

        /// <summary>
        /// Joins two sequences with a null comparer and key duplications
        /// </summary>
        [TestCategory("Unit")]
        [Description("Joins two sequences with a null comparer and key duplications")]
        [Priority(1)]
        [TestMethod]
        public void JoinNullComparerWithDuplicates()
        {
            var outer = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3), Tuple.Create("name3", 6) };
            var inner = new[] { Tuple.Create("name", 4), Tuple.Create("name3", 5) };
            var join = outer.Join(
                inner,
                tuple => tuple.Item1,
                tuple => tuple.Item1,
                (outerElement, innerElement) => Tuple.Create(outerElement.Item2, innerElement.Item2),
                null);
            CollectionAssert.AreEqual(new[] { Tuple.Create(1, 4), Tuple.Create(3, 5), Tuple.Create(6, 5) }, join.ToList());
        }

        /// <summary>
        /// Joins two sequences with a null comparer and only key duplications
        /// </summary>
        [TestCategory("Unit")]
        [Description("Joins two sequences with a null comparer and only key duplications")]
        [Priority(1)]
        [TestMethod]
        public void JoinNullComparerOnlyDuplicates()
        {
            var outer = new[] { Tuple.Create("name", 1), Tuple.Create("name", 2), Tuple.Create("name", 3) };
            var inner = new[] { Tuple.Create("name", 4), Tuple.Create("name", 5) };
            var join = outer.Join(
                inner,
                tuple => tuple.Item1,
                tuple => tuple.Item1,
                (outerElement, innerElement) => Tuple.Create(outerElement.Item2, innerElement.Item2),
                null);
            CollectionAssert.AreEqual(new[] { Tuple.Create(1, 4), Tuple.Create(1, 5), Tuple.Create(2, 4), Tuple.Create(2, 5), Tuple.Create(3, 4), Tuple.Create(3, 5) }, join.ToList());
        }

        /// <summary>
        /// Joins two sequences with a null comparer and null keys
        /// </summary>
        [TestCategory("Unit")]
        [Description("Joins two sequences with a null comparer and null keys")]
        [Priority(1)]
        [TestMethod]
        public void JoinNullComparerWithNulls()
        {
            var outer = new[] { Tuple.Create("name", 1), Tuple.Create((string)null, 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3) };
            var inner = new[] { Tuple.Create("name", 4), Tuple.Create((string)null, 5) };
            var join = outer.Join(
                inner,
                tuple => tuple.Item1,
                tuple => tuple.Item1,
                (outerElement, innerElement) => Tuple.Create(outerElement.Item2, innerElement.Item2),
                null);
            CollectionAssert.AreEqual(new[] { Tuple.Create(1, 4) }, join.ToList());
        }

        /// <summary>
        /// Joins two sequences with a comparer that finds null to be equivalent to the empty string
        /// </summary>
        [TestCategory("Unit")]
        [Description("Joins two sequences with a comparer that finds null to be equivalent to the empty string")]
        [Priority(1)]
        [TestMethod]
        public void JoinNullIsEmptyComparer()
        {
            var outer = new[] { Tuple.Create("name", 1), Tuple.Create((string)null, 2), Tuple.Create("name3", 3), Tuple.Create(string.Empty, 3) };
            var inner = new[] { Tuple.Create(string.Empty, 4), Tuple.Create((string)null, 5) };
            var join = outer.Join(
                inner,
                tuple => tuple.Item1,
                tuple => tuple.Item1,
                (outerElement, innerElement) => Tuple.Create(outerElement.Item2, innerElement.Item2),
                NullEqualsEmptyComparer.Instance);
            CollectionAssert.AreEqual(new[] { Tuple.Create(3, 4) }, join.ToList());
        }

        /// <summary>
        /// Joins two sequences with a comparer that finds the empty string to be equivalent to null
        /// </summary>
        [TestCategory("Unit")]
        [Description("Joins two sequences with a comparer that finds the empty string to be equivalent to null")]
        [Priority(1)]
        [TestMethod]
        public void JoinEmptyIsNullComparer()
        {
            var outer = new[] { Tuple.Create("name", 1), Tuple.Create((string)null, 2), Tuple.Create("name3", 3), Tuple.Create(string.Empty, 3) };
            var inner = new[] { Tuple.Create(string.Empty, 4), Tuple.Create((string)null, 5) };
            var join = outer.Join(
                inner,
                tuple => tuple.Item1,
                tuple => tuple.Item1,
                (outerElement, innerElement) => Tuple.Create(outerElement.Item2, innerElement.Item2),
                EmptyEqualsNullComparer.Instance);
            CollectionAssert.AreEqual(new[] { Tuple.Create(2, 4), Tuple.Create(3, 4) }, join.ToList());
        }
    }
}
