namespace System.Collections.Generic
{
    using Fx;

    /// <summary>
    /// Factory methods for the <see cref="ReadOnlyCollection{T}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static class ReadOnlyCollection
    {
        /// <summary>
        /// Creates a new instance of <see cref="ReadOnlyCollection{T}"/> from <paramref name="source"/>
        /// </summary>
        /// <typeparam name="T">The type of the elements in <paramref name="source"/></typeparam>
        /// <param name="source">The <see cref="ICollection{T}"/> to create a <see cref="ReadOnlyCollection{T}"/> of</param>
        /// <returns>A new instance of <see cref="ReadOnlyCollection{T}"/> based on <paramref name="source"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static ReadOnlyCollection<T> Create<T>(ICollection<T> source)
        {
            Ensure.NotNull(source, nameof(source));

            return new ReadOnlyCollection<T>(source);
        }
    }
}
