#if !NET35
namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;

    using Fx;

    /// <summary>
    /// Provides a set of static methods for querying objects that implement <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static partial class Enumerable
    {
        /// <summary>
        /// Filters the elements of an <see cref="IEnumerable"/> based on a specified type
        /// </summary>
        /// <typeparam name="TResult">The type to filter the elements of the sequence on</typeparam>
        /// <param name="source">The <see cref="IEnumerable"/> whose elements to filter</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains elements from the input sequence of type <typeparamref name="TResult"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static IEnumerable<TResult> OfType<TResult>(this IEnumerable source)
        {
            Ensure.NotNull(source, nameof(source));

            return OfTypeIterator<TResult>(source);
        }

        /// <summary>
        /// Filters the elements of an <see cref="IEnumerable"/> based on a specified type
        /// </summary>
        /// <typeparam name="TResult">The type to filter the elements of the sequence on</typeparam>
        /// <param name="source">The <see cref="IEnumerable"/> whose elements to filter; assumed to not be null</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains elements from the input sequence of type <typeparamref name="TResult"/></returns>
        private static IEnumerable<TResult> OfTypeIterator<TResult>(IEnumerable source)
        {
            foreach (var element in source)
            {
                if (element is TResult)
                {
                    yield return (TResult)element;
                }
            }
        }
    }
}
#endif