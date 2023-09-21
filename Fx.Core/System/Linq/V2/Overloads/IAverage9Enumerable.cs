namespace System.Linq.V2
{
    using System;

    public interface IAverage9Enumerable<TSource> : IV2Enumerable<TSource>
    {
        decimal Average(Func<TSource, decimal> selector);
    }
}