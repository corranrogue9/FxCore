namespace System.Linq
{
    using System.Collections.Generic;

    using Fx;

    /// <summary>
    /// Provides a set of static methods for querying objects that implement <see cref="IReadOnlyCollection{T}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static partial class ReadOnlyCollectionExtensions
    {
        /*/// <summary>
        /// Generates a sequence that contains one repeated value
        /// </summary>
        /// <typeparam name="TResult">The type of the value to be repeated in the result sequence</typeparam>
        /// <param name="element">The value to be repeated</param>
        /// <param name="count">The number of times to repeat the value in the generated sequence</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains a repeated value</returns>
        public static IReadOnlyCollection<TResult> Repeat<TResult>(TResult element, int count)
        {
            Ensure.NotNegative(count, nameof(count));

            return new ReadOnlyCollection<TResult>(Enumerable.Repeat(element, count), count);
        }*/
    }
}
