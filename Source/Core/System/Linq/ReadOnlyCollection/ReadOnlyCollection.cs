namespace System.Linq
{
    using Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Provides a set of static methods for querying objects that implement <see cref="IReadOnlyCollection{T}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static partial class ReadOnlyCollectionExtensions
    {
        private sealed class ReadOnlyCollection<T> : IReadOnlyCollection<T>
        {
            private readonly IEnumerable<T> source;

            private readonly int count;

            public ReadOnlyCollection(IEnumerable<T> source, int count)
            {
                this.source = source;
                this.count = count;
            }

            public int Count
            {
                get
                {
                    return this.count;
                }
            }

            public IEnumerator<T> GetEnumerator()
            {
                return this.source.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this.source).GetEnumerator();
            }
        }
    }
}
