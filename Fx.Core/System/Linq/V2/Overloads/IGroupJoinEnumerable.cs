namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IGroupJoinEnumerable<TOuter> : IV2Enumerable<TOuter>
    {
        IV2Enumerable<TResult> GroupJoin< TInner, TKey, TResult>(
            IV2Enumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, IV2Enumerable<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey>? comparer);

        IV2Enumerable<TResult> GroupJoin<TInner, TKey, TResult>(
            IV2Enumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, IV2Enumerable<TInner>, TResult> resultSelector);
    }
}