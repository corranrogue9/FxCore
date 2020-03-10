namespace Fx.Collections
{
    /// <summary>
    /// 
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public interface IArray<T> : IReadOnlyArray<T>
    {
        new T this[int index] { get; set; }
    }
}
