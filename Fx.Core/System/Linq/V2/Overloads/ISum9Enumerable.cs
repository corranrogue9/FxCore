namespace System.Linq.V2
{
    using System;

    public interface ISum9Enumerable<TSource> : IV2Enumerable<TSource>
    {
        double? Sum(Func<TSource, double?> selector);
    }
}