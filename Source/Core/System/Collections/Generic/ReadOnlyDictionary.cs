namespace System.Collections.Generic
{
    using Fx;

    /// <summary>
    /// Factory methods for the <see cref="ReadOnlyDictionary{TKey, TValue}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static class ReadOnlyDictionary
    {
        /// <summary>
        /// Creates a new instance of <see cref="ReadOnlyDictionary{TKey, TValue}"/> from <paramref name="source"/>
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in <paramref name="source"/></typeparam>
        /// <typeparam name="TValue">The type of the values in <paramref name="source"/></typeparam>
        /// <param name="source">The <see cref="IDictionary{TKey, TValue}"/> to create a <see cref="ReadOnlyDictionary{TKey, TValue}"/> of</param>
        /// <returns>A new instance of <see cref="ReadOnlyDictionary{TKey, TValue}"/> based on <paramref name="source"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static ReadOnlyDictionary<TKey, TValue> Create<TKey, TValue>(IDictionary<TKey, TValue> source)
        {
            Ensure.NotNull(source, nameof(source));

            return new ReadOnlyDictionary<TKey, TValue>(source);
        }
    }
}
