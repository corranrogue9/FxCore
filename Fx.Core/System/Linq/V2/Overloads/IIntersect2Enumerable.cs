namespace System.Linq.V2
{
    public interface IIntersect2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> Intersect(IV2Enumerable<TSource> second);
    }
}