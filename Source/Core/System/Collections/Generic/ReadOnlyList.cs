namespace System.Collections.Generic
{
    using Fx;

    /// <summary>
    /// Factory methods for the <see cref="ReadOnlyList{T}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static class ReadOnlyList
    {
        /// <summary>
        /// Creates a new instance of <see cref="ReadOnlyList{T}"/> from <paramref name="source"/>
        /// </summary>
        /// <typeparam name="T">The type of the elements in <paramref name="source"/></typeparam>
        /// <param name="source">The <see cref="IList{T}"/> to create a <see cref="ReadOnlyList{T}"/> of</param>
        /// <returns>A new instance of <see cref="ReadOnlyList{T}"/> based on <paramref name="source"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static ReadOnlyList<T> Create<T>(IList<T> source)
        {
            Ensure.NotNull(source, nameof(source));

            return new ReadOnlyList<T>(source);
        }
    }
}
