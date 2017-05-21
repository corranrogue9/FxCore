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
        /// Produces the set difference of two sequences by using the default equality comparer to compare values
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the input sequences</typeparam>
        /// <param name="first">An <see cref="IEnumerable{T}"/> whose elements that are not also in <paramref name="second"/> will be returned</param>
        /// <param name="second">
        /// An <see cref="IEnumerable{T}"/> whose elements that also occur in the first sequence will cause those elements to be removed from the returned sequence
        /// </param>
        /// <returns>A sequence that contains the set difference of the elements of two sequences</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="first"/> or <paramref name="second"/> is null</exception>
        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            Ensure.NotNull(first, nameof(first));
            Ensure.NotNull(second, nameof(second));

            return ExceptIterator(first, second, null);
        }

        /// <summary>
        /// Produces the set difference of two sequences by using the specified <see cref="IEqualityComparer{T}"/> to compare values
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the input sequences</typeparam>
        /// <param name="first">An <see cref="IEnumerable{T}"/> whose elements that are not also in <paramref name="second"/> will be returned</param>
        /// <param name="second">
        /// An <see cref="IEnumerable{T}"/> whose elements that also occur in the first sequence will cause those elements to be removed from the returned sequence
        /// </param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare values</param>
        /// <returns>A sequence that contains the set difference of the elements of two sequences</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="first"/> or <paramref name="second"/> is null</exception>
        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            Ensure.NotNull(first, nameof(first));
            Ensure.NotNull(second, nameof(second));

            return ExceptIterator(first, second, comparer);
        }

        /// <summary>
        /// Produces the set difference of two sequences by using the specified <see cref="IEqualityComparer{T}"/> to compare values
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the input sequences</typeparam>
        /// <param name="first">
        /// An <see cref="IEnumerable{T}"/> whose elements that are not also in <paramref name="second"/> will be returned; assumed to not be null
        /// </param>
        /// <param name="second">
        /// An <see cref="IEnumerable{T}"/> whose elements that also occur in the first sequence will cause those elements to be removed from the returned sequence; 
        /// assumed to not be null
        /// </param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare values</param>
        /// <returns>A sequence that contains the set difference of the elements of two sequences</returns>
        private static IEnumerable<TSource> ExceptIterator<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            var set = new Dictionary<TSource, bool>(comparer);
            foreach (var element in second)
            {
                set.Add(element, true);
            }

            foreach (var element in first)
            {
                if (!set.ContainsKey(element))
                {
                    yield return element;
                }
            }
        }
    }
}
#endif