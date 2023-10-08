namespace System.Linq.V2
{
    public interface IToArrayEnumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource[] ToArray();
    }
}