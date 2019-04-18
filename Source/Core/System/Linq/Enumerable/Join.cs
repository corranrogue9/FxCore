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
        /// Correlates the elements of two sequences based on matching keys. The default equality comparer is used to compare keys
        /// </summary>
        /// <typeparam name="TOuter">The type of the elements of the first sequence</typeparam>
        /// <typeparam name="TInner">The type of the elements of the second sequence</typeparam>
        /// <typeparam name="TKey">The type of the keys returned by the key selector functions</typeparam>
        /// <typeparam name="TResult">The type of the result elements</typeparam>
        /// <param name="outer">The first sequence to join</param>
        /// <param name="inner">The sequence to join to the first sequence</param>
        /// <param name="outerKeySelector">A function to extract the join key from each element of the first sequence</param>
        /// <param name="innerKeySelector">A function to extract the join key from each element of the second sequence</param>
        /// <param name="resultSelector">A function to create a result element from two matching elements</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that has elements of type <typeparamref name="TResult"/> that are obtained by performing an inner join on two sequences</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="outer"/> or <paramref name="inner"/> or <paramref name="outerKeySelector"/> or <paramref name="innerKeySelector"/> or <paramref name="resultSelector"/> is null</exception>
        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
        {
            return Join(outer, inner, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default);
        }

        /// <summary>
        /// Correlates the elements of two sequences based on matching keys. A specified <see cref="IEqualityComparer{T}"/> is used to compare keys
        /// </summary>
        /// <typeparam name="TOuter">The type of the elements of the first sequence</typeparam>
        /// <typeparam name="TInner">The type of the elements of the second sequence</typeparam>
        /// <typeparam name="TKey">The type of the keys returned by the key selector functions</typeparam>
        /// <typeparam name="TResult">The type of the result elements</typeparam>
        /// <param name="outer">The first sequence to join</param>
        /// <param name="inner">The sequence to join to the first sequence</param>
        /// <param name="outerKeySelector">A function to extract the join key from each element of the first sequence</param>
        /// <param name="innerKeySelector">A function to extract the join key from each element of the second sequence</param>
        /// <param name="resultSelector">A function to create a result element from two matching elements</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to hash and compare keys</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that has elements of type <typeparamref name="TResult"/> that are obtained by performing an inner join on two sequences</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="outer"/> or <paramref name="inner"/> or <paramref name="outerKeySelector"/> or <paramref name="innerKeySelector"/> or <paramref name="resultSelector"/> is null</exception>
        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            Ensure.NotNull(outer, nameof(outer));
            Ensure.NotNull(inner, nameof(inner));
            Ensure.NotNull(outerKeySelector, nameof(outerKeySelector));
            Ensure.NotNull(innerKeySelector, nameof(innerKeySelector));
            Ensure.NotNull(resultSelector, nameof(resultSelector));

            return JoinIterator(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer ?? EqualityComparer<TKey>.Default);
        }

        /// <summary>
        /// Correlates the elements of two sequences based on matching keys. A specified <see cref="IEqualityComparer{T}"/> is used to compare keys
        /// </summary>
        /// <typeparam name="TOuter">The type of the elements of the first sequence</typeparam>
        /// <typeparam name="TInner">The type of the elements of the second sequence</typeparam>
        /// <typeparam name="TKey">The type of the keys returned by the key selector functions</typeparam>
        /// <typeparam name="TResult">The type of the result elements</typeparam>
        /// <param name="outer">The first sequence to join; assumed to not be null</param>
        /// <param name="inner">The sequence to join to the first sequence; assumed to not be null</param>
        /// <param name="outerKeySelector">A function to extract the join key from each element of the first sequence; assumed to not be null</param>
        /// <param name="innerKeySelector">A function to extract the join key from each element of the second sequence; assumed to not be null</param>
        /// <param name="resultSelector">A function to create a result element from two matching elements; assumed to not be null</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to hash and compare keys; assumed to not be null</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that has elements of type <typeparamref name="TResult"/> that are obtained by performing an inner join on two sequences</returns>
        private static IEnumerable<TResult> JoinIterator<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            var innerLookup = ToLookup(inner.Where(element => innerKeySelector(element) != null), innerKeySelector, comparer);
            foreach (var outerElement in outer)
            {
                var outerKey = outerKeySelector(outerElement);
                foreach (var innerElement in innerLookup[outerKey])
                {
                    yield return resultSelector(outerElement, innerElement);
                }
            }
        }
    }
}
#endif