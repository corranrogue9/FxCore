namespace System.Linq.V2
{
    using System;

    public interface IZip3Enumerable<TFirst> : IV2Enumerable<TFirst>
    {
        IV2Enumerable<TResult> Zip<TSecond, TResult>(
            IV2Enumerable<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector);
    }
}