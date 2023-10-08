namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IOrderByDescending2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2OrderedEnumerable<TSource> OrderByDescending<TKey>(
            Func<TSource, TKey> keySelector,
            IComparer<TKey>? comparer);
    }
}