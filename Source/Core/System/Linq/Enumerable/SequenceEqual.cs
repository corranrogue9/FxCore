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
        /// Determines whether two sequences are equal by comparing the elements by using the default equality comparer for their type
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the input sequences</typeparam>
        /// <param name="first">An <see cref="IEnumerable{T}"/> to compare to <paramref name="second"/></param>
        /// <param name="second">An <see cref="IEnumerable{T}"/> to compare to the first sequence</param>
        /// <returns>
        /// true if the two source sequences are of equal length and their corresponding elements are equal according to the default equality comparer for their type; 
        /// otherwise, false
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="first"/> or <paramref name="second"/> is null</exception>
        public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            Ensure.NotNull(first, nameof(first));
            Ensure.NotNull(second, nameof(second));

            return SequenceEqual(first, second, null);
        }

        /// <summary>
        /// Determines whether two sequences are equal by comparing their elements by using a specified <see cref="IEqualityComparer{T}"/>
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the input sequences</typeparam>
        /// <param name="first">An <see cref="IEnumerable{T}"/> to compare to <paramref name="second"/></param>
        /// <param name="second">An <see cref="IEnumerable{T}"/> to compare to the first sequence</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to use to compare elements</param>
        /// <returns>
        /// true if the two source sequences are of equal length and their corresponding elements compare equal according to <paramref name="comparer"/>; otherwise, 
        /// false
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="first"/> or <paramref name="second"/> is null</exception>
        public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            Ensure.NotNull(first, nameof(first));
            Ensure.NotNull(second, nameof(second));

            comparer = comparer ?? EqualityComparer<TSource>.Default;
            using (var firstEnumerator = first.GetEnumerator())
            using (var secondEnumerator = second.GetEnumerator())
            {
                while (true)
                {
                    var firstHasMore = firstEnumerator.MoveNext();
                    var secondHasMore = secondEnumerator.MoveNext();
                    if (firstHasMore == false && secondHasMore == false)
                    {
                        return true;
                    }

                    if (firstHasMore != secondHasMore)
                    {
                        return false;
                    }

                    if (!comparer.Equals(firstEnumerator.Current, secondEnumerator.Current))
                    {
                        return false;
                    }
                }
            }
        }
    }
}
#endif