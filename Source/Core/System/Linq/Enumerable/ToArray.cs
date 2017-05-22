#if !NET35
namespace System.Linq
{
    using System.Collections.Generic;

    using Fx;

    /// <summary>
    /// Provides a set of static methods for querying objects that implement <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static partial class Enumerable
    {
        /// <summary>
        /// Creates an array from a <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to create an array from</param>
        /// <returns>An array that contains the elements from the input sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source)
        {
            Ensure.NotNull(source, nameof(source));
            
            return ToList(source).ToArray();
        }
    }
}
#endif