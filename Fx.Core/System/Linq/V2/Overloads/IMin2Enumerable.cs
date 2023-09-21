namespace System.Linq.V2
{
    using System;

    public interface IMin2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        TResult? Min<TResult>(Func<TSource, TResult> selector);
    }
}