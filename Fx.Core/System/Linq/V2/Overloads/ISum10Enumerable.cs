namespace System.Linq.V2
{
    using System;

    public interface ISum10Enumerable<TSource> : IV2Enumerable<TSource>
    {
        decimal Sum(Func<TSource, decimal> selector);
    }
}