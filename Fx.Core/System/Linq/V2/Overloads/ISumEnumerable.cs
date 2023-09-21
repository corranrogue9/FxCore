namespace System.Linq.V2
{
    using System;

    public interface ISumEnumerable<TSource> : IV2Enumerable<TSource>
    {
        int Sum(Func<TSource, int> selector);
    }
}