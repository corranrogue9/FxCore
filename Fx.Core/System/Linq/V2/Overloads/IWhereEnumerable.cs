namespace System.Linq.V2
{
    using System;

    public interface IWhereEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> Where(Func<TSource, bool> predicate);
    }
}