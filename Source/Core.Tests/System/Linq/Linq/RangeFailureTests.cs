namespace System.Linq
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for <see cref="Enumerable.Range(int, int)"/> implementations
    /// </summary>
    public sealed class RangeFailureTests
    {
        public RangeFailureTests()
        {
        }

        /// <summary>
        /// Gets a range with a negative count
        /// </summary>
        /// <param name="range">The implementation of range that is under test</param>
        /// <exception cref="AssertFailedException">Thrown if <paramref name="range"/> does not pass the test</exception>
        public void RangeNegative(Func<int, int, IEnumerable<int>> range)
        {
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => range(10, -1));
        }

        /// <summary>
        /// Gets a range that will go out of bounds of an integer
        /// </summary>
        /// <param name="range">The implementation of range that is under test</param>
        /// <exception cref="AssertFailedException">Thrown if <paramref name="range"/> does not pass the test</exception>
        public void RangeMassive(Func<int, int, IEnumerable<int>> range)
        {
            range(10, int.MaxValue - 9);
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => range(10, int.MaxValue - 8));
        }
    }
}
