namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IToDictionary2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        Dictionary<TKey, TSource> ToDictionary<TKey>(
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey>? comparer)
            where TKey : notnull;
    }
}