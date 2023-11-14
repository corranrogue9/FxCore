namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IToDictionaryEnumerable<TSource> : IV2Enumerable<TSource>
    {
        Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector)
            where TKey : notnull;

        Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey>? comparer)
            where TKey : notnull;

        Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
            where TKey : notnull;

        Dictionary<TKey, TSource> ToDictionary<TKey>(
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey>? comparer)
            where TKey : notnull;
    }
}