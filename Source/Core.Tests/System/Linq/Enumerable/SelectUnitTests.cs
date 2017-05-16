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
        /// Doubles the values in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Doubles the values in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void Select()
        {
            CollectionAssert.AreEqual(new[] { 2, 4, 6, 8 }, new[] { 1, 2, 3, 4 }.Select(value => value * 2).ToList());
        }

        /// <summary>
        /// Converts the integers to strings
        /// </summary>
        [TestCategory("Unit")]
        [Description("Converts the integers to strings")]
        [Priority(1)]
        [TestMethod]
        public void SelectType()
        {
            CollectionAssert.AreEqual(new[] { "1", "2", "3", "4" }, new[] { 1, 2, 3, 4 }.Select(value => value.ToString()).ToList());
        }

        /// <summary>
        /// Doubles the values in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Doubles the values in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void SelectIndex()
        {
            var indices = new List<int>();
            CollectionAssert.AreEqual(new[] { 2, 4, 6, 8 }, new[] { 1, 2, 3, 4 }.Select((value, index) => { indices.Add(index); return value * 2; }).ToList());
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 3 }, indices);
        }

        /// <summary>
        /// Selects elements in a sequence that is massive
        /// </summary>
        [TestCategory("Unit"), TestCategory("LongRunning")]
        [Description("Selects elements in a sequence that is massive")]
        [Priority(1)]
        [TestMethod]
        public void SelectOverflow()
        {
            Enumerable.Repeat(0, int.MaxValue).Concat(Enumerable.Repeat(0, 2)).Select(value => value).LongCount(); //// TODO singleton
        }
    }
}
