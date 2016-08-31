namespace Fx.ContextProvision
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A <see cref="IContextProvider"/> that swallows all of the provided metadata
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed class NullContextProvider : IContextProvider
    {
        /// <summary>
        /// A singleton instance of the <see cref="NullContextProvider"/>
        /// </summary>
        private static readonly NullContextProvider Singleton = new NullContextProvider();

        /// <summary>
        /// Prevents a default instance of the <see cref="NullContextProvider"/> class from being created
        /// </summary>
        private NullContextProvider()
        {
        }

        /// <summary>
        /// Gets a singleton instance of the <see cref="NullContextProvider"/>
        /// </summary>
        public static NullContextProvider Instance
        {
            get
            {
                return Singleton;
            }
        }

        /// <summary>
        /// Swallows the metadata represented by <paramref name="data"/>
        /// </summary>
        /// <param name="data">The metadata being added to the current logical operation</param>
        /// <returns>The context that should be disposed to remove the added metadata from the current logical operation</returns>
        public IDisposable ProvideContext(IEnumerable<KeyValuePair<string, object>> data)
        {
            return new Context();
        }

        /// <summary>
        /// A representation of metadata having been added to a logical operation
        /// </summary>
        private sealed class Context : IDisposable
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Context"/> class
            /// </summary>
            public Context()
            {
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources
            /// </summary>
            public void Dispose()
            {
            }
        }
    }
}
