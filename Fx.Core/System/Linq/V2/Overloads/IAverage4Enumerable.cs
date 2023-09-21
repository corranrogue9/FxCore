namespace System.Linq.V2
{
    using System;

    public interface IAverage4Enumerable<TSource> : IV2Enumerable<TSource>
    {
        float Average(Func<TSource, float> selector);
    }
}