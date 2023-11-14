namespace System.Linq.V2
{
    using System;

    public interface IElementAtEnumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource ElementAt(Index index);

        TSource ElementAt(int index);
    }
}