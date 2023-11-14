namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IGroupByEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TResult> GroupBy<TKey, TElement, TResult>(
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IV2Enumerable<TElement>, TResult> resultSelector,
            IEqualityComparer<TKey>? comparer);

        IV2Enumerable<IV2Grouping<TKey, TElement>> GroupBy<TKey, TElement>(
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey>? comparer);

        IV2Enumerable<IV2Grouping<TKey, TSource>> GroupBy<TKey>(
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey>? comparer);

        IV2Enumerable<IV2Grouping<TKey, TElement>> GroupBy<TKey, TElement>(
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector);

        IV2Enumerable<IV2Grouping<TKey, TSource>> GroupBy<TKey>(Func<TSource, TKey> keySelector);

        IV2Enumerable<TResult> GroupBy<TKey, TResult>(
            Func<TSource, TKey> keySelector,
            Func<TKey, IV2Enumerable<TSource>, TResult> resultSelector);

        IV2Enumerable<TResult> GroupBy<TKey, TResult>(
            Func<TSource, TKey> keySelector,
            Func<TKey, IV2Enumerable<TSource>, TResult> resultSelector,
            IEqualityComparer<TKey>? comparer);

        IV2Enumerable<TResult> GroupBy<TKey, TElement, TResult>(
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IV2Enumerable<TElement>, TResult> resultSelector);
    }
}