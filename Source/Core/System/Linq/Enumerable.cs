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
        /// Creates a <see cref="List{T}"/> from an <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of elements of <paramref name="source"/></typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to create a <see cref="List{T}"/> from</param>
        /// <returns>A <see cref="List{T}"/> that contains elements from the input sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        internal static List<T> ToList<T>(this IEnumerable<T> source)
        {
            Ensure.NotNull(source, nameof(source));

            return new List<T>(source);
        }

        /// <summary>
        /// Generates a sequence of integral numbers within a specified range
        /// </summary>
        /// <param name="start">The value of the first integer in the sequence</param>
        /// <param name="count">The number of sequential integers to generate</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains a range of sequential integral numbers</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="count"/> is less than 0, or <paramref name="start"/> + <paramref name="count"/> - 1 is larger than <see cref="int.MaxValue"/>
        /// </exception>
        internal static IEnumerable<int> Range(int start, int count)
        {
            Ensure.NotNegative(count, nameof(count));
            if (start + count - 1 > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }

            return RangeIterator(start, count);
        }

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
        /// Returns the number of elements in a sequence
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence that contains elements to be counted</param>
        /// <returns>The number of elements in the input sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="OverflowException">Thrown if the number of elements in <paramref name="source"/> is larger than <see cref="int.MaxValue"/></exception>
        internal static int Count<T>(this IEnumerable<T> source)
        {
            Ensure.NotNull(source, nameof(source));

            var count = 0;
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    ++count;
                }
            }

            return count;
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
        /// Projects each element of a sequence into a new form
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/></typeparam>
        /// <param name="source">A sequence of values to invoke a transform function on</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> whose elements are the result of invoking the transform function on each element of <paramref name="source"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        internal static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return SelectIterator(source, selector);
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
        /// Generates a sequence of integral numbers within a specified range
        /// </summary>
        /// <param name="start">The value of the first integer in the sequence</param>
        /// <param name="count">The number of sequential integers to generate</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains a range of sequential integral numbers</returns>
        /// <remarks>
        /// <paramref name="count"/> is assumed to be non-negative. <paramref name="start"/> + <paramref name="count"/> - 1 is assumed to be less than or equal to <see cref="int.MaxValue"/>
        /// </remarks>
        private static IEnumerable<int> RangeIterator(int start, int count)
        {
            for (int i = start; i < start + count; ++i)
            {
                yield return i;
            }
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

        /// <summary>
        /// Projects each element of a sequence into a new form
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/></typeparam>
        /// <param name="source">A sequence of values to invoke a transform function on</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> whose elements are the result of invoking the transform function on each element of <paramref name="source"/>
        /// </returns>
        /// <remarks><paramref name="source"/> is assumed to not be null. <paramref name="selector"/> is assumed to not be null</remarks>
        private static IEnumerable<TResult> SelectIterator<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (var element in source)
            {
                yield return selector(element);
            }
        }
    }
}
#endif
