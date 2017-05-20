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
        /// Counts the number of elements in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Counts the number of elements in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void CountEmpty()
        {
            Assert.AreEqual(0, Enumerable.Empty<string>().Count());
        }

        /// <summary>
        /// Counts the number of elements in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Counts the number of elements in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void CountPredicateEmpty()
        {
            Assert.AreEqual(0, Enumerable.Empty<string>().Count(value => true)); //// TODO singleton
        }

        /// <summary>
        /// Counts the number of elements in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Counts the number of elements in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void CountSingle()
        {
            Assert.AreEqual(1, new[] { 1 }.Select(value => value).Count());
        }

        /// <summary>
        /// Counts the number of elements in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Counts the number of elements in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void CountMany()
        {
            Assert.AreEqual(6, new[] { 1, 2, 3, 4, 5, 6 }.Select(value => value).Count());
        }

        /// <summary>
        /// Counts the number of elements in a sequence when no elements match
        /// </summary>
        [TestCategory("Unit")]
        [Description("Counts the number of elements in a sequence when no elements match")]
        [Priority(1)]
        [TestMethod]
        public void CountPredicateNoMatches()
        {
            Assert.AreEqual(0, new[] { 1, 2, 3, 4, 5, 6 }.Count(value => value < 1));
        }

        /// <summary>
        /// Counts the number of elements in a sequence when some elements match
        /// </summary>
        [TestCategory("Unit")]
        [Description("Counts the number of elements in a sequence when some elements match")]
        [Priority(1)]
        [TestMethod]
        public void CountPredicateSomeMatches()
        {
            Assert.AreEqual(2, new[] { 1, 2, 3, 4, 5, 6 }.Count(value => value < 3));
        }

        /// <summary>
        /// Counts the number of elements in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Counts the number of elements in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void CountGenericCollection()
        {
            var collection = new Collection<string>(Enumerable.Empty<string>());
            Assert.AreEqual(10, collection.Count());
        }

        /// <summary>
        /// Counts the number of elements in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Counts the number of elements in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void CountCollection()
        {
#if NET30 && !NET35 || NET40
            // this feature was added in .NET 4.0
            var collection = new OtherCollection<string>(new string[0]);
            Assert.AreEqual(11, collection.Count());
#endif
        }
    }
}
