namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;

    using Fx;

    /// <summary>
    /// 
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    internal sealed class DeferredExecutionReadOnlyCollection<T> : IReadOnlyCollection<T>
    {
        private readonly IReadOnlyCollection<T> collection;

        private bool enumeratorRetrieved;

        private bool enumerationStarted;

        private bool enumerationCompleted;

        public DeferredExecutionReadOnlyCollection(IReadOnlyCollection<T> collection)
        {
            Ensure.NotNull(collection, nameof(collection));

            this.collection = collection;

            this.enumeratorRetrieved = false;
            this.enumerationStarted = false;
            this.enumerationCompleted = false;
        }

        public int Count
        {
            get
            {
                return this.collection.Count;
            }
        }

        public bool EnumeratorRetrieved
        {
            get
            {
                return this.enumeratorRetrieved;
            }
        }

        public bool EnumerationStarted
        {
            get
            {
                return this.enumerationStarted;
            }
        }

        public bool EnumerationCompleted
        {
            get
            {
                return this.enumerationCompleted;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            this.enumeratorRetrieved = true;
            return this.GetEnumeratorIterator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private IEnumerator<T> GetEnumeratorIterator()
        {
            foreach (var element in this.collection)
            {
                this.enumerationStarted = true;
                yield return element;
            }

            this.enumerationCompleted = true;
        }
    }
}
