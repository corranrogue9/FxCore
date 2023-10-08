namespace System.Linq.V2
{
    using System;

    public interface ISelectEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TResult> Select<TResult>(Func<TSource, int, TResult> selector);
    }
}