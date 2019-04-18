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
        /// Joins a null sequence with a sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Joins a null sequence with a sequence")]
        [Priority(1)]
        [TestMethod]
        public void JoinNullSequence()
        {
            IEnumerable<Tuple<string, int>> outer = null;
            var inner = new[] { Tuple.Create("name", 4), Tuple.Create("name3", 5) };
            ExceptionAssert.Throws<ArgumentNullException>(() => 
                outer.Join(
                    inner,
                    tuple => tuple.Item1,
                    tuple => tuple.Item1,
                    (outerElement, innerElement) => Tuple.Create(outerElement.Item2, innerElement.Item2)));
        }

        /// <summary>
        /// Joins a sequence with a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Joins a sequence with a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void JoinSequenceWithNull()
        {
            var outer = new[] { Tuple.Create("name", 4), Tuple.Create("name3", 5) };
            IEnumerable<Tuple<string, int>> inner = null;
            ExceptionAssert.Throws<ArgumentNullException>(() =>
                outer.Join(
                    inner,
                    tuple => tuple.Item1,
                    tuple => tuple.Item1,
                    (outerElement, innerElement) => Tuple.Create(outerElement.Item2, innerElement.Item2)));
        }

        /// <summary>
        /// Joins two sequences with a null selector for the outer sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Joins two sequences with a null selector for the outer sequence")]
        [Priority(1)]
        [TestMethod]
        public void JoinWithNullOuterSelector()
        {
            var outer = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3) };
            var inner = new[] { Tuple.Create("name", 4), Tuple.Create("name3", 5) };
            ExceptionAssert.Throws<ArgumentNullException>(() =>
                outer.Join(
                    inner,
                    null,
                    tuple => tuple.Item1,
                    (outerElement, innerElement) => Tuple.Create(outerElement.Item2, innerElement.Item2)));
        }

        /// <summary>
        /// Joins two sequences with a null selector for the inner sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Joins two sequences with a null selector for the inner sequence")]
        [Priority(1)]
        [TestMethod]
        public void JoinWithNullInnerSelector()
        {
            var outer = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3) };
            var inner = new[] { Tuple.Create("name", 4), Tuple.Create("name3", 5) };
            ExceptionAssert.Throws<ArgumentNullException>(() =>
                outer.Join(
                    inner,
                    tuple => tuple.Item1,
                    null,
                    (outerElement, innerElement) => Tuple.Create(outerElement.Item2, innerElement.Item2)));
        }

        /// <summary>
        /// Joins two sequences with a null result selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Joins two sequences with a null result selector")]
        [Priority(1)]
        [TestMethod]
        public void JoinWithNullResultSelector()
        {
            var outer = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3) };
            var inner = new[] { Tuple.Create("name", 4), Tuple.Create("name3", 5) };
            Func<Tuple<string, int>, Tuple<string, int>, Tuple<int, int>> resultSelector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() =>
                outer.Join(
                    inner,
                    tuple => tuple.Item1,
                    tuple => tuple.Item1,
                    resultSelector));
        }
    }
}
