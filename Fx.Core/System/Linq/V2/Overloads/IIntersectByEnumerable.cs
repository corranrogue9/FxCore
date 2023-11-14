namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IIntersectByEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> IntersectBy<TKey>(IV2Enumerable<TKey> second, Func<TSource, TKey> keySelector);

        IV2Enumerable<TSource> IntersectBy<TKey>(
            IV2Enumerable<TKey> second,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey>? comparer);
    }
}