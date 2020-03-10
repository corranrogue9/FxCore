namespace Fx.Collections
{
    using System.Collections.Generic;

    public interface IReadOnlyCollection<T> : IEnumerable<T>
    {
        int Count { get; }
    }
}
