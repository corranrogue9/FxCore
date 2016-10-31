namespace System.Collections.Generic
{
    using System.Linq;

    using Fx;

    /// <summary>
    /// Factory methods for the <see cref="ImmutableCollection{T}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static class ImmutableCollection
    {
        /// <summary>
        /// Returns an instance of a <see cref="ImmutableCollection{T}"/> that has no data in it
        /// </summary>
        /// <typeparam name="T">The type of elements in the resulting <see cref="ImmutableCollection{T}"/></typeparam>
        /// <returns>An instance of a <see cref="ImmutableCollection{T}"/> that has no data in it</returns>
        public static ImmutableCollection<T> Empty<T>()
        {
            return Internal<T>.Empty;
        }

        /// <summary>
        /// Creates a new instance of <see cref="ImmutableCollection{T}"/> from <paramref name="source"/>
        /// </summary>
        /// <typeparam name="T">The type of the elements in <paramref name="source"/></typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to create a <see cref="ImmutableCollection{T}"/> of</param>
        /// <returns>A new instance of <see cref="ImmutableCollection{T}"/> based on <paramref name="source"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static ImmutableCollection<T> Create<T>(IEnumerable<T> source)
        {
            Ensure.NotNull(source, nameof(source));

            return new ImmutableCollection<T>(source);
        }

        /// <summary>
        /// A generic-type internal class that contains singleton fields
        /// </summary>
        /// <typeparam name="T">The generic type used by the constituent singletons</typeparam>
        /// <threadsafety static="true"/>
        private static class Internal<T>
        {
            /// <summary>
            /// An instance of a <see cref="ImmutableCollection{T}"/> that has no data in it
            /// </summary>
            public static readonly ImmutableCollection<T> Empty = new ImmutableCollection<T>(Enumerable.Empty<T>());
        }
    }
}
