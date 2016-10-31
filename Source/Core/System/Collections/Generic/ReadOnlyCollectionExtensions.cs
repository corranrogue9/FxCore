namespace System.Collections.Generic
{
    /// <summary>
    /// Extension methods for <see cref="IReadOnlyCollection{T}"/>s
    /// </summary>
    /// <threadsafety static="true"/>
    public static class ReadOnlyCollectionExtensions
    {
        /// <summary>
        /// Returns <paramref name="collection"/> typed as <see cref="IReadOnlyCollection{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of the elements in <paramref name="collection"/></typeparam>
        /// <param name="collection">The sequence to type as <see cref="IReadOnlyCollection{T}"/></param>
        /// <returns><paramref name="collection"/> typed as <see cref="IReadOnlyCollection{T}"/></returns>
        public static IReadOnlyCollection<T> AsReadOnlyCollection<T>(this IReadOnlyCollection<T> collection)
        {
            return collection;
        }
    }
}
