namespace System.Linq.V2
{
    using System;

    public interface IDistinctByEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> DistinctBy<TKey>(Func<TSource, TKey> keySelector);
    }
}