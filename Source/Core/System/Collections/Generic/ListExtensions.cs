namespace System.Collections.Generic
{
    using Fx;

    /// <summary>
    /// Extension methods for <see cref="IList{T}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static class ListExtensions
    {
        /// <summary>
        /// Adapts <paramref name="source"/> into a <see cref="ReadOnlyList{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of the elements in <paramref name="source"/></typeparam>
        /// <param name="source">The <see cref="IList{T}"/> to adapt into a <see cref="ReadOnlyList{T}"/></param>
        /// <returns>The <see cref="ReadOnlyList{T}"/> adapted from <paramref name="source"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static ReadOnlyList<T> ToReadOnlyList<T>(this IList<T> source)
        {
            Ensure.NotNull(source, nameof(source));

            return ReadOnlyList.Create(source);
        }
    }
}
