namespace System.Linq.V2
{
    using System;

    public interface IMax2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        decimal Max(Func<TSource, decimal> selector);
    }
}