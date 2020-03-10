namespace Fx.Collections
{
    /// <summary>
    /// 
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public interface IReadOnlySet<T> : IReadOnlyCollection<T>
    {
        bool Contains(T element);
    }
}
