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
        /// Filters a sequence of values based on a predicate
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to filter</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains elements from the input sequence that satisfy the condition</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="predicate"/> is null</exception>
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(predicate, nameof(predicate));

            return WhereIterator(source, predicate);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate. Each element's index is used in the logic of the predicate function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to filter</param>
        /// <param name="predicate">
        /// A function to test each source element for a condition; the second parameter of the function represents the index of the source element
        /// </param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains elements from the input sequence that satisfy the condition</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="predicate"/> is null</exception>
        /// <exception cref="OverflowException">Thrown if the number of elements in <paramref name="source"/> is larger than <see cref="int.MaxValue"/></exception>
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(predicate, nameof(predicate));

            return WhereIterator(source, predicate);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to filter; assumed to not be null</param>
        /// <param name="predicate">A function to test each element for a condition; assumed to not be null</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains elements from the input sequence that satisfy the condition</returns>
        private static IEnumerable<TSource> WhereIterator<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var element in source)
            {
                if (predicate(element))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate. Each element's index is used in the logic of the predicate function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to filter; assumed to not be null</param>
        /// <param name="predicate">
        /// A function to test each source element for a condition; the second parameter of the function represents the index of the source element; assumed to not be 
        /// null
        /// </param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains elements from the input sequence that satisfy the condition</returns>
        private static IEnumerable<TSource> WhereIterator<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            using (var enumerator = source.GetEnumerator())
            {
                int i = 0;
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current, i))
                    {
                        yield return enumerator.Current;
                    }

                    checked
                    {
                        ++i;
                    }
                }
            }
        }
    }
}
#endif