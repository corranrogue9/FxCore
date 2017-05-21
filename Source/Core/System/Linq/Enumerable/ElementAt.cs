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
        /// Returns the element at a specified index in a sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return an element from</param>
        /// <param name="index">The zero-based index of the element to retrieve</param>
        /// <returns>The element at the specified position in the source sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="index"/> is less than 0 or greater than or equal to the number of elements in <paramref name="source"/>
        /// </exception>
        public static TSource ElementAt<TSource>(this IEnumerable<TSource> source, int index)
        {
            Ensure.NotNull(source, nameof(source));

            var casted = source as IList<TSource>;
            if (casted != null)
            {
                return casted[index];
            }

            Ensure.NotNull(index, nameof(index));

            foreach (var element in source)
            {
                if (index-- == 0)
                {
                    return element;
                }
            }

            throw new ArgumentOutOfRangeException("index");
        }

        /// <summary>
        /// Returns the element at a specified index in a sequence or a default value if the index is out of range
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return an element from</param>
        /// <param name="index">The zero-based index of the element to retrieve</param>
        /// <returns>
        /// default(<typeparamref name="TSource"/>) if the index is outside the bounds of the source sequence; otherwise, the element at the specified position in the 
        /// source sequence
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static TSource ElementAtOrDefault<TSource>(this IEnumerable<TSource> source, int index)
        {
            Ensure.NotNull(source, nameof(source));
            if (index < 0)
            {
                return default(TSource);
            }

            var casted = source as IList<TSource>;
            if (casted != null && index >= casted.Count)
            {
                return default(TSource);
            }

            try
            {
                return ElementAt(source, index);
            }
            catch (ArgumentOutOfRangeException)
            {
                return default(TSource);
            }
        }
    }
}
#endif