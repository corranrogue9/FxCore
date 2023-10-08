namespace System.Linq.V2
{
    public interface IElementAtOrDefault2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource? ElementAtOrDefault(int index);
    }
}