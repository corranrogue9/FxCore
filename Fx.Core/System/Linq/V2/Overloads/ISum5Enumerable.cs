namespace System.Linq.V2
{
    using System;

    public interface ISum5Enumerable<TSource> : IV2Enumerable<TSource>
    {
        int? Sum(Func<TSource, int?> selector);
    }
}