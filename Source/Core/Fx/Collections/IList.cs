namespace Fx.Collections
{
    /// <summary>
    /// 
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public interface IList<T> : IArray<T>, ICollection<T>
    {
        void Insert(T element, int index);

        void Remove(int index);
    }
}
