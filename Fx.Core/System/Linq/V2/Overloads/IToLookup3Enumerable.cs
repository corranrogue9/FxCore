namespace System.Linq.V2
{
    using System;

    public interface IToLookup3Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Lookup<TKey, TSource> ToLookup<TKey>(Func<TSource, TKey> keySelector);
    }
}