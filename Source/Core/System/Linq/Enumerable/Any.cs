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
        /// Determines whether a sequence contains any elements
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> ` check for emptiness</param>
        /// <returns>true if the source sequence contains any elements; otherwise, false</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static bool Any<TSource>(this IEnumerable<TSource> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Any(source, val => true);
        }

        /// <summary>
        /// Determines whether any element of a sequence satisfies a condition
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to apply the predicate to</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>true if any elements in the source sequence pass the test in the specified predicate; otherwise, false</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="predicate"/> is null</exception>
        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(predicate, nameof(predicate));

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
#endif