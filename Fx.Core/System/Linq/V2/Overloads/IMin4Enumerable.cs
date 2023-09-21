namespace System.Linq.V2
{
    using System;

    public interface IMin4Enumerable<TSource> : IV2Enumerable<TSource>
    {
        float? Min(Func<TSource, float?> selector);
    }
}