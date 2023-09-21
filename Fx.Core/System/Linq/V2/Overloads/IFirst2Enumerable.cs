namespace System.Linq.V2
{
    using System;

    public interface IFirst2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource First(Func<TSource, bool> predicate);
    }
}