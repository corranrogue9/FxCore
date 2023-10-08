namespace System.Linq.V2
{
    using System.Collections.Generic;

    public interface IDistinct2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> Distinct(IEqualityComparer<TSource>? comparer);
    }
}