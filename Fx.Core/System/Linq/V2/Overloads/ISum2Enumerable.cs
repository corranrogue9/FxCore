namespace System.Linq.V2
{
    using System;

    public interface ISum2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        long Sum(Func<TSource, long> selector);
    }
}