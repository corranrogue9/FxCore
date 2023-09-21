namespace System.Linq.V2
{
    public interface IChunkEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource[]> Chunk(int size);
    }
}