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
        /// Selects strings to their characters
        /// </summary>
        [TestCategory("Unit")]
        [Description("Selects strings to their characters")]
        [Priority(1)]
        [TestMethod]
        public void SelectMany()
        {
            CollectionAssert.AreEqual(new[] { 't', 'e', 's', 't', 'v', 'a', 'l', 'u', 'e' }, new[] { "test", "value" }.SelectMany(value => value).ToList());
        }

        /// <summary>
        /// Selects strings to their characters
        /// </summary>
        [TestCategory("Unit")]
        [Description("Selects strings to their characters")]
        [Priority(1)]
        [TestMethod]
        public void SelectManyIndex()
        {
            var indices = new List<int>();
            CollectionAssert.AreEqual(
                new[] { 't', 'e', 's', 't', 'v', 'a', 'l', 'u', 'e' },
                new[] { "test", "value" }.SelectMany((value, index) => { indices.Add(index); return value; }).ToList());
            CollectionAssert.AreEqual(new[] { 0, 1 }, indices);
        }

        /// <summary>
        /// Selects strings to their characters
        /// </summary>
        [TestCategory("Unit")]
        [Description("Selects strings to their characters")]
        [Priority(1)]
        [TestMethod]
        public void SelectManyResultIndex()
        {
            var indices = new List<int>();
            CollectionAssert.AreEqual(
                new[] { "t", "e", "s", "t", "v", "a", "l", "u", "e" },
                new[] { "test", "value" }.SelectMany((val1, index) => { indices.Add(index); return val1.AsEnumerable(); }, (val1, val2) => val2.ToString()).ToList());
            CollectionAssert.AreEqual(new[] { 0, 1 }, indices);
        }

        /// <summary>
        /// Selects strings to their characters
        /// </summary>
        [TestCategory("Unit")]
        [Description("Selects strings to their characters")]
        [Priority(1)]
        [TestMethod]
        public void SelectManyResult()
        {
            CollectionAssert.AreEqual(
                new[] { "t", "e", "s", "t", "v", "a", "l", "u", "e" },
                new[] { "test", "value" }.SelectMany(val1 => val1.AsEnumerable(), (val1, val2) => val2.ToString()).ToList());
        }
    }
}
