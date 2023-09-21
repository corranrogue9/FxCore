namespace System.Linq.V2
{
    using System;

    public interface IElementAtOrDefaultEnumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource? ElementAtOrDefault(Index index);
    }
}