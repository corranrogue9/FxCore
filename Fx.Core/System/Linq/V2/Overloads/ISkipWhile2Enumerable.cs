namespace System.Linq.V2
{
    using System;

    public interface ISkipWhile2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> SkipWhile(Func<TSource, int, bool> predicate);
    }
}