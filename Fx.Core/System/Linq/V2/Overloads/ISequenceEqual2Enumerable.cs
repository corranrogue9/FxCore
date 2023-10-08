using System.Collections.Generic;

namespace System.Linq.V2
{
    public interface ISequenceEqual2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        bool SequenceEqual(IV2Enumerable<TSource> second, IEqualityComparer<TSource>? comparer);
    }
}