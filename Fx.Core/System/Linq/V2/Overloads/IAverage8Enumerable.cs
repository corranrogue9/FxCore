namespace System.Linq.V2
{
    using System;

    public interface IAverage8Enumerable<TSource> : IV2Enumerable<TSource>
    {
        double? Average(Func<TSource, int?> selector);
    }
}