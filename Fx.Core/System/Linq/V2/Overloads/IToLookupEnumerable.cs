namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IToLookupEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Lookup<TKey, TElement> ToLookup<TKey, TElement>(
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey>? comparer);
    }
}