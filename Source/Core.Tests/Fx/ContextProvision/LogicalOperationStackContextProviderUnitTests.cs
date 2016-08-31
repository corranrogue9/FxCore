namespace Fx.ContextProvision
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="LogicalOperationStackContextProvider"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class LogicalOperationStackContextProviderUnitTests
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
            ContextProviderUnitTests.ProvideNullContext(LogicalOperationStackContextProvider.Instance);
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
            ContextProviderUnitTests.ProvideNullKey(LogicalOperationStackContextProvider.Instance);
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
            ContextProviderUnitTests.ProvideNullValue(LogicalOperationStackContextProvider.Instance);
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
            ContextProviderUnitTests.ProvideNullDatum(LogicalOperationStackContextProvider.Instance);
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
            ContextProviderUnitTests.DisposeContext(LogicalOperationStackContextProvider.Instance);
        }

        /// <summary>
        /// Provides empty context
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Provides empty context")]
        [TestMethod]
        public void LogicalOperationProvideEmptyContext()
        {
            var initial = new Stack(Trace.CorrelationManager.LogicalOperationStack);
            using (LogicalOperationStackContextProvider.Instance.ProvideContext(Enumerable.Empty<KeyValuePair<string, object>>()))
            {
                CollectionAssert.AreEqual(initial, Trace.CorrelationManager.LogicalOperationStack);
            }

            CollectionAssert.AreEqual(initial, Trace.CorrelationManager.LogicalOperationStack);
        }

        /// <summary>
        /// Provides null context
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Provides null context")]
        [TestMethod]
        public void LogicalOperationProvideNullContext()
        {
            var initial = new Stack(Trace.CorrelationManager.LogicalOperationStack);
            using (LogicalOperationStackContextProvider.Instance.ProvideContext(null))
            {
                CollectionAssert.AreEqual(initial, Trace.CorrelationManager.LogicalOperationStack);
            }

            CollectionAssert.AreEqual(initial, Trace.CorrelationManager.LogicalOperationStack);
        }

        /// <summary>
        /// Provides context
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Provides context")]
        [TestMethod]
        public void LogicalOperationProvideContext()
        {
            var initial = new Stack(Trace.CorrelationManager.LogicalOperationStack);
            using (LogicalOperationStackContextProvider.Instance.ProvideContext(new[] { new KeyValuePair<string, object>("key", "value") }))
            {
                var final = new Stack(initial);
                final.Push("key=value");
                CollectionAssert.AreEqual(final, Trace.CorrelationManager.LogicalOperationStack);
            }

            CollectionAssert.AreEqual(initial, Trace.CorrelationManager.LogicalOperationStack);
        }

        /// <summary>
        /// Provides context in nested operations
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Provides context in nested operations")]
        [TestMethod]
        public void LogicalOperationProvideNestedContext()
        {
            var initial = new Stack(Trace.CorrelationManager.LogicalOperationStack);
            using (LogicalOperationStackContextProvider.Instance.ProvideContext(new[] { new KeyValuePair<string, object>("key1", "value1") }))
            {
                var intermediate = new Stack(initial);
                intermediate.Push("key1=value1");
                CollectionAssert.AreEqual(intermediate, Trace.CorrelationManager.LogicalOperationStack);

                using (LogicalOperationStackContextProvider.Instance.ProvideContext(new[] { new KeyValuePair<string, object>("key2", "value2") }))
                {
                    var final = new Stack(intermediate);
                    final.Push("key2=value2");
                    CollectionAssert.AreEqual(final, Trace.CorrelationManager.LogicalOperationStack);
                }

                CollectionAssert.AreEqual(intermediate, Trace.CorrelationManager.LogicalOperationStack);
            }

            CollectionAssert.AreEqual(initial, Trace.CorrelationManager.LogicalOperationStack);
        }
    }
}
