namespace System.Collections.Generic
{
    using System.Linq;

    using Fx;

    /// <summary>
    /// Factory methods for the <see cref="ImmutableList{T}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static class ImmutableList
    {
        /// <summary>
        /// Returns an instance of a <see cref="ImmutableList{T}"/> that has no data in it
        /// </summary>
        /// <typeparam name="T">The type of elements in the resulting <see cref="ImmutableList{T}"/></typeparam>
        /// <returns>An instance of a <see cref="ImmutableList{T}"/> that has no data in it</returns>
        public static ImmutableList<T> Empty<T>()
        {
            return Internal<T>.Empty;
        }

        /// <summary>
        /// Creates a new instance of <see cref="ImmutableList{T}"/> from <paramref name="source"/>
        /// </summary>
        /// <typeparam name="T">The type of the elements in <paramref name="source"/></typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to create a <see cref="ImmutableList{T}"/> of</param>
        /// <returns>A new instance of <see cref="ImmutableList{T}"/> based on <paramref name="source"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static ImmutableList<T> Create<T>(IEnumerable<T> source)
        {
            Ensure.NotNull(source, nameof(source));

            return new ImmutableList<T>(source);
        }

        /// <summary>
        /// A generic-type internal class that contains singleton fields
        /// </summary>
        /// <typeparam name="T">The generic type used by the constituent singletons</typeparam>
        /// <threadsafety static="true"/>
        private static class Internal<T>
        {
            /// <summary>
            /// An instance of a <see cref="ImmutableList{T}"/> that has no data in it
            /// </summary>
            public static readonly ImmutableList<T> Empty = new ImmutableList<T>(Enumerable.Empty<T>());
        }
    }
}
