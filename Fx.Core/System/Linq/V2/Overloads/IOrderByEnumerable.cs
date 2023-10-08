namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IOrderByEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2OrderedEnumerable<TSource> OrderBy<TKey>(Func<TSource, TKey> keySelector, IComparer<TKey>? comparer);
    }
}