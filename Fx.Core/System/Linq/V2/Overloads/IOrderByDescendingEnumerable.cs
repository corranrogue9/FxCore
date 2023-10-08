namespace System.Linq.V2
{
    using System;

    public interface IOrderByDescendingEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2OrderedEnumerable<TSource> OrderByDescending<TKey>(Func<TSource, TKey> keySelector);
    }
}