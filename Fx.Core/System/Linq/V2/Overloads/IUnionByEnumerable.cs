namespace System.Linq.V2
{
    using System;

    public interface IUnionByEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> UnionBy<TKey>(IV2Enumerable<TSource> second, Func<TSource, TKey> keySelector);
    }
}