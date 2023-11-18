namespace System.Linq.V2
{
    using System;
    using System.Collections.Generic;

    public interface IMaxEnumerable<TSource> : IV2Enumerable<TSource>
    {
        long Max(Func<TSource, long> selector);

        long? Max(Func<TSource, long?> selector);

        float? Max(Func<TSource, float?> selector);

        int? Max(Func<TSource, int?> selector);

        TSource? Max(IComparer<TSource>? comparer);

        decimal? Max(Func<TSource, decimal?> selector);

        int Max(Func<TSource, int> selector);

        double Max(Func<TSource, double> selector);

        decimal Max(Func<TSource, decimal> selector);

        TResult? Max<TResult>(Func<TSource, TResult> selector);

        float Max(Func<TSource, float> selector);

        TSource? Max();

        double? Max(Func<TSource, double?> selector);
    }
}