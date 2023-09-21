namespace System.Linq.V2
{
    using System;

    public interface IGroupBy5Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<IV2Grouping<TKey, TSource>> GroupBy<TKey>(Func<TSource, TKey> keySelector);
    }
}