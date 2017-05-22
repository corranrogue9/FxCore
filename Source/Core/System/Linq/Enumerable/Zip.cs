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
        /// Applies a specified function to the corresponding elements of two sequences, producing a sequence of the results
        /// </summary>
        /// <typeparam name="TFirst">The type of the elements of the first input sequence</typeparam>
        /// <typeparam name="TSecond">The type of the elements of the second input sequence</typeparam>
        /// <typeparam name="TResult">The type of the elements of the result sequence</typeparam>
        /// <param name="first">The first sequence to merge</param>
        /// <param name="second">The second sequence to merge</param>
        /// <param name="resultSelector">A function that specifies how to merge the elements from the two sequences</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains merged elements of two input sequences</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="first"/> or <paramref name="second"/> or <paramref name="resultSelector"/> is null
        /// </exception>
        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            Ensure.NotNull(first, nameof(first));
            Ensure.NotNull(second, nameof(second));
            Ensure.NotNull(resultSelector, nameof(resultSelector));

            return ZipIterator(first, second, resultSelector);
        }

        /// <summary>
        /// Applies a specified function to the corresponding elements of two sequences, producing a sequence of the results
        /// </summary>
        /// <typeparam name="TFirst">The type of the elements of the first input sequence</typeparam>
        /// <typeparam name="TSecond">The type of the elements of the second input sequence</typeparam>
        /// <typeparam name="TResult">The type of the elements of the result sequence</typeparam>
        /// <param name="first">The first sequence to merge; assumed to not be null</param>
        /// <param name="second">The second sequence to merge; assumed to not be null</param>
        /// <param name="resultSelector">A function that specifies how to merge the elements from the two sequences; assumed to not be null</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains merged elements of two input sequences</returns>
        private static IEnumerable<TResult> ZipIterator<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            using (var firstEnumerator = first.GetEnumerator())
            using (var secondEnumerator = second.GetEnumerator())
            {
                while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
                {
                    yield return resultSelector(firstEnumerator.Current, secondEnumerator.Current);
                }
            }
        }
    }
}
#endif