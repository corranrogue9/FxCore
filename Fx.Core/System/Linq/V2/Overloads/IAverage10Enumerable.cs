namespace System.Linq.V2
{
    using System;

    public interface IAverage10Enumerable<TSource> : IV2Enumerable<TSource>
    {
        decimal? Average(Func<TSource, decimal?> selector);
    }
}