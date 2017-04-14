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
        /// Creates a list from a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a list from a sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToList()
        {
            var list = Enumerable.Range(1, 4).ToList();
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
            Assert.AreEqual(4, list[3]);
        }

        /// <summary>
        /// Creates a list from an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a list from an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToListEmpty()
        {
            var list = Enumerable.Empty<int>().ToList();
            Assert.AreEqual(0, list.Count);
        }

        /// <summary>
        /// Creates a list from a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a list from a sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToListDifferentInstances()
        {
            var original = new List<int>(new[] { 1, 2, 3, 4 });
            var result = original.ToList();
            CollectionAssert.AreEqual(original, result);
            Assert.IsFalse(original == result);
        }
    }
}
