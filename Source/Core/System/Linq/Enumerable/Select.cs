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
        /// Projects each element of a sequence into a new form
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/></typeparam>
        /// <param name="source">A sequence of values to invoke a transform function on</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> whose elements are the result of invoking the transform function on each element of <paramref name="source"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return SelectIterator(source, selector);
        }

        /// <summary>
        /// Projects each element of a sequence into a new form by incorporating the element's index
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/></typeparam>
        /// <param name="source">A sequence of values to invoke a transform function on</param>
        /// <param name="selector">
        /// A transform function to apply to each source element; the second parameter of the function represents the index of the source element
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> whose elements are the result of invoking the transform function on each element of <paramref name="source"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return SelectIterator(source, selector);
        }

        /// <summary>
        /// Projects each element of a sequence into a new form
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/></typeparam>
        /// <param name="source">A sequence of values to invoke a transform function on; assumed to not be null</param>
        /// <param name="selector">A transform function to apply to each element; assumed to not be null</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> whose elements are the result of invoking the transform function on each element of <paramref name="source"/>
        /// </returns>
        private static IEnumerable<TResult> SelectIterator<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return SelectIterator(source, (value, index) => selector(value));
        }

        /// <summary>
        /// Projects each element of a sequence into a new form by incorporating the element's index
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/></typeparam>
        /// <param name="source">
        /// A sequence of values to invoke a transform function on; assumed to not be null</param>
        /// <param name="selector">
        /// A transform function to apply to each source element; the second parameter of the function represents the index of the source element; assumed to not be null
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> whose elements are the result of invoking the transform function on each element of <paramref name="source"/>
        /// </returns>
        private static IEnumerable<TResult> SelectIterator<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
        {
            using (var enumerator = source.GetEnumerator())
            {
                for (int i = 0; enumerator.MoveNext(); ++i)
                {
                    yield return selector(enumerator.Current, i);
                }
            }
        }
    }
}
#endif