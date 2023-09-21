namespace System.Linq.V2
{
    using System;

    public interface ISingleOrDefault4Enumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource? SingleOrDefault(Func<TSource, bool> predicate);
    }
}