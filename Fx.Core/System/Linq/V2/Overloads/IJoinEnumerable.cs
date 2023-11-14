namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IJoinEnumerable<TOuter> : IV2Enumerable<TOuter>
    {
        IV2Enumerable<TResult> Join<TInner, TKey, TResult>(
            IV2Enumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector);

        IV2Enumerable<TResult> Join<TInner, TKey, TResult>(
            IV2Enumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector,
            IEqualityComparer<TKey>? comparer);
    }
}