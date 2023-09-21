namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IGroupBy3Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TResult> GroupBy<TKey, TResult>(
            Func<TSource, TKey> keySelector,
            Func<TKey, IV2Enumerable<TSource>, TResult> resultSelector,
            IEqualityComparer<TKey>? comparer);
    }
}