#if !NET35
namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;

    using Fx;

    /// <summary>
    /// Provides a set of static methods for querying objects that implement <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static partial class Enumerable
    {
        /// <summary>
        /// Returns the number of elements in a sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence that contains elements to be counted</param>
        /// <returns>The number of elements in the input sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="OverflowException">Thrown if the number of elements in <paramref name="source"/> is larger than <see cref="int.MaxValue"/></exception>
        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            Ensure.NotNull(source, nameof(source));

            var genericCollection = source as ICollection<TSource>;
            if (genericCollection != null)
            {
                return genericCollection.Count;
            }

            var collection = source as ICollection;
            if (collection != null)
            {
                return collection.Count;
            }

            return Count(source, value => true); //// TODO singelton
        }

        /// <summary>
        /// Returns a number that represents how many elements in the specified sequence satisfy a condition
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence that contains elements to be tested and counted</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>A number that represents how many elements in the sequence satisfy the condition in the predicate function</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="OverflowException">Thrown if the number of elements in <paramref name="source"/> is larger than <see cref="int.MaxValue"/></exception>
        public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(predicate, nameof(predicate));

            var count = 0;
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