namespace System.Linq.V2
{
    public interface IZipEnumerable<TFirst> : IV2Enumerable<TFirst>
    {
        IV2Enumerable<(TFirst First, TSecond Second, TThird Third)> Zip<TSecond, TThird>(
            IV2Enumerable<TSecond> second,
            IV2Enumerable<TThird> third);
    }
}