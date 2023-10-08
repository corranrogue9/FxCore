namespace System.Linq.V2
{
    using System;

    public interface ISingle2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource Single(Func<TSource, bool> predicate);
    }
}