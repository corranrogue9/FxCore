namespace System.Linq.V2
{
    using System;

    public interface IAverageEnumerable<TSource> : IV2Enumerable<TSource>
    {
        double Average(Func<TSource, int> selector);
    }
}