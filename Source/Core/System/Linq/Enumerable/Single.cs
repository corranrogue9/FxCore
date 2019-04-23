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
        /// Returns the only element of a sequence that satisfies a specified condition, and throws an exception if more than one such element exists
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return a single element from</param>
        /// <param name="predicate">A function to test an element for a condition</param>
        /// <returns>The single element of the input sequence that satisfies a condition</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="predicate"/> is null</exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if no element satisfies the condition in <paramref name="predicate"/> or more than one element satisfies the condition in <paramref name="predicate"/> or the source sequence is empty
        /// </exception>
        public static TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(predicate, nameof(predicate));

            return Single(WhereIterator(source, predicate));
        }

        /// <summary>
        /// Returns the only element of a sequence, and throws an exception if there is not exactly one element in the sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return the single element of</param>
        /// <returns>The single element of the input sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the input sequence contains more than one element or the input sequence is empty
        /// </exception>
        public static TSource Single<TSource>(this IEnumerable<TSource> source)
        {
            Ensure.NotNull(source, nameof(source));

            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    throw new InvalidOperationException(Strings.SingleEmpty);
                }

                var single = enumerator.Current;
                if (enumerator.MoveNext())
                {
                    throw new InvalidOperationException(Strings.SingleMultiple);
                }

                return single;
            }
        }

        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return a single element from</param>
        /// <param name="predicate">A function to test an element for a condition</param>
        /// <returns>The single element of the input sequence that satisfies the condition, or default(<typeparamref name="TSource"/>) if no such element is found</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="predicate"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if more than one element satisfies the condition in <paramref name="predicate"/></exception>
        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(predicate, nameof(predicate));

            return SingleOrDefault(WhereIterator(source, predicate));
        }
        
        /// <summary>
        /// Returns the only element of a sequence, or a default value if the sequence is empty; this method throws an exception if there is more than one element in the sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return the single element of</param>
        /// <returns>The single element of the input sequence, or default(<typeparamref name="TSource"/>) if the sequence contains no elements</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if the input sequence contains more than one element</exception>
        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            Ensure.NotNull(source, nameof(source));

            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    return default(TSource);
                }

                var single = enumerator.Current;
                if (enumerator.MoveNext())
                {
                    throw new InvalidOperationException(Strings.SingleMultiple);
                }

                return single;
            }
        }
    }
}
#endif