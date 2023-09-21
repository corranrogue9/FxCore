namespace System.Linq.V2
{
    using System;

    public interface IGroupJoin2Enumerable<TOuter> : IV2Enumerable<TOuter>
    {
        IV2Enumerable<TResult> GroupJoin<TInner, TKey, TResult>(
            IV2Enumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, IV2Enumerable<TInner>, TResult> resultSelector);
    }
}