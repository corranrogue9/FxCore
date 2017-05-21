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
        /// Returns the last element of a sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return the last element of</param>
        /// <returns>The value at the last position in the source sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> is empty</exception>
        public static TSource Last<TSource>(this IEnumerable<TSource> source)
        {
            Ensure.NotNull(source, nameof(source));

            var casted = source as IList<TSource>;
            if (casted != null && casted.Count > 0)
            {
                return casted[casted.Count - 1];
            }

            return Last(source, val => true); //// TODO singleton
        }

        /// <summary>
        /// Returns the last element of a sequence that satisfies a specified condition
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return an element from</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>The last element in the sequence that passes the test in the specified predicate function</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="predicate"/> is null</exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if no element satisfies the condition in <paramref name="predicate"/> or <paramref name="source"/> is empty
        /// </exception>
        public static TSource Last<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(predicate, nameof(predicate));

            var found = false;
            TSource result = default(TSource);
            foreach (var element in source)
            {
                if (predicate(element))
                {
                    result = element;
                    found = true;
                }
            }

            if (found)
            {
                return result;
            }

            throw new InvalidOperationException(Strings.LastEmpty);
        }

        /// <summary>
        /// Returns the last element of a sequence, or a default value if the sequence contains no elements
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return the last element of</param>
        /// <returns>default(<typeparamref name="TSource"/>) if the source sequence is empty; otherwise, the last element in the <see cref="IEnumerable{T}"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            Ensure.NotNull(source, nameof(source));

            try
            {
                return Last(source);
            }
            catch (InvalidOperationException)
            {
                return default(TSource);
            }
        }

        /// <summary>
        /// Returns the last element of a sequence that satisfies a condition or a default value if no such element is found
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return an element from</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>
        /// default(<typeparamref name="TSource"/>) if the sequence is empty or if no elements pass the test in the predicate function; otherwise, the last element that
        /// passes the test in the predicate function
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="predicate"/> is empty</exception>
        public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(predicate, nameof(predicate));

            try
            {
                return Last(source, predicate);
            }
            catch (InvalidOperationException)
            {
                return default(TSource);
            }
        }
    }
}
#endif