namespace System.Linq.V2
{
    using System;

    public interface ITakeEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> Take(Range range);
    }
}