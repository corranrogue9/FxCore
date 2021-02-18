namespace System.Linq
{
    using System.Collections.Generic;

    using Fx;

    /// <summary>
    /// Provides a set of static methods for querying objects that implement <see cref="IReadOnlyCollection{T}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static partial class ReadOnlyCollectionExtensions
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
        public static IReadOnlyCollection<TResult> Select<TSource, TResult>(this IReadOnlyCollection<TSource> source, Func<TSource, TResult> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return new ReadOnlyCollection<TResult>(source.Select(selector), source.Count);
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
        /// <exception cref="OverflowException">Thrown if <paramref name="source"/> has more than <see cref="int.MaxValue"/> elements</exception>
        public static IReadOnlyCollection<TResult> Select<TSource, TResult>(this IReadOnlyCollection<TSource> source, Func<TSource, int, TResult> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return new ReadOnlyCollection<TResult>(source.Select(selector), source.Count);
        }
    }
}
