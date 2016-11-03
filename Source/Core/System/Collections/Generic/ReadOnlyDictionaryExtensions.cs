namespace System.Collections.Generic
{
    /// <summary>
    /// Extension methods for <see cref="IReadOnlyDictionary{TKey, TValue}"/>s
    /// </summary>
    /// <threadsafety static="true"/>
    public static class ReadOnlyDictionaryExtensions
    {
        /// <summary>
        /// Returns <paramref name="dictionary"/> typed as <see cref="IReadOnlyDictionary{TKey, TValue}"/>
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in <paramref name="dictionary"/></typeparam>
        /// <typeparam name="TValue">The type of the values in <paramref name="dictionary"/></typeparam>
        /// <param name="dictionary">The sequence to type as <see cref="IReadOnlyDictionary{TKey, TValue}"/></param>
        /// <returns><paramref name="dictionary"/> typed as <see cref="IReadOnlyDictionary{TKey, TValue}"/></returns>
        public static IReadOnlyDictionary<TKey, TValue> AsReadOnlyDictionary<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary)
        {
            return dictionary;
        }
    }
}
