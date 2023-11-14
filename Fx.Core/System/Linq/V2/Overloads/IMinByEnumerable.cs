namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IMinByEnumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource? MinBy<TKey>(Func<TSource, TKey> keySelector, IComparer<TKey>? comparer);

        TSource? MinBy<TKey>(Func<TSource, TKey> keySelector);
    }
}