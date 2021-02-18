namespace System.Linq
{
    using System.Collections.Generic;

    using Fx;

    /// <summary>
    /// Provides a set of static methods for querying objects that implement <see cref="IReadOnlyCollection{T}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static partial class ReadOnlyCollectionExtensions
    {
        /// <summary>
        /// Inverts the order of the elements in a sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to reverse</param>
        /// <returns>A sequence whose elements correspond to those of the input sequence in reverse order</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static IReadOnlyCollection<TSource> Reverse<TSource>(this IReadOnlyCollection<TSource> source)
        {
            Ensure.NotNull(source, nameof(source));

            return new ReadOnlyCollection<TSource>(source.Reverse(), source.Count);
        }
    }
}
