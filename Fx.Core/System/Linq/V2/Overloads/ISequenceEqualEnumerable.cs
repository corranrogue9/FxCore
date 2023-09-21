namespace System.Linq.V2
{
    public interface ISequenceEqualEnumerable<TSource> : IV2Enumerable<TSource>
    {
        bool SequenceEqual(IV2Enumerable<TSource> second);
    }
}