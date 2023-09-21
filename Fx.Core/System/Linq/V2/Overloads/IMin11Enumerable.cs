namespace System.Linq.V2
{
    using System.Collections.Generic;

    public interface IMin11Enumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource? Min(IComparer<TSource>? comparer);
    }
}