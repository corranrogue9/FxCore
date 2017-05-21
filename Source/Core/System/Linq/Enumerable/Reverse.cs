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
        /// Inverts the order of the elements in a sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to reverse</param>
        /// <returns>A sequence whose elements correspond to those of the input sequence in reverse order</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> source)
        {
            Ensure.NotNull(source, nameof(source));

            return ReverseIterator(source);
        }

        /// <summary>
        /// Inverts the order of the elements in a sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to reverse; assumed to not be null</param>
        /// <returns>A sequence whose elements correspond to those of the input sequence in reverse order</returns>
        private static IEnumerable<TSource> ReverseIterator<TSource>(this IEnumerable<TSource> source)
        {
            var data = source.ToList();
            for (int i = data.Count - 1; i >= 0; --i)
            {
                yield return data[i];
            }
        }
    }
}
#endif