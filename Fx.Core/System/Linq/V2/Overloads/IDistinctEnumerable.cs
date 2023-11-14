using System.Collections.Generic;

namespace System.Linq.V2
{
    public interface IDistinctEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> Distinct();

        IV2Enumerable<TSource> Distinct(IEqualityComparer<TSource>? comparer);
    }
}