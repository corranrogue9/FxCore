#if !NET35
namespace System.Linq
{
    using System.Collections.Generic;

    using Fx;

    /// <summary>
    /// Provides a set of static methods for querying objects that implement <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static partial class Enumerable
    {
        /// <summary>
        /// Generates a sequence of integral numbers within a specified range
        /// </summary>
        /// <param name="start">The value of the first integer in the sequence</param>
        /// <param name="count">The number of sequential integers to generate</param>
        /// <returns>An <see cref="IEnumerable{int32}"/> that contains a range of sequential integral numbers</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="count"/> is less than 0 or <paramref name="start"/> + <paramref name="count"/> - 1 is larger than <see cref="int.MaxValue"/>
        /// </exception>
        public static IEnumerable<int> Range(int start, int count)
        {
            Ensure.NotNegative(count, nameof(count));
            if ((long)start + count - 1 > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            return RangeIterator(start, count);
        }

        /// <summary>
        /// Generates a sequence of integral numbers within a specified range
        /// </summary>
        /// <param name="start">The value of the first integer in the sequence</param>
        /// <param name="count">The number of sequential integers to generate; assumed to be within positive integer range</param>
        /// <returns>An <see cref="IEnumerable{int32}"/> that contains a range of sequential integral numbers</returns>
        private static IEnumerable<int> RangeIterator(int start, int count)
        {
            for (int i = start; i < start + count; ++i)
            {
                yield return i;
            }
        }
    }
}
#endif