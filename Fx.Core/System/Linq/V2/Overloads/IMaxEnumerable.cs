namespace System.Linq.V2
{
    using System;

    public interface IMaxEnumerable<TSource> : IV2Enumerable<TSource>
    {
        long Max(Func<TSource, long> selector);
    }
}