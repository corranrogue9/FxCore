namespace Fx.ContextProvision
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// A <see cref="IContextProvider"/> that leverages the .NET <see cref="Trace.CorrelationManager"/> for determining and maintaining the current logical operation
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed class LogicalOperationStackContextProvider : IContextProvider
    {
        /// <summary>
        /// A singleton instance of the <see cref="LogicalOperationStackContextProvider"/>
        /// </summary>
        private static readonly LogicalOperationStackContextProvider Singleton = new LogicalOperationStackContextProvider();

        /// <summary>
        /// Prevents a default instance of the <see cref="LogicalOperationStackContextProvider"/> class from being created
        /// </summary>
        private LogicalOperationStackContextProvider()
        {
        }

        /// <summary>
        /// Gets a singleton instance of the <see cref="LogicalOperationStackContextProvider"/>
        /// </summary>
        public static LogicalOperationStackContextProvider Instance
        {
            get
            {
                return Singleton;
            }
        }

        /// <summary>
        /// Adds the elements of <paramref name="data"/> to the <see cref="Trace.CorrelationManager"/>'s logical operation stack
        /// </summary>
        /// <param name="data">The metadata that should be added to the current logical operation</param>
        /// <returns>The context that can be disposed in order to remove the added metadata from the current logical operation</returns>
        public IDisposable ProvideContext(IEnumerable<KeyValuePair<string, object>> data)
        {
            data = data ?? Enumerable.Empty<KeyValuePair<string, object>>();

            uint count;
            using (var enumerator = data.GetEnumerator())
            {
                for (count = 0; enumerator.MoveNext(); ++count)
                {
                    Trace.CorrelationManager.StartLogicalOperation($"{enumerator.Current.Key ?? string.Empty}={enumerator.Current.Value ?? string.Empty}");
                }
            }

            return new Context(count);
        }

        /// <summary>
        /// A representation of metadata having been added to a logical operation
        /// </summary>
        private sealed class Context : IDisposable
        {
            /// <summary>
            /// The number of elements in the metadata that was added to the current logical operation that should be removed when this object is disposed
            /// </summary>
            private readonly uint count;

            /// <summary>
            /// Whether or not this object is disposed
            /// </summary>
            private bool disposed;

            /// <summary>
            /// Initializes a new instance of the <see cref="Context"/> class
            /// </summary>
            /// <param name="count">The number of elements in the metadata that was added to the current logical operation that should be removed when this object is disposed</param>
            public Context(uint count)
            {
                this.count = count;

                this.disposed = false;
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources
            /// </summary>
            public void Dispose()
            {
                if (this.disposed)
                {
                    return;
                }

                for (uint i = 0; i < this.count; ++i)
                {
                    Trace.CorrelationManager.StopLogicalOperation();
                }

                this.disposed = true;
            }
        }
    }
}
