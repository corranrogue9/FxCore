namespace System.Linq.V2
{
    using System;

    public interface IIntersectByEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> IntersectBy<TKey>(IV2Enumerable<TKey> second, Func<TSource, TKey> keySelector);
    }
}