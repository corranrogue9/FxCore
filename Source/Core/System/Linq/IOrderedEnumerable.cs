#if !NET35
namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a sorted sequence
    /// </summary>
    /// <typeparam name="TElement">The type of the elements of the sequence</typeparam>
    /// <threadsafety instance="true"/>
    public interface IOrderedEnumerable<TElement> : IEnumerable<TElement>, IEnumerable
    {
        /// <summary>
        /// Performs a subsequent ordering on the elements of an <see cref="IOrderedEnumerable{TElement}"/> according to a key
        /// </summary>
        /// <typeparam name="TKey">The type of the key produced by <paramref name="keySelector"/></typeparam>
        /// <param name="keySelector">The <see cref="Func{T, TResult}"/> used to extract the key for each element</param>
        /// <param name="comparer">The <see cref="IComparer{T}"/> used to compare keys for placement in the returned sequence; null indicates that the default <see cref="IComparer{T}"/> should be used</param>
        /// <param name="descending">true to sort the elements in descending order; false to sort the elements in ascending order</param>
        /// <returns>An <see cref="IOrderedEnumerable{TElement}"/> whose elements are sorted according to a key</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="keySelector"/> is null</exception>
        IOrderedEnumerable<TElement> CreateOrderedEnumerable<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey> comparer, bool descending);
    }
}
#endif