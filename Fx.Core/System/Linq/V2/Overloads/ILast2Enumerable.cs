namespace System.Linq.V2
{
    using System;

    public interface ILast2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource Last(Func<TSource, bool> predicate);
    }
}