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
         /// Produces the set intersection of two sequences by using the default equality comparer to compare values
         /// </summary>
         /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
         /// <param name="first">An <see cref="IEnumerable{T}"/> whose distinct elements that also appear in <paramref name="second"/> will be returned</param>
         /// <param name="second">An <see cref="IEnumerable{T}"/> whose distinct elements that also appear in the first sequence will be returned</param>
         /// <returns>A sequence that contains the elements that form the set intersection of two sequences</returns>
         /// <exception cref="ArgumentNullException">Thrown if <paramref name="first"/> or <paramref name="second"/> is null</exception>
        public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            Ensure.NotNull(first, nameof(first));
            Ensure.NotNull(second, nameof(second));

            return IntersectIterator(first, second, null);
        }

        /// <summary>
        /// Produces the set intersection of two sequences by using the specified <see cref="IEqualityComparer{T}"/> to compare values
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the input sequences</typeparam>
        /// <param name="first">An <see cref="IEnumerable{T}"/> whose distinct elements that also appear in <paramref name="second"/> will be returned</param>
        /// <param name="second">An <see cref="IEnumerable{T}"/> whose distinct elements that also appear in the first sequence will be returned</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare values</param>
        /// <returns>A sequence that contains the elements that form the set intersection of two sequences</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="first"/> or <paramref name="second"/> is null</exception>
        public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            Ensure.NotNull(first, nameof(first));
            Ensure.NotNull(second, nameof(second));

            return IntersectIterator(first, second, comparer);
        }

        /// <summary>
        /// Produces the set intersection of two sequences by using the specified <see cref="IEqualityComparer{T}"/> to compare values
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the input sequences</typeparam>
        /// <param name="first">
        /// An <see cref="IEnumerable{T}"/> whose distinct elements that also appear in <paramref name="second"/> will be returned; assumed to not be null
        /// </param>
        /// <param name="second">
        /// An <see cref="IEnumerable{T}"/> whose distinct elements that also appear in the first sequence will be returned; assumed to not be null
        /// </param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare values</param>
        /// <returns>A sequence that contains the elements that form the set intersection of two sequences</returns>
        private static IEnumerable<TSource> IntersectIterator<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            var set = new Dictionary<TSource, bool>(comparer);
            foreach (var element in second)
            {
                set[element] = true;
            }

            foreach (var element in first)
            {
                if (set.Remove(element))
                {
                    yield return element;
                }
            }
        }
    }
}
#endif