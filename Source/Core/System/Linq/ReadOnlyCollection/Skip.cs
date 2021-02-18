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
        /// Bypasses a specified number of elements in a sequence and then returns the remaining elements
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return elements from</param>
        /// <param name="count">The number of elements to skip before returning the remaining elements</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains the elements that occur after the specified index in the input sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static IReadOnlyCollection<TSource> Skip<TSource>(this IReadOnlyCollection<TSource> source, int count)
        {
            Ensure.NotNull(source, nameof(source));

            return new ReadOnlyCollection<TSource>(
                source.Skip(count),
                Math.Max(source.Count - count, 0));
        }
    }
}
