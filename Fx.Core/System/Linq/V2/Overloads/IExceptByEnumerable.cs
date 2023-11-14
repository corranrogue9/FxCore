namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IExceptByEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> ExceptBy<TKey>(IV2Enumerable<TKey> second, Func<TSource, TKey> keySelector);

        IV2Enumerable<TSource> ExceptBy<TKey>(
            IV2Enumerable<TKey> second,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey>? comparer);
    }
}