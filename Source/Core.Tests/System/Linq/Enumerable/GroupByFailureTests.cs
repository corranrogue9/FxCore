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
        /// Groups the elements of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByNullSource()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString()));
        }

        /// <summary>
        /// Groups the elements of a sequence using a null key selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence using a null key selector")]
        [Priority(1)]
        [TestMethod]
        public void GroupByNullKeySelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector));
        }

        /// <summary>
        /// Groups the elements of a sequence 
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByNullSourceNullKeySelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByComparerNullSource()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), StringComparer.OrdinalIgnoreCase));
        }
        
        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByComparerNullKeySelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByComparerNullSourceNullKeySelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByComparerNullSourceNullComparer()
        {
            IEnumerable<string> data = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByComparerNullKeySelectorNullComparer()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByComparerNullSourceNullKeySelectorNullComparer()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorNullSource()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), (key, element) => string.Concat(key, element.Aggregate(string.Concat))));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorNullKeySelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, (key, element) => string.Concat(key, element.Aggregate(string.Concat))));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorNullSourceNullKeySelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, (key, element) => string.Concat(key, element.Aggregate(string.Concat))));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorNullResultSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), resultSelector));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorNullSourceNullResultSelector()
        {
            IEnumerable<string> data = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), resultSelector));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorNullKeySelectorNullResultSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, resultSelector));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorNullSourceNullKeySelectorNullResultSelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, resultSelector));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorNullSource()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), element => element[1].ToString()));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorNullKeySelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, element => element[1].ToString()));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorNullSourceNullKeySelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, element => element[1].ToString()));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorNullElementSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> elementSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), elementSelector));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorNullSourceNullElementSelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> elementSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), elementSelector));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorNullKeySelectorNullElementSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            Func<string, string> elementSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, elementSelector));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorNullSourceNullKeySelectorNullElementSelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            Func<string, string> elementSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, elementSelector));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorComparerNullSource()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), element => element[1].ToString(), StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorComparerNullKeySelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, element => element[1].ToString(), StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorComparerNullSourceNullKeySelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, element => element[1].ToString(), StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorComparerNullElementSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> elementSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), elementSelector, StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorComparerNullSourceNullElementSelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> elementSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), elementSelector, StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorComparerNullKeySelectorNullElementSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            Func<string, string> elementSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, elementSelector, StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorComparerNullSourceNullKeySelectorNullElementSelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            Func<string, string> elementSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, elementSelector, StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorComparerNullSourceNullComparer()
        {
            IEnumerable<string> data = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), element => element[1].ToString(), comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorComparerNullKeySelectorNullComparer()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, element => element[1].ToString(), comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorComparerNullSourceNullKeySelectorNullComparer()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, element => element[1].ToString(), comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorComparerNullElementSelectorNullComparer()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> elementSelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), elementSelector, comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorComparerNullSourceNullElementSelectorNullComparer()
        {
            IEnumerable<string> data = null;
            Func<string, string> elementSelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), elementSelector, comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorComparerNullKeySelectorNullElementSelectorNullComparer()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            Func<string, string> elementSelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, elementSelector, comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorComparerNullSourceNullKeySelectorNullElementSelectorNullComparer()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            Func<string, string> elementSelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, elementSelector, comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorComparerNullSource()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), (key, element) => string.Concat(key, element.Aggregate(string.Concat)), StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorComparerNullKeySelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, (key, element) => string.Concat(key, element.Aggregate(string.Concat)), StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorComparerNullSourceNullKeySelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, (key, element) => string.Concat(key, element.Aggregate(string.Concat)), StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorComparerNullResultSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), resultSelector, StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorComparerNullSourceNullResultSelector()
        {
            IEnumerable<string> data = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), resultSelector, StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorComparerNullKeySelectorNullResultSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, resultSelector, StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorComparerNullSourceNullKeySelectorNullResultSelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, resultSelector, StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorComparerNullSourceNullComparer()
        {
            IEnumerable<string> data = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), (key, element) => string.Concat(key, element.Aggregate(string.Concat)), comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorComparerNullKeySelectorNullComparer()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, (key, element) => string.Concat(key, element.Aggregate(string.Concat)), comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorComparerNullSourceNullKeySelectorNullComparer()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, (key, element) => string.Concat(key, element.Aggregate(string.Concat)), comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorComparerNullResultSelectorNullComparer()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, IEnumerable<string>, string> resultSelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), resultSelector, comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorComparerNullSourceNullResultSelectorNullComparer()
        {
            IEnumerable<string> data = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), resultSelector, comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorComparerNullKeySelectorNullResultSelectorNullComparer()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, resultSelector, comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorComparerNullSourceNullKeySelectorNullResultSelectorNullComparer()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, resultSelector, comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorNullSource()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), element => element[1].ToString(), (key, element) => string.Concat(key, element.Aggregate(string.Concat))));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorNullKeySelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, element => element[1].ToString(), (key, element) => string.Concat(key, element.Aggregate(string.Concat))));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorNullSourceNullKeySelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, element => element[1].ToString(), (key, element) => string.Concat(key, element.Aggregate(string.Concat))));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorNullElementSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> elementSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), elementSelector, (key, element) => string.Concat(key, element.Aggregate(string.Concat))));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorNullSourceNullElementSelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> elementSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), elementSelector, (key, element) => string.Concat(key, element.Aggregate(string.Concat))));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorNullKeySelectorNullElementSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            Func<string, string> elementSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, elementSelector, (key, element) => string.Concat(key, element.Aggregate(string.Concat))));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorNullSourceNullKeySelectorNullElementSelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            Func<string, string> elementSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, elementSelector, (key, element) => string.Concat(key, element.Aggregate(string.Concat))));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorNullResultSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), element => element[1].ToString(), resultSelector));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorNullSourceNullResultSelector()
        {
            IEnumerable<string> data = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), element => element[1].ToString(), resultSelector));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorNullKeySelectorNullResultSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, element => element[1].ToString(), resultSelector));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorNullSourceNullKeySelectorNullResultSelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, element => element[1].ToString(), resultSelector));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorNullElementSelectorNullResultSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> elementSelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), elementSelector, resultSelector));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorNullSourceNullElementSelectorNullResultSelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> elementSelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), elementSelector, resultSelector));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorNullKeySelectorNullElementSelectorNullResultSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            Func<string, string> elementSelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, elementSelector, resultSelector));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorNullSourceNullKeySelectorNullElementSelectorNullResultSelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            Func<string, string> elementSelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, elementSelector, resultSelector));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullSource()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), element => element[1].ToString(), (key, element) => string.Concat(key, element.Aggregate(string.Concat)), StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullKeySelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, element => element[1].ToString(), (key, element) => string.Concat(key, element.Aggregate(string.Concat)), StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullSourceNullKeySelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, element => element[1].ToString(), (key, element) => string.Concat(key, element.Aggregate(string.Concat)), StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullElementSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> elementSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), elementSelector, (key, element) => string.Concat(key, element.Aggregate(string.Concat)), StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullSourceNullElementSelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> elementSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), elementSelector, (key, element) => string.Concat(key, element.Aggregate(string.Concat)), StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullKeySelectorNullElementSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            Func<string, string> elementSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, elementSelector, (key, element) => string.Concat(key, element.Aggregate(string.Concat)), StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullSourceNullKeySelectorNullElementSelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            Func<string, string> elementSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, elementSelector, (key, element) => string.Concat(key, element.Aggregate(string.Concat)), StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullResultSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), element => element[1].ToString(), resultSelector, StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullSourceNullResultSelector()
        {
            IEnumerable<string> data = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), element => element[1].ToString(), resultSelector, StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullKeySelectorNullResultSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, element => element[1].ToString(), resultSelector, StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullSourceNullKeySelectorNullResultSelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, element => element[1].ToString(), resultSelector, StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullElementSelectorNullResultSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> elementSelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), elementSelector, resultSelector, StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullSourceNullElementSelectorNullResultSelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> elementSelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), elementSelector, resultSelector, StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullKeySelectorNullElementSelectorNullResultSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            Func<string, string> elementSelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, elementSelector, resultSelector, StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullSourceNullKeySelectorNullElementSelectorNullResultSelector()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            Func<string, string> elementSelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, elementSelector, resultSelector, StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullSourceNullComparer()
        {
            IEnumerable<string> data = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), element => element[1].ToString(), (key, element) => string.Concat(key, element.Aggregate(string.Concat)), comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullKeySelectorNullComparer()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, element => element[1].ToString(), (key, element) => string.Concat(key, element.Aggregate(string.Concat)), comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullSourceNullKeySelectorNullComparer()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, element => element[1].ToString(), (key, element) => string.Concat(key, element.Aggregate(string.Concat)), comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullElementSelectorNullComparer()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> elementSelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), elementSelector, (key, element) => string.Concat(key, element.Aggregate(string.Concat)), comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullSourceNullElementSelectorNullComparer()
        {
            IEnumerable<string> data = null;
            Func<string, string> elementSelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), elementSelector, (key, element) => string.Concat(key, element.Aggregate(string.Concat)), comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullKeySelectorNullElementSelectorNullComparer()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            Func<string, string> elementSelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, elementSelector, (key, element) => string.Concat(key, element.Aggregate(string.Concat)), comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullSourceNullKeySelectorNullElementSelectorNullComparer()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            Func<string, string> elementSelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, elementSelector, (key, element) => string.Concat(key, element.Aggregate(string.Concat)), comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullResultSelectorNullComparer()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, IEnumerable<string>, string> resultSelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), element => element[1].ToString(), resultSelector, comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullSourceNullResultSelectorNullComparer()
        {
            IEnumerable<string> data = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), element => element[1].ToString(), resultSelector, comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullKeySelectorNullResultSelectorNullComparer()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, element => element[1].ToString(), resultSelector, comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullSourceNullKeySelectorNullResultSelectorNullComparer()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, element => element[1].ToString(), resultSelector, comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullElementSelectorNullResultSelectorNullComparer()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> elementSelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), elementSelector, resultSelector, comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullSourceNullElementSelectorNullResultSelectorNullComparer()
        {
            IEnumerable<string> data = null;
            Func<string, string> elementSelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(key => key[0].ToString(), elementSelector, resultSelector, comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullKeySelectorNullElementSelectorNullResultSelectorNullComparer()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            Func<string, string> keySelector = null;
            Func<string, string> elementSelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, elementSelector, resultSelector, comparer));
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullSourceNullKeySelectorNullElementSelectorNullResultSelectorNullComparer()
        {
            IEnumerable<string> data = null;
            Func<string, string> keySelector = null;
            Func<string, string> elementSelector = null;
            Func<string, IEnumerable<string>, string> resultSelector = null;
            IEqualityComparer<string> comparer = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupBy(keySelector, elementSelector, resultSelector, comparer));
        }
    }
}
