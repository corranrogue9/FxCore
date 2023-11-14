namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IMaxByEnumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource? MaxBy<TKey>(Func<TSource, TKey> keySelector);

        TSource? MaxBy<TKey>(Func<TSource, TKey> keySelector, IComparer<TKey>? comparer);
    }
}