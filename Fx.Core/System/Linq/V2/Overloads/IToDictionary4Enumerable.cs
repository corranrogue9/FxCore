namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IToDictionary4Enumerable<TSource> : IV2Enumerable<TSource>
    {
        Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey>? comparer)
            where TKey : notnull;
    }
}