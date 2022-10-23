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
        /*/// <summary>
        /// Returns a specified number of contiguous elements from the start of a sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">The sequence to return elements from</param>
        /// <param name="count">The number of elements to return</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains the specified number of elements from the start of the input sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static IReadOnlyCollection<TSource> Take<TSource>(this IReadOnlyCollection<TSource> source, int count)
        {
            Ensure.NotNull(source, nameof(source));

            return new ReadOnlyCollection<TSource>(
                source.Take(count),
                Math.Min(source.Count, count));
        }*/
    }
}
