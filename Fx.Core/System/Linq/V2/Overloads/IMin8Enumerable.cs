namespace System.Linq.V2
{
    using System;

    public interface IMin8Enumerable<TSource> : IV2Enumerable<TSource>
    {
        long Min(Func<TSource, long> selector);
    }
}