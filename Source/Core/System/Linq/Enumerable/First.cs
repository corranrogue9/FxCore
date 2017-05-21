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
        /// Returns the first element of a sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to return the first element of</param>
        /// <returns>The first element in the specified sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if the source sequence is empty</exception>
        public static TSource First<TSource>(this IEnumerable<TSource> source)
        {
            Ensure.NotNull(source, nameof(source));

            var casted = source as IList<TSource>;
            if (casted != null && casted.Count > 0)
            {
                return casted[0];
            }

            return First(source, val => true); //// TODO singleton
        }

        /// <summary>
        /// Returns the first element in a sequence that satisfies a specified condition
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return an element from</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>The first element in the sequence that passes the test in the specified predicate function</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the source sequence is empty or no element satisfied the condition in <paramref name="predicate"/>
        /// </exception>
        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(predicate, nameof(predicate));

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    return element;
                }
            }

            throw new InvalidOperationException(Strings.FirstEmpty);
        }

        /// <summary>
        /// Returns the first element of a sequence, or a default value if the sequence contains no elements
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to return the first element of</param>
        /// <returns>default(<typeparamref name="TSource"/>) if <paramref name="source"/> is empty; otherwise, the first element in <paramref name="source"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            try
            {
                return First(source);
            }
            catch (InvalidOperationException)
            {
                return default(TSource);
            }
        }

        /// <summary>
        /// Returns the first element of the sequence that satisfies a condition or a default value if no such element is found
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return an element from</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>
        /// default(<typeparamref name="TSource"/>) if <paramref name="source"/> is empty or if no element passes the test specified by <paramref name="predicate"/>; 
        /// otherwise, the first element in <paramref name="source"/> that passes the test specified by <paramref name="predicate"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="predicate"/> is null</exception>
        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            try
            {
                return First(source, predicate);
            }
            catch (InvalidOperationException)
            {
                return default(TSource);
            }
        }
    }
}
#endif