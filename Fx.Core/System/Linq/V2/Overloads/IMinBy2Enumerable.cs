namespace System.Linq.V2
{
    using System;

    public interface IMinBy2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource? MinBy<TKey>(Func<TSource, TKey> keySelector);
    }
}