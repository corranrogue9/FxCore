namespace System.Linq.V2
{
    using System;

    public interface IAggregateEnumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource Aggregate(Func<TSource, TSource, TSource> func);

        TAccumulate Aggregate<TAccumulate>(TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func);

        TResult Aggregate<TAccumulate, TResult>(
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func,
            Func<TAccumulate, TResult> resultSelector);
    }
}