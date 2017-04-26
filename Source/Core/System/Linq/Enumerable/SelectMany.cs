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
        /// Projects each element of a sequence to an <see cref="IEnumerable{T}"/> and flattens the resulting sequences into one sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TResult">The type of the elements of the sequence returned by <paramref name="selector"/></typeparam>
        /// <param name="source">A sequence of values to project</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> whose elements are the result of invoking the one-to-many transform function on each element of the input sequence
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return SelectManyIterator(source, (value, index) => selector(value), (val1, val2) => val2);
        }

        /// <summary>
        /// Projects each element of a sequence to an <see cref="IEnumerable{T}"/>, and flattens the resulting sequences into one sequence. The index of each source 
        /// element is used in the projected form of that element.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TResult">The type of the elements of the sequence returned by <paramref name="selector"/></typeparam>
        /// <param name="source">A sequence of values to project</param>
        /// <param name="selector">
        /// A transform function to apply to each source element; the second parameter of the function represents the index of the source element
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> whose elements are the result of invoking the one-to-many transform function on each element of an input sequence
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return SelectManyIterator(source, selector, (val1, val2) => val2);
        }

        /// <summary>
        /// Projects each element of a sequence to an <see cref="IEnumerable{T}"/>, flattens the resulting sequences into one sequence, and invokes a result selector 
        /// function on each element therein
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TCollection">The type of the intermediate elements collected by <paramref name="collectionSelector"/></typeparam>
        /// <typeparam name="TResult">The type of the elements of the resulting sequence</typeparam>
        /// <param name="source">A sequence of values to project</param>
        /// <param name="collectionSelector">A transform function to apply to each element of the input sequence</param>
        /// <param name="resultSelector">A transform function to apply to each element of the intermediate sequence</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> whose elements are the result of invoking the one-to-many transform function <paramref name="collectionSelector"/> on each 
        /// element of <paramref name="source"/> and then mapping each of those sequence elements and their corresponding source element to a result element
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="source"/> or <paramref name="collectionSelector"/> or <paramref name="resultSelector"/> is null
        /// </exception>
        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(collectionSelector, nameof(collectionSelector));
            Ensure.NotNull(resultSelector, nameof(resultSelector));

            return SelectManyIterator(source, (value, index) => collectionSelector(value), resultSelector);
        }

        /// <summary>
        /// Projects each element of a sequence to an <see cref="IEnumerable{T}"/>, flattens the resulting sequences into one sequence, and invokes a result selector 
        /// function on each element therein. The index of each source element is used in the intermediate projected form of that element
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TCollection">The type of the intermediate elements collected by <paramref name="collectionSelector"/></typeparam>
        /// <typeparam name="TResult">The type of the elements of the resulting sequence</typeparam>
        /// <param name="source">A sequence of values to project</param>
        /// <param name="collectionSelector">
        /// A transform function to apply to each source element; the second parameter of the function represents the index of the source element
        /// </param>
        /// <param name="resultSelector">A transform function to apply to each element of the intermediate sequence</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> whose elements are the result of invoking the one-to-many transform function <paramref name="collectionSelector"/> on each 
        /// element of <paramref name="source"/> and then mapping each of those sequence elements and their corresponding source element to a result element
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="source"/> or <paramref name="collectionSelector"/> or <paramref name="resultSelector"/> is null
        /// </exception>
        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, int, IEnumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(collectionSelector, nameof(collectionSelector));
            Ensure.NotNull(resultSelector, nameof(resultSelector));

            return SelectManyIterator(source, collectionSelector, resultSelector);
        }

        /// <summary>
        /// Projects each element of a sequence to an <see cref="IEnumerable{T}"/>, flattens the resulting sequences into one sequence, and invokes a result selector 
        /// function on each element therein. The index of each source element is used in the intermediate projected form of that element
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TCollection">The type of the intermediate elements collected by <paramref name="collectionSelector"/></typeparam>
        /// <typeparam name="TResult">The type of the elements of the resulting sequence</typeparam>
        /// <param name="source">A sequence of values to project; assumed to not be null</param>
        /// <param name="collectionSelector">
        /// A transform function to apply to each source element; the second parameter of the function represents the index of the source element; assumed to not be null
        /// </param>
        /// <param name="resultSelector">A transform function to apply to each element of the intermediate sequence; assumed to not be null</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> whose elements are the result of invoking the one-to-many transform function <paramref name="collectionSelector"/> on each 
        /// element of <paramref name="source"/> and then mapping each of those sequence elements and their corresponding source element to a result element
        /// </returns>
        private static IEnumerable<TResult> SelectManyIterator<TSource, TCollection, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, int, IEnumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector)
        {
            using (var enumerator = source.GetEnumerator())
            {
                for (int i = 0; enumerator.MoveNext(); ++i)
                {
                    foreach (var element in collectionSelector(enumerator.Current, i).Select(value => resultSelector(enumerator.Current, value)))
                    {
                        yield return element;
                    }
                }
            }
        }
    }
}
#endif