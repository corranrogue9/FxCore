namespace System.Linq.V2
{
    using System;

    public interface ILongCountEnumerable<TSource> : IV2Enumerable<TSource>
    {
        long LongCount(Func<TSource, bool> predicate);

        long LongCount();
    }
}