namespace System.Linq.V2
{
    using System;

    public interface ISelect2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TResult> Select<TResult>(Func<TSource, TResult> selector);
    }
}