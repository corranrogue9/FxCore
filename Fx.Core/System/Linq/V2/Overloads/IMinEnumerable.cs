using System.Collections.Generic;

namespace System.Linq.V2
{
    public interface IMinEnumerable<TSource> : IV2Enumerable<TSource>
    {
        int Min(Func<TSource, int> selector);

        long Min(Func<TSource, long> selector);

        decimal? Min(Func<TSource, decimal?> selector);

        double? Min(Func<TSource, double?> selector);

        int? Min(Func<TSource, int?> selector);

        float? Min(Func<TSource, float?> selector);

        float Min(Func<TSource, float> selector);

        TResult? Min<TResult>(Func<TSource, TResult> selector);

        double Min(Func<TSource, double> selector);

        long? Min(Func<TSource, long?> selector);

        TSource? Min();

        TSource? Min(IComparer<TSource>? comparer);

        decimal Min(Func<TSource, decimal> selector);
    }
}