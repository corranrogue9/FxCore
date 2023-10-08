namespace System.Linq.V2
{
    using System;

    public interface IAggregate2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        TAccumulate Aggregate<TAccumulate>(TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func);
    }
}