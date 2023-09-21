namespace System.Linq.V2
{
    using System;

    public interface IAggregate3Enumerable<TSource> : IV2Enumerable<TSource>
    {
        TResult Aggregate<TAccumulate, TResult>(
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func,
            Func<TAccumulate, TResult> resultSelector);
    }
}