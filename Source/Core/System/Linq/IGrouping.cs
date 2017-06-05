#if !NET35
namespace System.Linq
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a collection of objects that have a common key
    /// </summary>
    /// <typeparam name="TKey">The type of the key of the <see cref="IGrouping{TKey, TElement}"/></typeparam>
    /// <typeparam name="TElement">The type of the values in the <see cref="IGrouping{TKey, TElement}"/></typeparam>
    /// <threadsafety instance="true"/>
    public interface IGrouping<out TKey,
#if NET40
        out TElement>
#else
        TElement>
#endif
        : IEnumerable<TElement>
    {
        /// <summary>
        /// Gets the key of the <see cref="IGrouping{TKey, TElement}"/>
        /// </summary>
        TKey Key { get; }
    }
}
#endif