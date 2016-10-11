namespace System.Diagnostics
{
    using System.Collections;
    using System.Linq;
    using System.Reflection;
    using System.Threading;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="MemoryTraceListener"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class MemoryTraceListenerUnitTests
    {
        /// <summary>
        /// Ensures that the TraceListener is thread-safe
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that the TraceListener is thread-safe")]
        [TestMethod]
        public void IsThreadSafe()
        {
            MemoryTraceListener listener;
            MemoryTraceListener.Create(out listener);

            Assert.IsTrue(listener.IsThreadSafe);
        }

        /// <summary>
        /// Traces information from a trace source
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Traces information from a trace source")]
        [TestMethod]
        public void TraceSourceTraceInformation()
        {
            MemoryTraceListener listener;
            var traceSource = MemoryTraceListener.Create(out listener);

            var startTime = DateTime.UtcNow;
            traceSource.TraceInformation("this is a message");
            var endTime = DateTime.UtcNow;

            Assert.AreEqual(1, listener.TraceEvents.Count());
            Assert.AreEqual(1, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().Count());
            Assert.AreEqual("this is a message", listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Message);
            Assert.AreEqual(TraceEventType.Information, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().EventType);
            Assert.AreEqual(traceSource.Name, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Source);
            Assert.AreEqual(0, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Id);
            Assert.IsTrue(listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().CallStack.Contains(MethodBase.GetCurrentMethod().Name));
            CollectionAssert.AreEqual(new Stack(new string[0]), listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().LogicalOperationStack);
            Assert.AreEqual(Process.GetCurrentProcess().Id, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().ProcessId);
            Assert.AreEqual(Thread.CurrentThread.ManagedThreadId.ToString(), listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().ThreadId);
            Assert.IsTrue(startTime <= listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().DateTime && listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().DateTime <= endTime);
        }

        /// <summary>
        /// Traces information from a trace source using a string format
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Traces information from a trace source using a string format")]
        [TestMethod]
        public void TraceSourceTraceInformationWithFormat()
        {
            MemoryTraceListener listener;
            var traceSource = MemoryTraceListener.Create(out listener);

            var startTime = DateTime.UtcNow;
            traceSource.TraceInformation("this is a {0}", "message");
            var endTime = DateTime.UtcNow;

            Assert.AreEqual(1, listener.TraceEvents.Count());
            Assert.AreEqual(1, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().Count());
            Assert.AreEqual("this is a message", listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Message);
            Assert.AreEqual(TraceEventType.Information, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().EventType);
            Assert.AreEqual(traceSource.Name, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Source);
            Assert.AreEqual(0, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Id);
            Assert.IsTrue(listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().CallStack.Contains(MethodBase.GetCurrentMethod().Name));
            CollectionAssert.AreEqual(new Stack(new string[0]), listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().LogicalOperationStack);
            Assert.AreEqual(Process.GetCurrentProcess().Id, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().ProcessId);
            Assert.AreEqual(Thread.CurrentThread.ManagedThreadId.ToString(), listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().ThreadId);
            Assert.IsTrue(startTime <= listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().DateTime && listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().DateTime <= endTime);
        }

        /// <summary>
        /// Traces information from a trace source when the logical operation stack is being leveraged
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Traces information from a trace source when the logical operation stack is being leveraged")]
        [TestMethod]
        public void TraceSourceLogicalOperationStack()
        {
            MemoryTraceListener listener;
            var traceSource = MemoryTraceListener.Create(out listener);

            Trace.CorrelationManager.StartLogicalOperation("first operation");
            try
            {
                traceSource.TraceInformation("this is a message");
                Trace.CorrelationManager.StartLogicalOperation("second operation");
                try
                {
                    traceSource.TraceInformation("this is another message");
                }
                finally
                {
                    Trace.CorrelationManager.StopLogicalOperation();
                }
            }
            finally
            {
                Trace.CorrelationManager.StopLogicalOperation();
            }

            Assert.AreEqual(2, listener.TraceEvents.Count());
            Assert.AreEqual(2, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().Count());
            Assert.AreEqual("this is a message", listener.TraceEvents.OfType<TraceEvent.MessageEvent>().ElementAt(0).Message);
            CollectionAssert.AreEqual(new[] { "first operation" }, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().ElementAt(0).LogicalOperationStack);
            Assert.AreEqual("this is another message", listener.TraceEvents.OfType<TraceEvent.MessageEvent>().ElementAt(1).Message);
            CollectionAssert.AreEqual(new[] { "second operation", "first operation" }, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().ElementAt(1).LogicalOperationStack);
        }

        /// <summary>
        /// Traces information from a trace source using a string format that takes in a null set of arguments
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Traces information from a trace source using a string format that takes in a null set of arguments")]
        [TestMethod]
        public void TraceSourceTraceInformationWithFormatNullArguments()
        {
            MemoryTraceListener listener;
            var traceSource = MemoryTraceListener.Create(out listener);

            var startTime = DateTime.UtcNow;
            traceSource.TraceInformation("this is a {0}", null);
            var endTime = DateTime.UtcNow;

            Assert.AreEqual(1, listener.TraceEvents.Count());
            Assert.AreEqual(1, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().Count());
            Assert.AreEqual("this is a {0}", listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Message);
            Assert.AreEqual(TraceEventType.Information, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().EventType);
            Assert.AreEqual(traceSource.Name, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Source);
            Assert.AreEqual(0, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Id);
            Assert.IsTrue(listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().CallStack.Contains(MethodBase.GetCurrentMethod().Name));
            CollectionAssert.AreEqual(new Stack(new string[0]), listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().LogicalOperationStack);
            Assert.AreEqual(Process.GetCurrentProcess().Id, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().ProcessId);
            Assert.AreEqual(Thread.CurrentThread.ManagedThreadId.ToString(), listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().ThreadId);
            Assert.IsTrue(startTime <= listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().DateTime && listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().DateTime <= endTime);
        }

        /// <summary>
        /// Traces transfer from a trace source
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Traces transfer from a trace source")]
        [TestMethod]
        public void TraceSourceTraceTransfer()
        {
            MemoryTraceListener listener;
            var traceSource = MemoryTraceListener.Create(out listener);

            var activityId = Guid.NewGuid();
            var startTime = DateTime.UtcNow;
            traceSource.TraceTransfer(100, "this is a message", activityId);
            var endTime = DateTime.UtcNow;

            Assert.AreEqual(1, listener.TraceEvents.Count());
            Assert.AreEqual(1, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().Count());
            Assert.IsTrue(listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Message.Contains("this is a message"));
            Assert.IsTrue(listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Message.Contains(activityId.ToString()));
            Assert.AreEqual(TraceEventType.Transfer, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().EventType);
            Assert.AreEqual(traceSource.Name, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Source);
            Assert.AreEqual(100, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Id);
            Assert.IsTrue(listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().CallStack.Contains(MethodBase.GetCurrentMethod().Name));
            CollectionAssert.AreEqual(new Stack(new string[0]), listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().LogicalOperationStack);
            Assert.AreEqual(Process.GetCurrentProcess().Id, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().ProcessId);
            Assert.AreEqual(Thread.CurrentThread.ManagedThreadId.ToString(), listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().ThreadId);
            Assert.IsTrue(startTime <= listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().DateTime && listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().DateTime <= endTime);
        }

        /// <summary>
        /// Traces error from a trace source
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Traces error from a trace source")]
        [TestMethod]
        public void TraceSourceTraceError()
        {
            MemoryTraceListener listener;
            var traceSource = MemoryTraceListener.Create(out listener);

            var startTime = DateTime.UtcNow;
            traceSource.TraceEvent(TraceEventType.Error, 1000);
            var endTime = DateTime.UtcNow;

            Assert.AreEqual(1, listener.TraceEvents.Count());
            Assert.AreEqual(1, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().Count());
            Assert.AreEqual(string.Empty, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Message);
            Assert.AreEqual(TraceEventType.Error, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().EventType);
            Assert.AreEqual(traceSource.Name, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Source);
            Assert.AreEqual(1000, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Id);
            Assert.IsTrue(listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().CallStack.Contains(MethodBase.GetCurrentMethod().Name));
            CollectionAssert.AreEqual(new Stack(new string[0]), listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().LogicalOperationStack);
            Assert.AreEqual(Process.GetCurrentProcess().Id, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().ProcessId);
            Assert.AreEqual(Thread.CurrentThread.ManagedThreadId.ToString(), listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().ThreadId);
            Assert.IsTrue(startTime <= listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().DateTime && listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().DateTime <= endTime);
        }

        /// <summary>
        /// Traces error from a trace source when a filter is applied
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Traces error from a trace source when a filter is applied")]
        [TestMethod]
        public void TraceSourceTraceErrorWithFilter()
        {
            MemoryTraceListener listener;
            var traceSource = MemoryTraceListener.Create(out listener);
            listener.Filter = NegativeTraceFilter.Instance;

            traceSource.TraceEvent(TraceEventType.Error, 1000);

            Assert.AreEqual(0, listener.TraceEvents.Count());
        }

        /// <summary>
        /// Traces error from a trace source with a message
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Traces error from a trace source with a messsage")]
        [TestMethod]
        public void TraceSourceTraceErrorWithMessage()
        {
            MemoryTraceListener listener;
            var traceSource = MemoryTraceListener.Create(out listener);

            var startTime = DateTime.UtcNow;
            traceSource.TraceEvent(TraceEventType.Error, 1000, "this is a message");
            var endTime = DateTime.UtcNow;

            Assert.AreEqual(1, listener.TraceEvents.Count());
            Assert.AreEqual(1, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().Count());
            Assert.AreEqual("this is a message", listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Message);
            Assert.AreEqual(TraceEventType.Error, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().EventType);
            Assert.AreEqual(traceSource.Name, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Source);
            Assert.AreEqual(1000, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Id);
            Assert.IsTrue(listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().CallStack.Contains(MethodBase.GetCurrentMethod().Name));
            CollectionAssert.AreEqual(new Stack(new string[0]), listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().LogicalOperationStack);
            Assert.AreEqual(Process.GetCurrentProcess().Id, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().ProcessId);
            Assert.AreEqual(Thread.CurrentThread.ManagedThreadId.ToString(), listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().ThreadId);
            Assert.IsTrue(startTime <= listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().DateTime && listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().DateTime <= endTime);
        }

        /// <summary>
        /// Traces error from a trace source with a message that is null
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Traces error from a trace source with a messsage that is null")]
        [TestMethod]
        public void TraceSourceTraceErrorWithNullMessage()
        {
            MemoryTraceListener listener;
            var traceSource = MemoryTraceListener.Create(out listener);

            var startTime = DateTime.UtcNow;
            traceSource.TraceEvent(TraceEventType.Error, 1000, null);
            var endTime = DateTime.UtcNow;

            Assert.AreEqual(1, listener.TraceEvents.Count());
            Assert.AreEqual(1, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().Count());
            Assert.IsNull(listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Message);
            Assert.AreEqual(TraceEventType.Error, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().EventType);
            Assert.AreEqual(traceSource.Name, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Source);
            Assert.AreEqual(1000, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Id);
            Assert.IsTrue(listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().CallStack.Contains(MethodBase.GetCurrentMethod().Name));
            CollectionAssert.AreEqual(new Stack(new string[0]), listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().LogicalOperationStack);
            Assert.AreEqual(Process.GetCurrentProcess().Id, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().ProcessId);
            Assert.AreEqual(Thread.CurrentThread.ManagedThreadId.ToString(), listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().ThreadId);
            Assert.IsTrue(startTime <= listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().DateTime && listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().DateTime <= endTime);
        }

        /// <summary>
        /// Traces error from a trace source using a string format
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Traces error from a trace source using a string format")]
        [TestMethod]
        public void TraceSourceTraceErrorWithFormat()
        {
            MemoryTraceListener listener;
            var traceSource = MemoryTraceListener.Create(out listener);

            var startTime = DateTime.UtcNow;
            traceSource.TraceEvent(TraceEventType.Error, 1000, "this is a {0}", "message");
            var endTime = DateTime.UtcNow;

            Assert.AreEqual(1, listener.TraceEvents.Count());
            Assert.AreEqual(1, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().Count());
            Assert.AreEqual("this is a message", listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Message);
            Assert.AreEqual(TraceEventType.Error, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().EventType);
            Assert.AreEqual(traceSource.Name, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Source);
            Assert.AreEqual(1000, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Id);
            Assert.IsTrue(listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().CallStack.Contains(MethodBase.GetCurrentMethod().Name));
            CollectionAssert.AreEqual(new Stack(new string[0]), listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().LogicalOperationStack);
            Assert.AreEqual(Process.GetCurrentProcess().Id, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().ProcessId);
            Assert.AreEqual(Thread.CurrentThread.ManagedThreadId.ToString(), listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().ThreadId);
            Assert.IsTrue(startTime <= listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().DateTime && listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().DateTime <= endTime);
        }

        /// <summary>
        /// Traces error from a trace source using a string format that is malformed with the number of arguments
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Traces error from a trace source using a string format that is malformed with the number of arguments")]
        [TestMethod]
        public void TraceSourceTraceErrorWithBadFormat()
        {
            MemoryTraceListener listener;
            var traceSource = MemoryTraceListener.Create(out listener);

#if DEBUG
            ExceptionAssert.Throws<FormatException>(() => traceSource.TraceEvent(TraceEventType.Error, 1000, "this is a {0} {1}", "message"));
#else
            var startTime = DateTime.UtcNow;
            traceSource.TraceEvent(TraceEventType.Error, 1000, "this is a {0} {1}", "message");
            var endTime = DateTime.UtcNow;

            Assert.AreEqual(1, listener.TraceEvents.Count());
            Assert.AreEqual(1, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().Count());
            Assert.IsTrue(listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Message.Contains("this is a {0} {1}"));
            Assert.IsTrue(listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Message.Contains("message"));
            Assert.AreEqual(TraceEventType.Error, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().EventType);
            Assert.AreEqual(traceSource.Name, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Source);
            Assert.AreEqual(1000, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Id);
            Assert.IsTrue(listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().CallStack.Contains(MethodBase.GetCurrentMethod().Name));
            CollectionAssert.AreEqual(new Stack(new string[0]), listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().LogicalOperationStack);
            Assert.AreEqual(Process.GetCurrentProcess().Id, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().ProcessId);
            Assert.AreEqual(Thread.CurrentThread.ManagedThreadId.ToString(), listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().ThreadId);
            Assert.IsTrue(startTime <= listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().DateTime && listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().DateTime <= endTime);
#endif
        }

        /// <summary>
        /// Traces information from a trace source using a string format that takes in a null set of arguments
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Traces information from a trace source using a string format that takes in a null set of arguments")]
        [TestMethod]
        public void TraceSourceTraceErrorWithFormatNullArguments()
        {
            MemoryTraceListener listener;
            var traceSource = MemoryTraceListener.Create(out listener);

            var startTime = DateTime.UtcNow;
            traceSource.TraceEvent(TraceEventType.Error, 1000, "this is a {0}", null);
            var endTime = DateTime.UtcNow;

            Assert.AreEqual(1, listener.TraceEvents.Count());
            Assert.AreEqual(1, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().Count());
            Assert.AreEqual("this is a {0}", listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Message);
            Assert.AreEqual(TraceEventType.Error, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().EventType);
            Assert.AreEqual(traceSource.Name, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Source);
            Assert.AreEqual(1000, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().Id);
            Assert.IsTrue(listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().CallStack.Contains(MethodBase.GetCurrentMethod().Name));
            CollectionAssert.AreEqual(new Stack(new string[0]), listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().LogicalOperationStack);
            Assert.AreEqual(Process.GetCurrentProcess().Id, listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().ProcessId);
            Assert.AreEqual(Thread.CurrentThread.ManagedThreadId.ToString(), listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().ThreadId);
            Assert.IsTrue(startTime <= listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().DateTime && listener.TraceEvents.OfType<TraceEvent.MessageEvent>().First().DateTime <= endTime);
        }

        /// <summary>
        /// Traces datum from a trace source
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Traces datum from a trace source")]
        [TestMethod]
        public void TraceSourceTraceDatum()
        {
            MemoryTraceListener listener;
            var traceSource = MemoryTraceListener.Create(out listener);

            var datum = new object();
            var startTime = DateTime.UtcNow;
            traceSource.TraceData(TraceEventType.Verbose, 1000, datum);
            var endTime = DateTime.UtcNow;

            Assert.AreEqual(1, listener.TraceEvents.Count());
            Assert.AreEqual(1, listener.TraceEvents.OfType<TraceEvent.DataEvent>().Count());
            Assert.AreEqual(TraceEventType.Verbose, listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().EventType);
            Assert.AreEqual(traceSource.Name, listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().Source);
            Assert.AreEqual(1000, listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().Id);
            Assert.AreEqual(1, listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().Data.Count());
            Assert.AreEqual(datum, listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().Data.First());
            Assert.IsTrue(listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().CallStack.Contains(MethodBase.GetCurrentMethod().Name));
            CollectionAssert.AreEqual(new Stack(new string[0]), listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().LogicalOperationStack);
            Assert.AreEqual(Process.GetCurrentProcess().Id, listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().ProcessId);
            Assert.AreEqual(Thread.CurrentThread.ManagedThreadId.ToString(), listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().ThreadId);
            Assert.IsTrue(startTime <= listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().DateTime && listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().DateTime <= endTime);
        }

        /// <summary>
        /// Traces datum from a trace source when a filter is applied
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Traces datum from a trace source when a filter is applied")]
        [TestMethod]
        public void TraceSourceTraceDatumWithFilter()
        {
            MemoryTraceListener listener;
            var traceSource = MemoryTraceListener.Create(out listener);
            listener.Filter = NegativeTraceFilter.Instance;

            var datum = new object();
            traceSource.TraceData(TraceEventType.Verbose, 1000, datum);

            Assert.AreEqual(0, listener.TraceEvents.Count());
        }

        /// <summary>
        /// Traces data from a trace source
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Traces data from a trace source")]
        [TestMethod]
        public void TraceSourceTraceData()
        {
            MemoryTraceListener listener;
            var traceSource = MemoryTraceListener.Create(out listener);

            var datum1 = new object();
            var datum2 = new object();
            var startTime = DateTime.UtcNow;
            traceSource.TraceData(TraceEventType.Verbose, 1000, datum1, datum2);
            var endTime = DateTime.UtcNow;

            Assert.AreEqual(1, listener.TraceEvents.Count());
            Assert.AreEqual(1, listener.TraceEvents.OfType<TraceEvent.DataEvent>().Count());
            Assert.AreEqual(TraceEventType.Verbose, listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().EventType);
            Assert.AreEqual(traceSource.Name, listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().Source);
            Assert.AreEqual(1000, listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().Id);
            Assert.AreEqual(2, listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().Data.Count());
            Assert.AreEqual(datum1, listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().Data.ElementAt(0));
            Assert.AreEqual(datum2, listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().Data.ElementAt(1));
            Assert.IsTrue(listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().CallStack.Contains(MethodBase.GetCurrentMethod().Name));
            CollectionAssert.AreEqual(new Stack(new string[0]), listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().LogicalOperationStack);
            Assert.AreEqual(Process.GetCurrentProcess().Id, listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().ProcessId);
            Assert.AreEqual(Thread.CurrentThread.ManagedThreadId.ToString(), listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().ThreadId);
            Assert.IsTrue(startTime <= listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().DateTime && listener.TraceEvents.OfType<TraceEvent.DataEvent>().First().DateTime <= endTime);
        }

        /// <summary>
        /// Traces from a trace source and ensures that the events collected are consistent
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Traces from a trace source and ensures that the events collected are consistent")]
        [TestMethod]
        public void TraceSourceEventEnumeration()
        {
            MemoryTraceListener listener;
            var traceSource = MemoryTraceListener.Create(out listener);
            listener.Filter = NegativeTraceFilter.Instance;

            var datum = new object();
            traceSource.TraceData(TraceEventType.Verbose, 1000, datum);

            var events = listener.TraceEvents;
            Assert.AreEqual(0, events.Count());

            traceSource.TraceData(TraceEventType.Verbose, 1000, datum);
            Assert.AreEqual(0, events.Count());
        }
    }
}
