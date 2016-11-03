namespace System.Collections.Generic
{
    using Fx;

    /// <summary>
    /// Extension methods for <see cref="IDictionary{TKey, TValue}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Adapts <paramref name="source"/> into a <see cref="ReadOnlyDictionary{TKey, TValue}"/>
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in <paramref name="source"/></typeparam>
        /// <typeparam name="TValue">The type of the values in <paramref name="source"/></typeparam>
        /// <param name="source">The <see cref="IDictionary{TKey, TValue}"/> to adapt into a <see cref="ReadOnlyDictionary{TKey, TValue}"/></param>
        /// <returns>The <see cref="ReadOnlyDictionary{TKey, TValue}"/> adapted from <paramref name="source"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static ReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(this IDictionary<TKey, TValue> source)
        {
            Ensure.NotNull(source, nameof(source));

            return ReadOnlyDictionary.Create(source);
        }
    }
}
