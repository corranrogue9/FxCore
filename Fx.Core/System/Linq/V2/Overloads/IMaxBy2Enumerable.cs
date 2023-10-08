namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IMaxBy2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource? MaxBy<TKey>(Func<TSource, TKey> keySelector, IComparer<TKey>? comparer);
    }
}