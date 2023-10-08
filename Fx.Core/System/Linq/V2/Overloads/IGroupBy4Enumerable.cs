namespace System.Linq.V2
{
    using System;

    public interface IGroupBy4Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TResult> GroupBy<TKey, TResult>(
            Func<TSource, TKey> keySelector,
            Func<TKey, IV2Enumerable<TSource>, TResult> resultSelector);
    }
}