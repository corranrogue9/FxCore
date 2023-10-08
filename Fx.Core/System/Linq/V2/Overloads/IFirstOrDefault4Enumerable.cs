namespace System.Linq.V2
{
    using System;

    public interface IFirstOrDefault4Enumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource FirstOrDefault(Func<TSource, bool> predicate, TSource defaultValue);
    }
}