namespace System.Linq.V2
{
    using System;

    public interface ISumEnumerable<TSource> : IV2Enumerable<TSource>
    {
        int Sum(Func<TSource, int> selector);

        double? Sum(Func<TSource, double?> selector);

        float Sum(Func<TSource, float> selector);

        float? Sum(Func<TSource, float?> selector);

        int? Sum(Func<TSource, int?> selector);

        double Sum(Func<TSource, double> selector);

        long? Sum(Func<TSource, long?> selector);

        decimal? Sum(Func<TSource, decimal?> selector);

        long Sum(Func<TSource, long> selector);

        decimal Sum(Func<TSource, decimal> selector);
    }
}