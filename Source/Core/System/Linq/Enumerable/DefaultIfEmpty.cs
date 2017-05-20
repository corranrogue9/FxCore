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
        /// Returns the elements of the specified sequence or the type parameter's default value in a singleton collection if the sequence is empty
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">The sequence to return a default value for if it is empty</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> object that contains the default value for the <typeparamref name="TSource"/> type if <paramref name="source"/> is empty; 
        /// otherwise, <paramref name="source"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source)
        {
            Ensure.NotNull(source, nameof(source));

            return DefaultIfEmptyIterator(source, default(TSource));
        }

        /// <summary>
        /// Returns the elements of the specified sequence or the specified value in a singleton collection if the sequence is empty
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">The sequence to return the specified value for if it is empty</param>
        /// <param name="defaultValue">The value to return if the sequence is empty</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that contains <paramref name="defaultValue"/> if <paramref name="source"/> is empty; otherwise, <paramref name="source"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source, TSource defaultValue)
        {
            Ensure.NotNull(source, nameof(source));

            return DefaultIfEmptyIterator(source, defaultValue);
        }

        /// <summary>
        /// Returns the elements of the specified sequence or the specified value in a singleton collection if the sequence is empty
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">The sequence to return the specified value for if it is empty; assumed to not be null</param>
        /// <param name="defaultValue">The value to return if the sequence is empty</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that contains <paramref name="defaultValue"/> if <paramref name="source"/> is empty; otherwise, <paramref name="source"/>
        /// </returns>
        private static IEnumerable<TSource> DefaultIfEmptyIterator<TSource>(this IEnumerable<TSource> source, TSource defaultValue)
        {
            using (var enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    do
                    {
                        yield return enumerator.Current;
                    }
                    while (enumerator.MoveNext());
                }
                else
                {
                    yield return defaultValue;
                }
            }
        }
    }
}
#endif