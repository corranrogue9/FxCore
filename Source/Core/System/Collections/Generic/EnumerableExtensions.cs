namespace System.Collections.Generic
{
    using Fx;

    /// <summary>
    /// Extension methods for <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Creates a new instance of <see cref="ImmutableCollection{T}"/> from <paramref name="source"/>
        /// </summary>
        /// <typeparam name="T">The type of the elements in <paramref name="source"/></typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to create a <see cref="ImmutableCollection{T}"/> of</param>
        /// <returns>A new instance of <see cref="ImmutableCollection{T}"/> based on <paramref name="source"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static ImmutableCollection<T> ToImmutableCollection<T>(this IEnumerable<T> source)
        {
            Ensure.NotNull(source, nameof(source));

            return ImmutableCollection.Create(source);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ImmutableDictionary{TKey, TValue}"/> from <paramref name="source"/>
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the resulting <see cref="ImmutableDictionary{TKey, TValue}"/></typeparam>
        /// <typeparam name="TValue">The type of the values in the resulting <see cref="ImmutableDictionary{TKey, TValue}"/></typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to create a <see cref="ImmutableDictionary{TKey, TValue}"/> of</param>
        /// <returns>A new instance of <see cref="ImmutableDictionary{TKey, TValue}"/> based on <paramref name="source"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null or one of the elements within <paramref name="source"/> contain a null key</exception>
        /// <exception cref="ArgumentException">Thrown if two or more elements of <paramref name="source"/> contain the same key</exception>
        public static ImmutableDictionary<TKey, TValue> ToImmutableDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source)
        {
            Ensure.NotNull(source, nameof(source));

            return ImmutableDictionary.Create(source);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ImmutableList{T}"/> from <paramref name="source"/>
        /// </summary>
        /// <typeparam name="T">The type of the elements in <paramref name="source"/></typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to create a <see cref="ImmutableList{T}"/> of</param>
        /// <returns>A new instance of <see cref="ImmutableList{T}"/> based on <paramref name="source"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static ImmutableList<T> ToImmutableList<T>(this IEnumerable<T> source)
        {
            Ensure.NotNull(source, nameof(source));

            return ImmutableList.Create(source);
        }
    }
}
