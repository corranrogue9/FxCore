namespace System.Linq.V2
{
    using System;

    public interface IWhere2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> Where(Func<TSource, int, bool> predicate);
    }
}