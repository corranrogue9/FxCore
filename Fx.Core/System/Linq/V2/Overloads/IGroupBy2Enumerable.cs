namespace System.Linq.V2
{
    using System;

    public interface IGroupBy2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TResult> GroupBy<TKey, TElement, TResult>(
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IV2Enumerable<TElement>, TResult> resultSelector);
    }
}