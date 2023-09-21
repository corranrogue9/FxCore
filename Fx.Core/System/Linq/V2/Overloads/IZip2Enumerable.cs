namespace System.Linq.V2
{
    public interface IZip2Enumerable<TFirst> : IV2Enumerable<TFirst>
    {
        IV2Enumerable<(TFirst First, TSecond Second)> Zip<TSecond>(IV2Enumerable<TSecond> second);
    }
}