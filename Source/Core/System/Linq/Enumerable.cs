#if !NET35
namespace System.Linq
{
    using System.Collections.Generic;

    using Fx;

    /// <summary>
    /// Extensions methods <see cref="IEnumerable{T}"/> that mimic the behavior of <see cref="System.Linq.Enumerable"/> introduced in .NET 3.5; provides a set of static methods for querying objects that implement <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static partial class Enumerable
    {
        /// <summary>
        /// Creates an array from a <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to create an array from</param>
        /// <returns>An array that contains the elements from the input sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        internal static T[] ToArray<T>(this IEnumerable<T> source)
        {
            Ensure.NotNull(source, nameof(source));

            return source.ToList().ToArray();
        }
    }
}
#endif
