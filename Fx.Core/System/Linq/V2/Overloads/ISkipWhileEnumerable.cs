namespace System.Linq.V2
{
    using System;

    public interface ISkipWhileEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> SkipWhile(Func<TSource, bool> predicate);
    }
}