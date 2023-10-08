namespace System.Linq.V2
{
    using System;

    public interface IMax10Enumerable<TSource> : IV2Enumerable<TSource>
    {
        TResult? Max<TResult>(Func<TSource, TResult> selector);
    }
}