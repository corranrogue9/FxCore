namespace System.Linq.V2
{
    using System;

    public interface ISum8Enumerable<TSource> : IV2Enumerable<TSource>
    {
        float Sum(Func<TSource, float> selector);
    }
}