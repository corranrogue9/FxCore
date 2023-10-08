namespace System.Linq.V2
{
    using System;

    public interface IMaxByEnumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource? MaxBy<TKey>(Func<TSource, TKey> keySelector);
    }
}