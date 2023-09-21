namespace System.Linq.V2
{
    using System;

    public interface IToLookup2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Lookup<TKey, TElement> ToLookup<TKey, TElement>(
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector);
    }
}