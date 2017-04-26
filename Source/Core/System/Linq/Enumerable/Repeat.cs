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
        /// Generates a sequence that contains one repeated value
        /// </summary>
        /// <typeparam name="TResult">The type of the value to be repeated in the result sequence</typeparam>
        /// <param name="element">The value to be repeated</param>
        /// <param name="count">The number of times to repeat the value in the generated sequence</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains a repeated value</returns>
        public static IEnumerable<TResult> Repeat<TResult>(TResult element, int count)
        {
            Ensure.NotNegative(count, nameof(count));

            return RepeatIterator(element, count);
        }

        /// <summary>
        /// Generates a sequence that contains one repeated value
        /// </summary>
        /// <typeparam name="TResult">The type of the value to be repeated in the result sequence</typeparam>
        /// <param name="element">The value to be repeated</param>
        /// <param name="count">The number of times to repeat the value in the generated sequence; assumed to be non-negative</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains a repeated value</returns>
        private static IEnumerable<TResult> RepeatIterator<TResult>(TResult element, int count)
        {
            for (int i = 0; i < count; ++i)
            {
                yield return element;
            }
        }
    }
}
#endif