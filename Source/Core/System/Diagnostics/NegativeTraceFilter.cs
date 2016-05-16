namespace System.Diagnostics
{
    /// <summary>
    /// a <see cref="TraceFilter"/> that always filters events
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    internal sealed class NegativeTraceFilter : TraceFilter
    {
        /// <summary>
        /// A singleton instance of the <see cref="NegativeTraceFilter"/>
        /// </summary>
        private static readonly NegativeTraceFilter Singleton = new NegativeTraceFilter();

        /// <summary>
        /// Prevents a default instance of the <see cref="NegativeTraceFilter"/> class from being created
        /// </summary>
        private NegativeTraceFilter()
        {
        }

        /// <summary>
        /// Gets a singleton instance of the <see cref="NegativeTraceFilter"/>
        /// </summary>
        public static NegativeTraceFilter Instance
        {
            get
            {
                return Singleton;
            }
        }

        /// <summary>
        /// Indicates that a <see cref="TraceListener"/> should not trace an event
        /// </summary>
        /// <param name="cache">The <see cref="TraceEventCache"/> that contains information for the trace event</param>
        /// <param name="source">The name of the source</param>
        /// <param name="eventType">One of the <see cref="TraceEventType"/> values specifying the type of event that has caused the trace</param>
        /// <param name="id">A trace identifier number</param>
        /// <param name="formatOrMessage">Either the format to use for writing an array of arguments specified by the <paramref name="args"/> parameter, or a message to write</param>
        /// <param name="args">An array of argument objects</param>
        /// <param name="data1">A trace data object</param>
        /// <param name="data">An array of trace data objects</param>
        /// <returns>false for any trace event</returns>
        public override bool ShouldTrace(TraceEventCache cache, string source, TraceEventType eventType, int id, string formatOrMessage, object[] args, object data1, object[] data)
        {
            return false;
        }
    }
}
