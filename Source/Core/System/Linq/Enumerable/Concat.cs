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
        /// Concatenates two sequences
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the input sequences</typeparam>
        /// <param name="first">The first sequence to concatenate</param>
        /// <param name="second">The sequence to concatenate to the first sequence</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains the concatenated elements of the two input sequences</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="first"/> or <paramref name="second"/> is null</exception>
        public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            Ensure.NotNull(first, nameof(first));
            Ensure.NotNull(second, nameof(second));

            return ConcatIterator(first, second);
        }

        /// <summary>
        /// Concatenates two sequences
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the input sequences</typeparam>
        /// <param name="first">The first sequence to concatenate; assumed to not be null</param>
        /// <param name="second">The sequence to concatenate to the first sequence; assumed to not be null</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains the concatenated elements of the two input sequences</returns>
        private static IEnumerable<TSource> ConcatIterator<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            foreach (var element in first)
            {
                yield return element;
            }

            foreach (var element in second)
            {
                yield return element;
            }
        }
    }
}
#endif