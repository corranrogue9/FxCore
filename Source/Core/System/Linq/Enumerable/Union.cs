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
        /// Produces the set union of two sequences by using the default equality comparer
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the input sequences</typeparam>
        /// <param name="first">An <see cref="IEnumerable{T}"/> whose distinct elements form the first set for the union</param>
        /// <param name="second">An <see cref="IEnumerable{T}"/> whose distinct elements form the second set for the union</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains the elements from both input sequences, excluding duplicates</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="first"/> or <paramref name="second"/> is null</exception>
        public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            Ensure.NotNull(first, nameof(first));
            Ensure.NotNull(second, nameof(second));

            return UnionIterator(first, second, null);
        }

        /// <summary>
        /// Produces the set union of two sequences by using a specified <see cref="IEqualityComparer{T}"/>
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the input sequences</typeparam>
        /// <param name="first">An <see cref="IEnumerable{T}"/> whose distinct elements form the first set for the union</param>
        /// <param name="second">An <see cref="IEnumerable{T}"/> whose distinct elements form the second set for the union</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> to compare values</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains the elements from both input sequences, excluding duplicates</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="first"/> or <paramref name="second"/> is null</exception>
        public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            Ensure.NotNull(first, nameof(first));
            Ensure.NotNull(second, nameof(second));

            return UnionIterator(first, second, comparer);
        }

        /// <summary>
        /// Produces the set union of two sequences by using a specified <see cref="IEqualityComparer{T}"/>
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the input sequences</typeparam>
        /// <param name="first">An <see cref="IEnumerable{T}"/> whose distinct elements form the first set for the union; assumed to not be null</param>
        /// <param name="second">An <see cref="IEnumerable{T}"/> whose distinct elements form the second set for the union; assumed to not be null</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> to compare values</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains the elements from both input sequences, excluding duplicates</returns>
        private static IEnumerable<TSource> UnionIterator<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            var set = new Dictionary<TSource, bool>(comparer);
            foreach (var element in first)
            {
                if (!set.ContainsKey(element))
                {
                    set.Add(element, true);
                    yield return element;
                }
            }

            foreach (var element in second)
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