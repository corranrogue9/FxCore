namespace System.Linq.V2
{
    public interface ILastOrDefault2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource LastOrDefault(TSource defaultValue);
    }
}