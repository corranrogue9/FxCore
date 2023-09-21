namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IGroupByEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TResult> GroupBy<TKey, TElement, TResult>(
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IV2Enumerable<TElement>, TResult> resultSelector,
            IEqualityComparer<TKey>? comparer);
    }
}