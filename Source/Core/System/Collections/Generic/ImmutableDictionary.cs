namespace System.Collections.Generic
{
    using System.Linq;

    using Fx;

    /// <summary>
    /// Factory methods for the <see cref="ImmutableDictionary{TKey, TValue}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static class ImmutableDictionary
    {
        /// <summary>
        /// Returns an instance of a <see cref="ImmutableDictionary{TKey, TValue}"/> that has no data in it
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the resulting <see cref="ImmutableDictionary{TKey, TValue}"/></typeparam>
        /// <typeparam name="TValue">The type of the values in the resulting <see cref="ImmutableDictionary{TKey, TValue}"/></typeparam>
        /// <returns>An instance of a <see cref="ImmutableDictionary{TKey, TValue}"/> that has no data in it</returns>
        public static ImmutableDictionary<TKey, TValue> Empty<TKey, TValue>()
        {
            return Internal<TKey, TValue>.Empty;
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
        public static ImmutableDictionary<TKey, TValue> Create<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> source)
        {
            Ensure.NotNull(source, nameof(source));

            return new ImmutableDictionary<TKey, TValue>(source);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ImmutableDictionary{TKey, TValue}"/> from <paramref name="source"/>
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the resulting <see cref="ImmutableDictionary{TKey, TValue}"/></typeparam>
        /// <typeparam name="TValue">The type of the values in the resulting <see cref="ImmutableDictionary{TKey, TValue}"/></typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to create a <see cref="ImmutableDictionary{TKey, TValue}"/> of</param>
        /// <param name="equalityComparer">
        /// The <see cref="IEqualityComparer{T}"/> that should be used for determining if two keys are the same within the resulting <see cref="ImmutableDictionary{TKey, TValue}"/>
        /// </param>
        /// <returns>A new instance of <see cref="ImmutableDictionary{TKey, TValue}"/> based on <paramref name="source"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="equalityComparer"/> is null or one of the elements within <paramref name="source"/> contain a null key</exception>
        /// <exception cref="ArgumentException">Thrown if two or more elements of <paramref name="source"/> contain the same key</exception>
        public static ImmutableDictionary<TKey, TValue> Create<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey> equalityComparer)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(equalityComparer, nameof(equalityComparer));

            return new ImmutableDictionary<TKey, TValue>(source, equalityComparer);
        }

        /// <summary>
        /// A generic-type internal class that contains singleton fields
        /// </summary>
        /// <typeparam name="TKey">The generic key type used by the constituent singletons</typeparam>
        /// <typeparam name="TValue">The generic value type used by the constituent singletons</typeparam>
        /// <threadsafety static="true"/>
        private static class Internal<TKey, TValue>
        {
            /// <summary>
            /// An instance of a <see cref="ImmutableDictionary{TKey, TValue}"/> that has no data in it
            /// </summary>
            public static readonly ImmutableDictionary<TKey, TValue> Empty = new ImmutableDictionary<TKey, TValue>(Enumerable.Empty<KeyValuePair<TKey, TValue>>());
        }
    }
}
