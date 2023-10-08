namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IToLookup4Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Lookup<TKey, TSource> ToLookup<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer);
    }
}