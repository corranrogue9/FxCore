namespace System.Linq.V2
{
    using System;

    public interface ILastOrDefault4Enumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource LastOrDefault(Func<TSource, bool> predicate, TSource defaultValue);
    }
}