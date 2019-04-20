namespace System.Threading
{
    using System.Collections.Generic;

    internal sealed class ThreadLocal<T> : IDisposable
    {
        private sealed class ValueWrapper
        {
            private readonly Func<T> valueFactory;

            private bool initialized;

            private T value;

            private Exception exception;

            public ValueWrapper(Func<T> valueFactory)
            {
                this.valueFactory = valueFactory;

                this.initialized = false;
            }

            public T Value
            {
                get
                {
                    if (!this.initialized)
                    {
                        try
                        {
                            this.value = this.valueFactory();
                            this.initialized = true;
                        }
                        catch (Exception e)
                        {
                            this.exception = e;
                        }
                    }

                    //// TODO use overloads for this stuff
                    if (this.exception == null)
                    {
                        return this.value;
                    }

                    throw this.exception;
                }
            }
        }

        [ThreadStatic]
        private static Dictionary<int, ValueWrapper> values = new Dictionary<int, ValueWrapper>();

        private static int previousId = 0;

        private readonly Func<T> valueFactory;

        private readonly int id;

        private bool disposed;

        public ThreadLocal(Func<T> valueFactory)
        {
            if (valueFactory == null)
            {
                throw new ArgumentNullException(nameof(valueFactory)); //// TODO
            }

            this.valueFactory = valueFactory;

            this.id = System.Threading.Interlocked.Increment(ref previousId);
            //// TODO re-use ids for objects that have been disposed
            this.disposed = false;
        }

        public T Value
        {
            get
            {
                if (this.disposed)
                {
                    throw new ObjectDisposedException("TODO");
                }

                ValueWrapper wrapper;
                if (!values.TryGetValue(this.id, out wrapper))
                {
                    //// TODO compute value here instead of in wrapper?
                    wrapper = new ValueWrapper(this.valueFactory);
                    values[this.id] = wrapper;
                }

                return wrapper.Value;
            }
        }

        public void Dispose()
        {
            if (this.disposed)
            {
                return;
            }
            
            values[this.id] = null;

            this.disposed = true;
        }
    }
}
