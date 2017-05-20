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
        /// Returns distinct elements from a sequence by using the default equality comparer to compare values
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">The sequence to remove duplicate elements from</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains distinct elements from the source sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source)
        {
            Ensure.NotNull(source, nameof(source));

            return DistinctIterator(source, null);
        }

        /// <summary>
        /// Returns distinct elements from a sequence by using a specified <see cref="IEqualityComparer{T}"/> to compare values
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">The sequence to remove duplicate elements from</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare values; null indicates to use the default <see cref="IEqualityComparer{T}"/></param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains distinct elements from the source sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
        {
            Ensure.NotNull(source, nameof(source));

            return DistinctIterator(source, comparer);
        }

        /// <summary>
        /// Returns distinct elements from a sequence by using a specified <see cref="IEqualityComparer{T}"/> to compare values
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">The sequence to remove duplicate elements from; assumed to not be null</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare values; null indicates to use the default <see cref="IEqualityComparer{T}"/></param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains distinct elements from the source sequence</returns>
        private static IEnumerable<TSource> DistinctIterator<TSource>(IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
        {
            var set = new Dictionary<TSource, bool>(comparer);
            foreach (var element in source)
            {
                if (!set.ContainsKey(element))
                {
                    set.Add(element, true);
                    yield return element;
                }
            }
        }
    }
}
#endif