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
        /// Bypasses a specified number of elements in a sequence and then returns the remaining elements
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return elements from</param>
        /// <param name="count">The number of elements to skip before returning the remaining elements</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains the elements that occur after the specified index in the input sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, int count)
        {
            Ensure.NotNull(source, nameof(source));

            return SkipWhileIterator(source, (value, index) => index < count);
        }

        /// <summary>
        /// Bypasses elements in a sequence as long as a specified condition is true and then returns the remaining elements
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return elements from</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that contains the elements from the input sequence starting at the first element in the linear series that does not pass the
        /// test specified by <paramref name="predicate"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="predicate"/> is null</exception>
        public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(predicate, nameof(predicate));

            return SkipWhileIterator(source, predicate);
        }

        /// <summary>
        /// Bypasses elements in a sequence as long as a specified condition is true and then returns the remaining elements. The element's index is used in the logic 
        /// of the predicate function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return elements from</param>
        /// <param name="predicate">
        /// A function to test each source element for a condition; the second parameter of the function represents the index of the source element
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that contains the elements from the input sequence starting at the first element in the linear series that does not pass the
        /// test specified by <paramref name="predicate"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="predicate"/> is null</exception>
        /// <exception cref="OverflowException">Thrown if <paramref name="source"/> has more than <see cref="int.MaxValue"/> elements</exception>
        public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(predicate, nameof(predicate));

            return SkipWhileIterator(source, predicate);
        }

        /// <summary>
        /// Bypasses elements in a sequence as long as a specified condition is true and then returns the remaining elements
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return elements from; assumed to not be null</param>
        /// <param name="predicate">A function to test each element for a condition; assumed to not be null</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that contains the elements from the input sequence starting at the first element in the linear series that does not pass the
        /// test specified by <paramref name="predicate"/>
        /// </returns>
        private static IEnumerable<TSource> SkipWhileIterator<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (!predicate(enumerator.Current))
                    {
                        yield return enumerator.Current;
                        break;
                    }
                }

                while (enumerator.MoveNext())
                {
                    yield return enumerator.Current;
                }
            }
        }

        /// <summary>
        /// Bypasses elements in a sequence as long as a specified condition is true and then returns the remaining elements. The element's index is used in the logic 
        /// of the predicate function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return elements from; assumed to not be null</param>
        /// <param name="predicate">
        /// A function to test each source element for a condition; the second parameter of the function represents the index of the source element; assumed to not be
        /// null
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that contains the elements from the input sequence starting at the first element in the linear series that does not pass the
        /// test specified by <paramref name="predicate"/>
        /// </returns>
        private static IEnumerable<TSource> SkipWhileIterator<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            using (var enumerator = source.GetEnumerator())
            {
                checked
                {
                    for (int i = 0; enumerator.MoveNext(); ++i)
                    {
                        if (!predicate(enumerator.Current, i))
                        {
                            yield return enumerator.Current;
                            break;
                        }
                    }
                }

                while (enumerator.MoveNext())
                {
                    yield return enumerator.Current;
                }
            }
        }
    }
}
#endif