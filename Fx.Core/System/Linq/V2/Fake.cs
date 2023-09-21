namespace System.Linq.V2
{
    public interface IV2Enumerable //// TODO do you need this type?
    {
    }

    public interface IV2Grouping<out TKey, out TElement> : IV2Enumerable<TElement>, IV2Enumerable //// TODO do you need this type?
    {
        TKey Key { get; }
    }

    public interface IV2Lookup<TKey, TElement> : IV2Enumerable<IV2Grouping<TKey, TElement>>, IV2Enumerable //// TODO do you need this type?
    {
        IV2Enumerable<TElement> this[TKey key] { get; }

        int Count { get; }

        bool Contains(TKey key);
    }
}