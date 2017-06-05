#if !NET35
namespace System.Linq
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines an indexer, size property, and Boolean search method for data structures that map keys to <see cref="IEnumerable{T}"/> sequences of values
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the <see cref="ILookup{TKey, TElement}"/></typeparam>
    /// <typeparam name="TElement">The type of the elements in the <see cref="IEnumerable{T}"/> sequences that make up the values in the <see cref="ILookup{TKey, TElement}"/></typeparam>
    /// <threadsafety instance="true"/>
    public interface ILookup<TKey, TElement> : IEnumerable<IGrouping<TKey, TElement>>
    {
        /// <summary>
        /// Gets the number of key/value collection pairs in the <see cref="ILookup{TKey, TElement}"/>
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets the <see cref="IEnumerable{T}"/> sequence of values indexed by a specified key
        /// </summary>
        /// <param name="key">The key of the desired sequence of values</param>
        /// <returns>The <see cref="IEnumerable{T}"/> sequence of values indexed by the specified key</returns>
        IEnumerable<TElement> this[TKey key] { get; }

        /// <summary>
        /// Determines whether a specified key exists in the <see cref="ILookup{TKey, TElement}"/>
        /// </summary>
        /// <param name="key">The key to search for in the <see cref="ILookup{TKey, TElement}"/></param>
        /// <returns>true if <paramref name="key"/> is in the <see cref="ILookup{TKey, TElement}"/>; otherwise, false</returns>
        bool Contains(TKey key);
    }
}
#endif