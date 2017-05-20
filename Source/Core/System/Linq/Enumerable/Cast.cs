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
        /// Casts the elements of an <see cref="IEnumerable"/> to the specified type
        /// </summary>
        /// <typeparam name="TResult">The type to cast the elements of <paramref name="source"/> to</typeparam>
        /// <param name="source">The <see cref="IEnumerable"/> that contains the elements to be cast to type <typeparamref name="TResult"/></param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains each element of the source sequence cast to the specified type</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="InvalidCastException">Thrown if an element in the sequence cannot be cast to type <typeparamref name="TResult"/></exception>
        public static IEnumerable<TResult> Cast<TResult>(this IEnumerable source)
        {
            Ensure.NotNull(source, nameof(source));

            var casted = source as IEnumerable<TResult>;
            if (casted != null)
            {
                return casted;
            }

            return CastIterator<TResult>(source);
        }

        /// <summary>
        /// Casts the elements of an <see cref="IEnumerable"/> to the specified type
        /// </summary>
        /// <typeparam name="TResult">The type to cast the elements of <paramref name="source"/> to</typeparam>
        /// <param name="source">
        /// The <see cref="IEnumerable"/> that contains the elements to be cast to type <typeparamref name="TResult"/>; assumed to not be null
        /// </param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains each element of the source sequence cast to the specified type</returns>
        /// <exception cref="InvalidCastException">Thrown if an element in the sequence cannot be cast to type <typeparamref name="TResult"/></exception>
        private static IEnumerable<TResult> CastIterator<TResult>(IEnumerable source)
        {
            foreach (var element in source)
            {
                yield return (TResult)element;
            }
        }
    }
}
#endif