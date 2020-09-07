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
        /// Joins a null sequence with the grouping of another sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Joins a null sequence with the grouping of another sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupJoinNullSource()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupJoin(Enumerable.Empty<string>(), key => key, key => key, (key, grouping) => grouping.Concat(new[] { key })));
        }

        /// <summary>
        /// Joins a sequence with the grouping of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Joins a sequence with the grouping of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupJoinNullGrouping()
        {
            IEnumerable<string> inner = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<string>().GroupJoin(inner, key => key, key => key, (key, grouping) => grouping.Concat(new[] { key })));
        }

        /// <summary>
        /// Joins a sequence with the grouping of another sequence using a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Joins a sequence with the grouping of another sequence using a null selector")]
        [Priority(1)]
        [TestMethod]
        public void GroupJoinNullOuterSelector()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<string>().GroupJoin(Enumerable.Empty<string>(), null, key => key, (key, grouping) => grouping.Concat(new[] { key })));
        }

        /// <summary>
        /// Joins a sequence with the grouping of another sequence using a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Joins a sequence with the grouping of another sequence using a null selector")]
        [Priority(1)]
        [TestMethod]
        public void GroupJoinNullInnerSelector()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<string>().GroupJoin(Enumerable.Empty<string>(), key => key, null, (key, grouping) => grouping.Concat(new[] { key })));
        }

        /// <summary>
        /// Joins a sequence with the grouping of another sequence using a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Joins a sequence with the grouping of another sequence using a null selector")]
        [Priority(1)]
        [TestMethod]
        public void GroupJoinNullResultSelector()
        {
            Func<string, IEnumerable<string>, IEnumerable<string>> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<string>().GroupJoin(Enumerable.Empty<string>(), key => key, key => key, resultSelector));
        }

        /// <summary>
        /// Joins a null sequence with the grouping of another sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Joins a null sequence with the grouping of another sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupJoinComparerNullSource()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.GroupJoin(Enumerable.Empty<string>(), key => key, key => key, (key, grouping) => grouping.Concat(new[] { key }), StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Joins a sequence with the grouping of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Joins a sequence with the grouping of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupJoinComparerNullGrouping()
        {
            IEnumerable<string> inner = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<string>().GroupJoin(inner, key => key, key => key, (key, grouping) => grouping.Concat(new[] { key }), StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Joins a sequence with the grouping of another sequence using a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Joins a sequence with the grouping of another sequence using a null selector")]
        [Priority(1)]
        [TestMethod]
        public void GroupJoinComparerNullOuterSelector()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<string>().GroupJoin(Enumerable.Empty<string>(), null, key => key, (key, grouping) => grouping.Concat(new[] { key }), StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Joins a sequence with the grouping of another sequence using a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Joins a sequence with the grouping of another sequence using a null selector")]
        [Priority(1)]
        [TestMethod]
        public void GroupJoinComparerNullInnerSelector()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<string>().GroupJoin(Enumerable.Empty<string>(), key => key, null, (key, grouping) => grouping.Concat(new[] { key }), StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Joins a sequence with the grouping of another sequence using a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Joins a sequence with the grouping of another sequence using a null selector")]
        [Priority(1)]
        [TestMethod]
        public void GroupJoinComparerNullResultSelector()
        {
            Func<string, IEnumerable<string>, IEnumerable<string>> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<string>().GroupJoin(Enumerable.Empty<string>(), key => key, key => key, resultSelector, StringComparer.OrdinalIgnoreCase));
        }
    }
}
