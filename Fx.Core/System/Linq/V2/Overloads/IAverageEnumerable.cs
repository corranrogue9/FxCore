namespace System.Linq.V2
{
    using System;

    public interface IAverageEnumerable<TSource> : IV2Enumerable<TSource>
    {
        double Average(Func<TSource, int> selector);

        double? Average(Func<TSource, int?> selector);

        decimal Average(Func<TSource, decimal> selector);

        double Average(Func<TSource, double> selector);

        float? Average(Func<TSource, float?> selector);

        double? Average(Func<TSource, long?> selector);

        float Average(Func<TSource, float> selector);

        double? Average(Func<TSource, double?> selector);

        double Average(Func<TSource, long> selector);

        decimal? Average(Func<TSource, decimal?> selector);
    }
}