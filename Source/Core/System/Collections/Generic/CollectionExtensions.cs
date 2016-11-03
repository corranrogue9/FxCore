namespace System.Collections.Generic
{
    using Fx;

    /// <summary>
    /// Extension methods for <see cref="ICollection{T}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Adapts <paramref name="source"/> into a <see cref="ReadOnlyCollection{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of the elements in <paramref name="source"/></typeparam>
        /// <param name="source">The <see cref="ICollection{T}"/> to adapt into a <see cref="ReadOnlyCollection{T}"/></param>
        /// <returns>The <see cref="ReadOnlyCollection{T}"/> adapted from <paramref name="source"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static ReadOnlyCollection<T> ToReadOnlyCollection<T>(this ICollection<T> source)
        {
            Ensure.NotNull(source, nameof(source));

            return ReadOnlyCollection.Create(source);
        }
    }
}
