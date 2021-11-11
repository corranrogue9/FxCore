namespace System.Linq
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public sealed class RangeUnitTests
    {
        public RangeUnitTests()
        {
        }

        /// <summary>
        /// Gets a range
        /// </summary>
        /// <param name="range">The implementation of range that is under test</param>
        /// <exception cref="AssertFailedException">Thrown if <paramref name="range"/> does not pass the test</exception>
        public void Range(Func<int, int, IEnumerable<int>> range)
        {
            CollectionAssert.AreEqual(new[] { 10, 11, 12, 13, 14 }, range(10, 5).ToList());
        }

        /// <summary>
        /// Gets an empty range
        /// </summary>
        /// <param name="range">The implementation of range that is under test</param>
        /// <exception cref="AssertFailedException">Thrown if <paramref name="range"/> does not pass the test</exception>
        public void RangeEmpty(Func<int, int, IEnumerable<int>> range)
        {
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), range(10, 0).ToList());
        }

        /// <summary>
        /// Gets a range with a single element
        /// </summary>
        /// <param name="range">The implementation of range that is under test</param>
        /// <exception cref="AssertFailedException">Thrown if <paramref name="range"/> does not pass the test</exception>
        public void RangeSingle(Func<int, int, IEnumerable<int>> range)
        {
            CollectionAssert.AreEqual(new[] { 10 }, range(10, 1).ToList());
        }
    }
}
