namespace Fx.Collections
{
    /// <summary>
    /// 
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public interface ICollection<T> : IReadOnlyCollection<T>
    {
        void Add(T element);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <exception cref="ElementNotFoundException"></exception>
        void Remove(T element);
    }
}
