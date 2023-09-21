namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IGroupBy8Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<IV2Grouping<TKey, TElement>> GroupBy<TKey, TElement>(
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey>? comparer);
    }
}