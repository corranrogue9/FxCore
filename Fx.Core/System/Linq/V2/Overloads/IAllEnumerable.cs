namespace System.Linq.V2
{
    using System;

    public interface IAllEnumerable<TSource> : IV2Enumerable<TSource>
    {
        bool All(Func<TSource, bool> predicate);
    }
}