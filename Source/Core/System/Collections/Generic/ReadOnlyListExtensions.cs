namespace System.Collections.Generic
{
    /// <summary>
    /// Extension methods for <see cref="IReadOnlyList{T}"/>s
    /// </summary>
    /// <threadsafety static="true"/>
    public static class ReadOnlyListExtensions
    {
        /// <summary>
        /// Returns <paramref name="list"/> typed as <see cref="IReadOnlyList{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of the elements in <paramref name="list"/></typeparam>
        /// <param name="list">The sequence to type as <see cref="IReadOnlyList{T}"/></param>
        /// <returns><paramref name="list"/> typed as <see cref="IReadOnlyList{T}"/></returns>
        public static IReadOnlyList<T> AsReadOnlyList<T>(this IReadOnlyList<T> list)
        {
            return list;
        }
    }
}
