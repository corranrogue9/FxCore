namespace System.Linq.V2
{
    using System.Collections.Generic;

    public interface IToHashSet2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        HashSet<TSource> ToHashSet();
    }
}