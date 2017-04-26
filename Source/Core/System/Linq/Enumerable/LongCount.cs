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
        /// Returns an <see cref="System.Int64"/> that represents the total number of elements in a sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> that contains the elements to be counted</param>
        /// <returns>The number of elements in the source sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="OverflowException">Thrown if the number of elements exceeds <see cref="long.MaxValue"/></exception>
        public static long LongCount<TSource>(this IEnumerable<TSource> source)
        {
            Ensure.NotNull(source, nameof(source));
            
            return LongCount(source, val => true);
        }

        /// <summary>
        /// Returns an <see cref="System.Int64"/> that represents how many elements in a sequence satisfy a condition
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> that contains the elements to be counted</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>A number that represents how many elements in the sequence satisfy the condition in the predicate function</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="predicate"/> is null</exception>
        /// <exception cref="OverflowException">Thrown if the number of matching elements exceeds <see cref="long.MaxValue"/></exception>
        public static long LongCount<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(predicate, nameof(predicate));

            var count = 0L;
            checked
            {
                foreach (var element in source)
                {
                    if (predicate(element))
                    {
                        ++count;
                    }
                }
            }

            return count;
        }
    }
}
#endif