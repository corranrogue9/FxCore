namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IToDictionaryEnumerable<TSource> : IV2Enumerable<TSource>
    {
        Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector)
            where TKey : notnull;
    }
}