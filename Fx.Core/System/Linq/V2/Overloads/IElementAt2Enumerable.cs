namespace System.Linq.V2
{
    public interface IElementAt2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource ElementAt(int index);
    }
}