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
        /// Concatenates two sequences when the first is empty
        /// </summary>
        [TestCategory("Unit")]
        [Description("Concatenates two sequences when the first is empty")]
        [Priority(1)]
        [TestMethod]
        public void ConcatEmptyFirst()
        {
            var first = Enumerable.Empty<string>();
            var second = new List<string>();
            second.Add("test1");
            second.Add("test2");

            var concat = first.Concat(second);

            CollectionAssert.AreEqual(second, concat.ToList());
        }

        /// <summary>
        /// Concatenates two sequences when the second is empty
        /// </summary>
        [TestCategory("Unit")]
        [Description("Concatenates two sequences when the second is empty")]
        [Priority(1)]
        [TestMethod]
        public void ConcatEmptySecond()
        {
            var first = new List<string>();
            first.Add("test1");
            first.Add("test2");
            var second = Enumerable.Empty<string>();

            var concat = first.Concat(second);

            CollectionAssert.AreEqual(first, concat.ToList());
        }

        /// <summary>
        /// Concatenates two sequences
        /// </summary>
        [TestCategory("Unit")]
        [Description("Concatenates two sequences")]
        [Priority(1)]
        [TestMethod]
        public void Concat()
        {
            var first = new List<string>();
            first.Add("test1");
            first.Add("test2");
            var second = new List<string>();
            second.Add("test3");
            second.Add("test4");

            var concat = first.Concat(second);

            var result = new List<string>();
            result.Add("test1");
            result.Add("test2");
            result.Add("test3");
            result.Add("test4");
            CollectionAssert.AreEqual(result, concat.ToList());
        }
    }
}
