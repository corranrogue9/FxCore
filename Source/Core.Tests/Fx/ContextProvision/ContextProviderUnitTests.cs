namespace Fx.ContextProvision
{
    using System.Collections.Generic;
    
    /// <summary>
    /// Unit tests for the <see cref="IContextProvider"/> abstraction
    /// </summary>
    /// <threadsafety static="true"/>
    internal static class ContextProviderUnitTests
    {
        /// <summary>
        /// Provides a null collection to a context provider
        /// </summary>
        /// <param name="contextProvider">The <see cref="IContextProvider"/> to text</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="contextProvider"/> is null</exception>
        public static void ProvideNullContext(IContextProvider contextProvider)
        {
            Ensure.NotNull(contextProvider, nameof(contextProvider));

            contextProvider.ProvideContext(null).Dispose();
        }

        /// <summary>
        /// Provides a collection with a null key to a context provider
        /// </summary>
        /// <param name="contextProvider">The <see cref="IContextProvider"/> to text</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="contextProvider"/> is null</exception>
        public static void ProvideNullKey(IContextProvider contextProvider)
        {
            Ensure.NotNull(contextProvider, nameof(contextProvider));

            contextProvider.ProvideContext(new[] { new KeyValuePair<string, object>(null, new object()) }).Dispose();
        }

        /// <summary>
        /// Provides a collection with a null value to a context provider
        /// </summary>
        /// <param name="contextProvider">The <see cref="IContextProvider"/> to text</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="contextProvider"/> is null</exception>
        public static void ProvideNullValue(IContextProvider contextProvider)
        {
            Ensure.NotNull(contextProvider, nameof(contextProvider));

            contextProvider.ProvideContext(new[] { new KeyValuePair<string, object>("key", null) }).Dispose();
        }

        /// <summary>
        /// Provides a collection with a null key and value to a context provider
        /// </summary>
        /// <param name="contextProvider">The <see cref="IContextProvider"/> to text</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="contextProvider"/> is null</exception>
        public static void ProvideNullDatum(IContextProvider contextProvider)
        {
            Ensure.NotNull(contextProvider, nameof(contextProvider));

            contextProvider.ProvideContext(new[] { new KeyValuePair<string, object>(null, null) }).Dispose();
        }

        /// <summary>
        /// Provides metadata to a context provider and disposes the context multiple times
        /// </summary>
        /// <param name="contextProvider">The <see cref="IContextProvider"/> to text</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="contextProvider"/> is null</exception>
        public static void DisposeContext(IContextProvider contextProvider)
        {
            Ensure.NotNull(contextProvider, nameof(contextProvider));

            using (var context = contextProvider.ProvideContext(new[] { new KeyValuePair<string, object>("asdf", new object()) }))
            {
                context.Dispose();
            }
        }
    }
}
