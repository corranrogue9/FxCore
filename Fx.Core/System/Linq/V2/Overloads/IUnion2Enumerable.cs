namespace System.Linq.V2
{
    using System.Collections.Generic;

    public interface IUnion2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> Union(IV2Enumerable<TSource> second, IEqualityComparer<TSource>? comparer);
    }
}