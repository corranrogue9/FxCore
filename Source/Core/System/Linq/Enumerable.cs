#if !NET35
namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;

    using Fx;

    /// <summary>
    /// Extensions methods <see cref="IEnumerable{T}"/> that mimic the behavior of <see cref="System.Linq.Enumerable"/> introduced in .NET 3.5; provides a set of static methods for querying objects that implement <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static partial class Enumerable
    {
        /// <summary>
        /// Filters the elements of an <see cref="IEnumerable"/> based on a specified type.
        /// </summary>
        /// <typeparam name="T">The type to filter the elements of the sequence on</typeparam>
        /// <param name="source">The <see cref="IEnumerable"/> whose elements to filter</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains elements from the input sequence of type <typeparamref name="T"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        internal static IEnumerable<T> OfType<T>(this IEnumerable source)
        {
            Ensure.NotNull(source, nameof(source));

            return OfTypeIterator<T>(source);
        }
        
        /// <summary>
        /// Returns the first element of a sequence
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to return the first element of</param>
        /// <returns>The first element in the specified sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if the source sequence is empty</exception>
        internal static T First<T>(this IEnumerable<T> source)
        {
            Ensure.NotNull(source, nameof(source));

            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    throw new InvalidOperationException("TODO");
                }

                return enumerator.Current;
            }
        }

        /// <summary>
        /// Returns the element at a specified index in a sequence
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return an element from</param>
        /// <param name="index">The zero-based index of the element to retrieve</param>
        /// <returns>The element at the specified position in the source sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is less than 0 or greater than or equal to the number of elements in <paramref name="source"/></exception>
        internal static T ElementAt<T>(this IEnumerable<T> source, int index)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNegative(index, nameof(index));

            using (var enumerator = source.GetEnumerator())
            {
                for (int i = 0; i < index && enumerator.MoveNext(); ++i)
                {
                }

                if (!enumerator.MoveNext())
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                return enumerator.Current;
            }
        }
        
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

        /// <summary>
        /// Filters the elements of an <see cref="IEnumerable"/> based on a specified type.
        /// </summary>
        /// <typeparam name="T">The type to filter the elements of the sequence on</typeparam>
        /// <param name="source">The <see cref="IEnumerable"/> whose elements to filter</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains elements from the input sequence of type <typeparamref name="T"/></returns>
        /// <remarks><paramref name="source"/> is assumed to not be null</remarks>
        private static IEnumerable<T> OfTypeIterator<T>(IEnumerable source)
        {
            foreach (var element in source)
            {
                if (element is T)
                {
                    yield return (T)element;
                }
            }
        }
    }
}
#endif
