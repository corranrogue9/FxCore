namespace System.Linq.V2
{
    using System;

    public interface ITakeWhile2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> TakeWhile(Func<TSource, int, bool> predicate);
    }
}