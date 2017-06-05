namespace System.Linq
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class EnumerableFailureTests
    {
        /// <summary>
        /// Creates a lookup from a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a lookup from a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupNullSequence()
        {
            IEnumerable<Tuple<string, int>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.ToLookup(tuple => tuple.Item1));
        }

        /// <summary>
        /// Creates a lookup from a sequence with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a lookup from a sequence with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupNullSelector()
        {
            Func<Tuple<string, int>, string> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(
                () => new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3) }.ToLookup(selector));
        }

        /// <summary>
        /// Creates a lookup from a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a lookup from a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupComparerNullSequence()
        {
            IEnumerable<Tuple<string, int>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.ToLookup(tuple => tuple.Item1, StringComparer.Ordinal));
        }

        /// <summary>
        /// Creates a lookup from a sequence with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a lookup from a sequence with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupComparerNullSelector()
        {
            Func<Tuple<string, int>, string> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(
                () => new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3) }.ToLookup(selector, StringComparer.Ordinal));
        }

        /// <summary>
        /// Creates a lookup from a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a lookup from a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupSelectorNullSequence()
        {
            IEnumerable<Tuple<string, int>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.ToLookup(tuple => tuple.Item1, tuple => tuple.Item2));
        }

        /// <summary>
        /// Creates a lookup from a sequence with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a lookup from a sequence with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupSelectorNullSelector()
        {
            Func<Tuple<string, int>, string> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(
                () => new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3) }.ToLookup(selector, tuple => tuple.Item2));
        }

        /// <summary>
        /// Creates a lookup from a sequence with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a lookup from a sequence with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupSelectorNullElementSelector()
        {
            Func<Tuple<string, int>, int> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(
                () => new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3) }.ToLookup(tuple => tuple.Item1, selector));
        }

        /// <summary>
        /// Creates a lookup from a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a lookup from a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupComparerSelectorNullSequence()
        {
            IEnumerable<Tuple<string, int>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.ToLookup(tuple => tuple.Item1, tuple => tuple.Item2, StringComparer.Ordinal));
        }

        /// <summary>
        /// Creates a lookup from a sequence with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a lookup from a sequence with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupComparerSelectorNullSelector()
        {
            Func<Tuple<string, int>, string> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(
                () => new[]
                {
                    Tuple.Create("name", 1),
                    Tuple.Create("name2", 2),
                    Tuple.Create("name3", 3)
                }.ToLookup(selector, tuple => tuple.Item2, StringComparer.Ordinal));
        }

        /// <summary>
        /// Creates a lookup from a sequence with a null element selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a lookup from a sequence with a null element selector")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupComparerSelectorNullElementSelector()
        {
            Func<Tuple<string, int>, int> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(
                () => new[]
                {
                    Tuple.Create("name", 1),
                    Tuple.Create("name2", 2),
                    Tuple.Create("name3", 3)
                }.ToLookup(tuple => tuple.Item1, selector, StringComparer.Ordinal));
        }
    }
}
