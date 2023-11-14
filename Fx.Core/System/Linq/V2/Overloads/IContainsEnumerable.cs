namespace System.Linq.V2
{
    using System.Collections.Generic;

    public interface IContainsEnumerable<TSource> : IV2Enumerable<TSource>
    {
        bool Contains(TSource value, IEqualityComparer<TSource>? comparer);

        bool Contains(TSource value);
    }
}