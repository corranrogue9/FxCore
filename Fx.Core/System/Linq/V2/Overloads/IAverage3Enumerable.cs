namespace System.Linq.V2
{
    using System;

    public interface IAverage3Enumerable<TSource> : IV2Enumerable<TSource>
    {
        double? Average(Func<TSource, double?> selector);
    }
}