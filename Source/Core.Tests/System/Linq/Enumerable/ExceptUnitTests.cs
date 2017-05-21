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
        /// Gets the set difference between a sequence and an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the set difference between a sequence and an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void ExceptEmpty()
        {
            var data = new[] { 1, 2, 3, 4, 5 };
            var excepted = data.Except(Enumerable.Empty<int>());

            CollectionAssert.AreEqual(data, excepted.ToList());
        }

        /// <summary>
        /// Gets the set difference between a sequence and a subset of that sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the set difference between a sequence and a subset of that sequence")]
        [Priority(1)]
        [TestMethod]
        public void ExceptSubset()
        {
            var data = new[] { 1, 2, 3, 4, 5 };
            var excepted = data.Except(new[] { 5, 2 });

            CollectionAssert.AreEqual(new[] { 1, 3, 4 }, excepted.ToList());
        }

        /// <summary>
        /// Gets the set difference between a sequence and a superset of that sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the set difference between a sequence and a superset of that sequence")]
        [Priority(1)]
        [TestMethod]
        public void ExceptSuperset()
        {
            var data = new[] { 1, 2, 3, 4, 5 };
            var excepted = data.Except(new[] { 5, 2, 1, 4, 3 });

            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), excepted.ToList());
        }

        /// <summary>
        /// Gets the set difference between a sequence and a sequence that contains a string with different capitalization
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the set difference between a sequence and a sequence that contains a string with different capitalization")]
        [Priority(1)]
        [TestMethod]
        public void ExceptDuplicateString()
        {
            var data = new[] { "first", "second" };
            var excepted = data.Except(new[] { "FIRST" });

            CollectionAssert.AreEqual(data, excepted.ToList());
        }
        
        /// <summary>
        /// Gets the set difference between a sequence and an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the set difference between a sequence and an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void ExceptComparerEmpty()
        {
            var data = new[] { 1, 2, 3, 4, 5 };
            var excepted = data.Except(Enumerable.Empty<int>(), null);

            CollectionAssert.AreEqual(data, excepted.ToList());
        }

        /// <summary>
        /// Gets the set difference between a sequence and a subset of that sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the set difference between a sequence and a subset of that sequence")]
        [Priority(1)]
        [TestMethod]
        public void ExceptComparerSubset()
        {
            var data = new[] { 1, 2, 3, 4, 5 };
            var excepted = data.Except(new[] { 5, 2 }, null);

            CollectionAssert.AreEqual(new[] { 1, 3, 4 }, excepted.ToList());
        }

        /// <summary>
        /// Gets the set difference between a sequence and a superset of that sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the set difference between a sequence and a superset of that sequence")]
        [Priority(1)]
        [TestMethod]
        public void ExceptComparerSuperset()
        {
            var data = new[] { 1, 2, 3, 4, 5 };
            var excepted = data.Except(new[] { 5, 2, 1, 4, 3 }, null);

            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), excepted.ToList());
        }

        /// <summary>
        /// Gets the set difference between a sequence and a sequence that contains a string with different capitalization
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the set difference between a sequence and a sequence that contains a string with different capitalization")]
        [Priority(1)]
        [TestMethod]
        public void ExceptComparerDuplicateString()
        {
            var data = new[] { "first", "second" };
            var excepted = data.Except(new[] { "FIRST" }, StringComparer.OrdinalIgnoreCase);

            CollectionAssert.AreEqual(new[] { "second" }, excepted.ToList());
        }
    }
}
