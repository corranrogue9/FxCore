namespace System.Linq.V2
{
    using System;

    public interface IMin7Enumerable<TSource> : IV2Enumerable<TSource>
    {
        decimal? Min(Func<TSource, decimal?> selector);
    }
}