namespace System.Linq.V2
{
    using System.Collections.Generic;

    public interface IToHashSetEnumerable<TSource> : IV2Enumerable<TSource>
    {
        HashSet<TSource> ToHashSet();

        HashSet<TSource> ToHashSet(IEqualityComparer<TSource>? comparer);
    }
}