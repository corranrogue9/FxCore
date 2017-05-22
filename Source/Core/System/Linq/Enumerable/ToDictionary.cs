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
        /// Creates a <see cref="Dictionary{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> according to a specified key selector function
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to create a <see cref="Dictionary{TKey, TValue}"/> from</param>
        /// <param name="keySelector">A function to extract a key from each element</param>
        /// <returns>A <see cref="Dictionary{TKey, TValue}"/> that contains keys and values</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="source"/> or <paramref name="keySelector"/> is null, or <paramref name="keySelector"/> produces a key that is null
        /// </exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="keySelector"/> produces duplicate keys from two elements</exception>
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(keySelector, nameof(keySelector));

            //// TODO singleton
            return ToDictionary(source, keySelector, value => value, null);
        }

        /// <summary>
        /// Creates a <see cref="Dictionary{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> according to a specified key selector function and key comparer
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TKey">The type of the keys returned by <paramref name="keySelector"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to create a <see cref="Dictionary{TKey, TValue}"/> from</param>
        /// <param name="keySelector">A function to extract a key from each element</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare keys</param>
        /// <returns>A <see cref="Dictionary{TKey, TValue}"/> that contains keys and values</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="source"/> or <paramref name="keySelector"/> is null, or <paramref name="keySelector"/> produces a key that is null
        /// </exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="keySelector"/> produces duplicate keys from two elements</exception>
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> comparer)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(keySelector, nameof(keySelector));

            //// TODO singleton
            return ToDictionary(source, keySelector, value => value, comparer);
        }

        /// <summary>
        /// Creates a <see cref="Dictionary{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> according to specified key selector and element selector functions
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/></typeparam>
        /// <typeparam name="TElement">The type of the value returned by <paramref name="elementSelector"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to create a <see cref="Dictionary{TKey, TValue}"/> from</param>
        /// <param name="keySelector">A function to extract a key from each element</param>
        /// <param name="elementSelector">A transform function to produce a result element value from each element</param>
        /// <returns>A <see cref="Dictionary{TKey, TValue}"/> that contains values of type <typeparamref name="TElement"/> selected from the input sequence</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="elementSelector"/> is null, or <paramref name="keySelector"/> 
        /// produces a key that is null
        /// </exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="keySelector"/> produces duplicate keys from two elements</exception>
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(keySelector, nameof(keySelector));
            Ensure.NotNull(elementSelector, nameof(elementSelector));

            return ToDictionary(source, keySelector, elementSelector, null);
        }

        /// <summary>
        /// Creates a <see cref="Dictionary{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> according to a specified key selector function, a comparer, and an 
        /// element selector function
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/></typeparam>
        /// <typeparam name="TElement">The type of the value returned by <paramref name="elementSelector"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to create a <see cref="Dictionary{TKey, TValue}"/> from</param>
        /// <param name="keySelector">A function to extract a key from each element</param>
        /// <param name="elementSelector">A transform function to produce a result element value from each element</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare keys</param>
        /// <returns>A <see cref="Dictionary{TKey, TValue}"/> that contains values of type <typeparamref name="TElement"/> selected from the input sequence</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="elementSelector"/> is null, or <paramref name="keySelector"/> 
        /// produces a key that is null
        /// </exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="keySelector"/> produces duplicate keys from two elements</exception>
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey> comparer)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(keySelector, nameof(keySelector));
            Ensure.NotNull(elementSelector, nameof(elementSelector));

            var dictionary = new Dictionary<TKey, TElement>(comparer);
            foreach (var element in source)
            {
                dictionary.Add(keySelector(element), elementSelector(element));
            }

            return dictionary;
        }
    }
}
#endif