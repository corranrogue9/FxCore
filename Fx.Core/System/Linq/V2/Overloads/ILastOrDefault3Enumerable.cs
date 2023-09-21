namespace System.Linq.V2
{
    using System;

    public interface ILastOrDefault3Enumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource? LastOrDefault(Func<TSource, bool> predicate);
    }
}