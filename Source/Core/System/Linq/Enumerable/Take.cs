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
        /// Returns a specified number of contiguous elements from the start of a sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">The sequence to return elements from</param>
        /// <param name="count">The number of elements to return</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains the specified number of elements from the start of the input sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, int count)
        {
            Ensure.NotNull(source, nameof(source));

            return TakeWhileIterator(source, (value, index) => index < count);
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence to return elements from</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that contains the elements from the input sequence that occur before the element at which the test no longer passes
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="predicate"/> is null</exception>
        public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(predicate, nameof(predicate));

            return TakeWhileIterator(source, predicate);
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true. The element's index is used in the logic of the predicate function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">The sequence to return elements from</param>
        /// <param name="predicate">
        /// A function to test each source element for a condition; the second parameter of the function represents the index of the source element
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that contains elements from the input sequence that occur before the element at which the test no longer passes
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="predicate"/> is null</exception>
        /// <exception cref="OverflowException">Thrown if <paramref name="source"/> has more than <see cref="int.MaxValue"/> elements</exception>
        public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(predicate, nameof(predicate));

            return TakeWhileIterator(source, predicate);
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence to return elements from; assumed to not be null</param>
        /// <param name="predicate">A function to test each element for a condition; assumed to not be null</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that contains the elements from the input sequence that occur before the element at which the test no longer passes
        /// </returns>
        private static IEnumerable<TSource> TakeWhileIterator<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext() && predicate(enumerator.Current))
                {
                    yield return enumerator.Current;
                }
            }
        }
        
        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true. The element's index is used in the logic of the predicate function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">The sequence to return elements from; assumed to not be null</param>
        /// <param name="predicate">
        /// A function to test each source element for a condition; the second parameter of the function represents the index of the source element; assumed to not be 
        /// null
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that contains elements from the input sequence that occur before the element at which the test no longer passes
        /// </returns>
        /// <exception cref="OverflowException">Thrown if <paramref name="source"/> has more than <see cref="int.MaxValue"/> elements</exception>
        private static IEnumerable<TSource> TakeWhileIterator<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            using (var enumerator = source.GetEnumerator())
            {
                checked
                {
                    for (int i = 0; enumerator.MoveNext() && predicate(enumerator.Current, i); ++i)
                    {
                        yield return enumerator.Current;
                    }
                }
            }
        }
    }
}
#endif