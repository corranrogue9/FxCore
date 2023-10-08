namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IUnionBy2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> UnionBy<TKey>(
            IV2Enumerable<TSource> second,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey>? comparer);
    }
}