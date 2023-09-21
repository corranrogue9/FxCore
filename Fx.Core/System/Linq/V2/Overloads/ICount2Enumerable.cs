namespace System.Linq.V2
{
    using System;

    public interface ICount2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        int Count(Func<TSource, bool> predicate);
    }
}