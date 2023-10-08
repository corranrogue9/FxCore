namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IGroupBy7Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<IV2Grouping<TKey, TSource>> GroupBy<TKey>(
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey>? comparer);
    }
}