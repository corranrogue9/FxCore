namespace Fx.Collections
{
    /// <summary>
    /// 
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public interface IReadOnlyArray<T> : IReadOnlyCollection<T>
    {
        T this[int index] { get; }
    }
}
