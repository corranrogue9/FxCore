namespace System.Linq.V2
{
    using System;

    public interface ITakeWhileEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> TakeWhile(Func<TSource, bool> predicate);
    }
}