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
        /// Determines whether a sequence contains a specified element by using the default equality comparer
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence in which to locate a value</param>
        /// <param name="value">The value to locate in the sequence</param>
        /// <returns>true if the source sequence contains an element that has the specified value; otherwise, false</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value)
        {
            Ensure.NotNull(source, nameof(source));

            var casted = source as ICollection<TSource>;
            if (casted != null)
            {
                return casted.Contains(value);
            }

            return Contains(source, value, null);
        }

        /// <summary>
        /// Determines whether a sequence contains a specified element by using a specified <see cref="IEqualityComparer{T}"/>
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence in which to locate a value</param>
        /// <param name="value">The value to locate in the sequence</param>
        /// <param name="comparer">An equality comparer to compare values</param>
        /// <returns>true if the source sequence contains an element that has the specified value; otherwise, false</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
        {
            Ensure.NotNull(source, nameof(source));

            if (comparer == null)
            {
                comparer = EqualityComparer<TSource>.Default;
            }

            foreach (var element in source)
            {
                if (comparer.Equals(value, element))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
#endif