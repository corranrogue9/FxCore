namespace System.Linq.V2
{
    using System;

    public interface IOrderBy2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2OrderedEnumerable<TSource> OrderBy<TKey>(Func<TSource, TKey> keySelector);
    }
}