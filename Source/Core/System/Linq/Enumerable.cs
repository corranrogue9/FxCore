#if !NET35
namespace System.Linq
{
    using System.Collections.Generic;

    using Fx;

    /// <summary>
    /// Extensions methods <see cref="IEnumerable{T}"/> that mimic the behavior of <see cref="System.Linq.Enumerable"/> introduced in .NET 3.5
    /// </summary>
    /// <threadsafety static="true"/>
    internal static class Enumerable
    {
        /// <summary>
        /// Returns an empty <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of the elements that would be contained in the <see cref="IEnumerable{T}"/> if it were not empty</typeparam>
        /// <returns>An empty <see cref="IEnumerable{T}"/> whose type argument is <typeparamref name="T"/></returns>
        public static IEnumerable<T> Empty<T>()
        {
            return GenericEnumerable<T>.Empty;
        }

        /// <summary>
        /// Determines if <paramref name="source"/> has any elements in it
        /// </summary>
        /// <typeparam name="T">The type of the elements contained in <paramref name="source"/></typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to determine whether it has any elements</param>
        /// <returns>false if <paramref name="source"/> contains no elements, true otherwise</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        internal static bool Any<T>(this IEnumerable<T> source)
        {
            Ensure.NotNull(source, nameof(source));

            using (var enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Creates a <see cref="List{T}"/> from an <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of elements of <paramref name="source"/></typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to create a <see cref="List{T}"/> from</param>
        /// <returns>A <see cref="List{T}"/> that contains elements from the input sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        internal static List<T> ToList<T>(this IEnumerable<T> source)
        {
            Ensure.NotNull(source, nameof(source));

            return new List<T>(source);
        }

        /// <summary>
        /// Generates a sequence of integral numbers within a specified range
        /// </summary>
        /// <param name="start">The value of the first integer in the sequence</param>
        /// <param name="count">The number of sequential integers to generate</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains a range of sequential integral numbers</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="count"/> is less than 0, or <paramref name="start"/> + <paramref name="count"/> - 1 is larger than <see cref="int.MaxValue"/>
        /// </exception>
        internal static IEnumerable<int> Range(int start, int count)
        {
            Ensure.NotNegative(count, nameof(count));
            if (start + count - 1 > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }

            return RangeIterator(start, count);
        }

        /// <summary>
        /// Generates a sequence of integral numbers within a specified range
        /// </summary>
        /// <param name="start">The value of the first integer in the sequence</param>
        /// <param name="count">The number of sequential integers to generate</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains a range of sequential integral numbers</returns>
        /// <remarks>
        /// <paramref name="count"/> is assumed to be non-negative. <paramref name="start"/> + <paramref name="count"/> - 1 is assumed to be less than or equal to <see cref="int.MaxValue"/>
        /// </remarks>
        private static IEnumerable<int> RangeIterator(int start, int count)
        {
            for (int i = start; i < start + count; ++i)
            {
                yield return i;
            }
        }

        /// <summary>
        /// A helper class which uses a strongly-typed generic type on the class for caching purposes
        /// </summary>
        /// <typeparam name="T">The type of the elements in the <see cref="IEnumerable{T}"/>s that are cached in this helper</typeparam>
        /// <threadsafety static="true"/>
        private static class GenericEnumerable<T>
        {
            /// <summary>
            /// A <see cref="IEnumerable{T}"/> that contains no elements and is cached per type
            /// </summary>
            public static readonly IEnumerable<T> Empty = new T[0];
        }
    }
}
#endif
