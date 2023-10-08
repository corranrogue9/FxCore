namespace System.Linq.V2
{
    using System.Collections.Generic;

    public interface IMax6Enumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource? Max(IComparer<TSource>? comparer);
    }
}