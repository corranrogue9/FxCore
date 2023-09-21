namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IDistinctBy2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> DistinctBy<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer);
    }
}