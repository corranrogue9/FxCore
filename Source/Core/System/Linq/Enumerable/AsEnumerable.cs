#if !NET35
namespace System.Linq
{
    using System.Collections.Generic;

    /// <summary>
    /// Provides a set of static methods for querying objects that implement <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static partial class Enumerable
    {
        /// <summary>
        /// Returns the input types as <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">The sequence to type as <see cref="IEnumerable{T}"/></param>
        /// <returns>The input sequence typed as <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<TSource> AsEnumerable<TSource>(this IEnumerable<TSource> source)
        {
            return source;
        }
    }
}
#endif