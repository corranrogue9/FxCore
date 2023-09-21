namespace System.Linq.V2
{
    using System;

    public interface IAggregateEnumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource Aggregate(Func<TSource, TSource, TSource> func);
    }
}