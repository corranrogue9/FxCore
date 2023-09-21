namespace System.Linq.V2
{
    using System;

    public interface IGroupBy6Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<IV2Grouping<TKey, TElement>> GroupBy< TKey, TElement>(
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector);
    }
}