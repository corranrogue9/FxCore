namespace System.Linq.V2
{
    public interface IFirstOrDefault2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource FirstOrDefault(TSource defaultValue);
    }
}