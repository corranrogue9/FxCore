namespace System.Linq
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class EnumerableFailureTests
    {
        /// <summary>
        /// Creates a dictionary from a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a dictionary from a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionaryNullSequence()
        {
            IEnumerable<Tuple<string, int>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.ToDictionary(tuple => tuple.Item1));
        }

        /// <summary>
        /// Creates a dictionary from a sequence with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a dictionary from a sequence with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionaryNullSelector()
        {
            Func<Tuple<string, int>, string> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(
                () => new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3) }.ToDictionary(selector));
        }

        /// <summary>
        /// Creates a dictionary from a sequence with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a dictionary from a sequence with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionaryDuplicateKey()
        {
            ExceptionAssert.Throws<ArgumentException>(
                () => new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name", 3) }.ToDictionary(tuple => tuple.Item1));
        }

        /// <summary>
        /// Creates a dictionary from a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a dictionary from a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionaryComparerNullSequence()
        {
            IEnumerable<Tuple<string, int>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.ToDictionary(tuple => tuple.Item1, StringComparer.Ordinal));
        }

        /// <summary>
        /// Creates a dictionary from a sequence with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a dictionary from a sequence with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionaryComparerNullSelector()
        {
            Func<Tuple<string, int>, string> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(
                () => new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3) }.ToDictionary(selector, StringComparer.Ordinal));
        }

        /// <summary>
        /// Creates a dictionary from a sequence with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a dictionary from a sequence with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionaryComparerDuplicateKey()
        {
            ExceptionAssert.Throws<ArgumentException>(
                () => new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name", 3) }.ToDictionary(tuple => tuple.Item1, StringComparer.Ordinal));
        }

        /// <summary>
        /// Creates a dictionary from a sequence with a case insensitive comparer
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a dictionary from a sequence with a case insensitive comparer")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionaryComparerCaseInsensitive()
        {
            ExceptionAssert.Throws<ArgumentException>(
                () => new[]
                {
                    Tuple.Create("name", 1),
                    Tuple.Create("name2", 2),
                    Tuple.Create("name3", 3),
                    Tuple.Create("NAME", 3)
                }.ToDictionary(tuple => tuple.Item1, StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Creates a dictionary from a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a dictionary from a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionarySelectorNullSequence()
        {
            IEnumerable<Tuple<string, int>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2));
        }

        /// <summary>
        /// Creates a dictionary from a sequence with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a dictionary from a sequence with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionarySelectorNullSelector()
        {
            Func<Tuple<string, int>, string> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(
                () => new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3) }.ToDictionary(selector, tuple => tuple.Item2));
        }

        /// <summary>
        /// Creates a dictionary from a sequence with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a dictionary from a sequence with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionarySelectorNullElementSelector()
        {
            Func<Tuple<string, int>, int> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(
                () => new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3) }.ToDictionary(tuple => tuple.Item1, selector));
        }

        /// <summary>
        /// Creates a dictionary from a sequence with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a dictionary from a sequence with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionarySelectorDuplicateKey()
        {
            ExceptionAssert.Throws<ArgumentException>(
                () => new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name", 3) }.ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2));
        }

        /// <summary>
        /// Creates a dictionary from a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a dictionary from a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionaryComparerSelectorNullSequence()
        {
            IEnumerable<Tuple<string, int>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2, StringComparer.Ordinal));
        }

        /// <summary>
        /// Creates a dictionary from a sequence with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a dictionary from a sequence with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionaryComparerSelectorNullSelector()
        {
            Func<Tuple<string, int>, string> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(
                () => new[]
                {
                    Tuple.Create("name", 1),
                    Tuple.Create("name2", 2),
                    Tuple.Create("name3", 3)
                }.ToDictionary(selector, tuple => tuple.Item2, StringComparer.Ordinal));
        }

        /// <summary>
        /// Creates a dictionary from a sequence with a null element selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a dictionary from a sequence with a null element selector")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionaryComparerSelectorNullElementSelector()
        {
            Func<Tuple<string, int>, int> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(
                () => new[]
                {
                    Tuple.Create("name", 1),
                    Tuple.Create("name2", 2),
                    Tuple.Create("name3", 3)
                }.ToDictionary(tuple => tuple.Item1, selector, StringComparer.Ordinal));
        }

        /// <summary>
        /// Creates a dictionary from a sequence with a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a dictionary from a sequence with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionaryComparerSelectorDuplicateKey()
        {
            ExceptionAssert.Throws<ArgumentException>(
                () => new[]
                {
                    Tuple.Create("name", 1),
                    Tuple.Create("name2", 2),
                    Tuple.Create("name", 3)
                }.ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2, StringComparer.Ordinal));
        }

        /// <summary>
        /// Creates a dictionary from a sequence with a case insensitive comparer
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a dictionary from a sequence with a case insensitive comparer")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionaryComparerSelectorCaseInsensitive()
        {
            ExceptionAssert.Throws<ArgumentException>(
                () => new[]
                {
                    Tuple.Create("name", 1),
                    Tuple.Create("name2", 2),
                    Tuple.Create("name3", 3),
                    Tuple.Create("NAME", 3)
                }.ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2, StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Creates a dictionary from a sequence with a key selector that returns null
        /// </summary>
        [TestCategory("Failure")]
        [Description("Creates a dictionary from a sequence with a key selector that returns null")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionaryKeySelectorNull()
        {
            Func<Tuple<string, int>, object> keySelector = tuple => null;
            ExceptionAssert.Throws<ArgumentNullException>(
                () => new[]
                {
                    Tuple.Create("name", 1),
                    Tuple.Create("name2", 2),
                    Tuple.Create("name3", 3),
                    Tuple.Create("NAME", 3)
                }.ToDictionary(keySelector));
            ExceptionAssert.Throws<ArgumentNullException>(
                () => new[]
                {
                    Tuple.Create("name", 1),
                    Tuple.Create("name2", 2),
                    Tuple.Create("name3", 3),
                    Tuple.Create("NAME", 3)
                }.ToDictionary(keySelector, EqualityComparer<object>.Default));
            ExceptionAssert.Throws<ArgumentNullException>(
                () => new[]
                {
                    Tuple.Create("name", 1),
                    Tuple.Create("name2", 2),
                    Tuple.Create("name3", 3),
                    Tuple.Create("NAME", 3)
                }.ToDictionary(keySelector, value => value, EqualityComparer<object>.Default));
            ExceptionAssert.Throws<ArgumentNullException>(
                () => new[]
                {
                    Tuple.Create("name", 1),
                    Tuple.Create("name2", 2),
                    Tuple.Create("name3", 3),
                    Tuple.Create("NAME", 3)
                }.ToDictionary(keySelector, value => value));
        }
    }
}
