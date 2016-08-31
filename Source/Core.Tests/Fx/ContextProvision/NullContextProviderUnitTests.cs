namespace Fx.ContextProvision
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="NullContextProvider"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class NullContextProviderUnitTests
    {
        /// <summary>
        /// Provides a null collection to a context provider
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Provides a null collection to a context provider")]
        [TestMethod]
        public void ProvideNullContext()
        {
            ContextProviderUnitTests.ProvideNullContext(NullContextProvider.Instance);
        }

        /// <summary>
        /// Provides a collection with a null key to a context provider
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Provides a collection with a null key to a context provider")]
        [TestMethod]
        public void ProvideNullKey()
        {
            ContextProviderUnitTests.ProvideNullKey(NullContextProvider.Instance);
        }

        /// <summary>
        /// Provides a collection with a null value to a context provider
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Provides a collection with a null value to a context provider")]
        [TestMethod]
        public void ProvideNullValue()
        {
            ContextProviderUnitTests.ProvideNullValue(NullContextProvider.Instance);
        }

        /// <summary>
        /// Provides a collection with a null key and value to a context provider
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Provides a collection with a null key and value to a context provider")]
        [TestMethod]
        public void ProvideNullDatum()
        {
            ContextProviderUnitTests.ProvideNullDatum(NullContextProvider.Instance);
        }

        /// <summary>
        /// Provides metadata to a context provider and disposes the context multiple times
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Provides metadata to a context provider and disposes the context multiple times")]
        [TestMethod]
        public void DisposeContext()
        {
            ContextProviderUnitTests.DisposeContext(NullContextProvider.Instance);
        }
    }
}
