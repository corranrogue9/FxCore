namespace System.Linq.V2
{
    using System;

    public interface IMin14Enumerable<TSource> : IV2Enumerable<TSource>
    {
        double Min(Func<TSource, double> selector);
    }
}