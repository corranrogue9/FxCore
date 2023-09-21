namespace System.Linq.V2
{
    using System;

    public interface IAny2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        bool Any(Func<TSource, bool> predicate);
    }
}