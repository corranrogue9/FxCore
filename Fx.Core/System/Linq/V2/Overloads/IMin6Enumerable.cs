namespace System.Linq.V2
{
    using System;

    public interface IMin6Enumerable<TSource> : IV2Enumerable<TSource>
    {
        double? Min(Func<TSource, double?> selector);
    }
}