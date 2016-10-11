namespace System.Diagnostics
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Globalization;
#if !DEBUG
    using System.Linq;
#endif

    using Fx;

    /// <summary>
    /// A <see cref="TraceListener"/> that stores the events it emits in memory and exposes the collection of all events emitted so far
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed class MemoryTraceListener : TraceListener
    {
        /// <summary>
        /// The collection of <see cref="System.Diagnostics.TraceEvent"/>s that have been emitted by this <see cref="TraceListener"/> so far
        /// </summary>
        /// <remarks>We use a <see cref="ConcurrentQueue{T}"/> here since it is actually a linked list underneath</remarks>
        private readonly ConcurrentQueue<TraceEvent> traceEvents = new ConcurrentQueue<TraceEvent>();

        /// <summary>
        /// Gets the collection of <see cref="System.Diagnostics.TraceEvent"/>s that have been emitted by this <see cref="TraceListener"/> so far
        /// </summary>
        public IEnumerable<TraceEvent> TraceEvents
        {
            get
            {
                foreach (var @event in this.traceEvents)
                {
                    yield return @event;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the trace listener is thread safe
        /// </summary>
        public override bool IsThreadSafe
        {
            get
            {   
                return true;
            }
        }

        /// <summary>
        /// Creates a new <see cref="MemoryTraceListener"/>, attaches it to a <see cref="TraceSource"/>, and then returns the <see cref="TraceSource"/>
        /// </summary>
        /// <param name="listener">The <see cref="MemoryTraceListener"/> that is attached to the resulting <see cref="TraceSource"/></param>
        /// <returns>A <see cref="TraceSource"/> with a new <see cref="MemoryTraceListener"/> attached</returns>
        public static TraceSource Create(out MemoryTraceListener listener)
        {
            listener = new MemoryTraceListener();

            var traceSource = new TraceSource(Guid.NewGuid().ToString());
            traceSource.Switch = new SourceSwitch(Guid.NewGuid().ToString(), "All");
            traceSource.Listeners.Remove("Default");
            traceSource.Listeners.Add(listener);

            return traceSource;
        }

        /// <summary>
        /// Writes the specified message to the listener
        /// </summary>
        /// <param name="message">A message to write</param>
        public override void Write(string message)
        {
            this.traceEvents.Enqueue(new TraceEvent.WriteEvent(message));
        }

        /// <summary>
        /// Writes the specified message the the listener; this listener has no concept of a newline
        /// </summary>
        /// <param name="message">A message to write</param>
        public override void WriteLine(string message)
        {
            this.Write(message);
        }

        /// <summary>
        /// Writes trace information, a data object and event information to the listener specific output
        /// </summary>
        /// <param name="eventCache">A <see cref="TraceEventCache"/> object that contains the current process ID, thread ID, and stack trace information</param>
        /// <param name="source">A name used to identify the output, typically the name of the application that generated the trace event</param>
        /// <param name="eventType">One of the <see cref="TraceEventType"/> values specifying the type of event that has caused the trace</param>
        /// <param name="id">A numeric identifier for the event</param>
        /// <param name="data">The trace data to emit</param>
        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
        {
            this.TraceData(eventCache, source, eventType, id, new[] { data });
        }

        /// <summary>
        /// Writes trace information, an array of data objects and event information to the listener specific output
        /// </summary>
        /// <param name="eventCache">A <see cref="TraceEventCache"/> object that contains the current process ID, thread ID, and stack trace information</param>
        /// <param name="source">A name used to identify the output, typically the name of the application that generated the trace event</param>
        /// <param name="eventType">One of the <see cref="TraceEventType"/> values specifying the type of event that has caused the trace</param>
        /// <param name="id">A numeric identifier for the event</param>
        /// <param name="data">An array of objects to emit as data</param>
        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, params object[] data)
        {
            if (this.Filter != null && !this.Filter.ShouldTrace(eventCache, source, eventType, id, null, null, null, data))
            {
                return;
            }

            this.traceEvents.Enqueue(new TraceEvent.DataEvent(eventCache, source, eventType, id, data));
        }

        /// <summary>
        /// Writes trace and event information to the listener specific output
        /// </summary>
        /// <param name="eventCache">A <see cref="TraceEventCache"/> object that contains the current process ID, thread ID, and stack trace information</param>
        /// <param name="source">A name used to identify the output, typically the name of the application that generated the trace event</param>
        /// <param name="eventType">One of the <see cref="TraceEventType"/> values specifying the type of event that has caused the trace</param>
        /// <param name="id">A numeric identifier for the event</param>
        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id)
        {
            this.TraceEvent(eventCache, source, eventType, id, string.Empty);
        }

        /// <summary>
        /// Writes trace information, a formatted array of objects and event information to the listener specific output
        /// </summary>
        /// <param name="eventCache">A <see cref="TraceEventCache"/> object that contains the current process ID, thread ID, and stack trace information</param>
        /// <param name="source">A name used to identify the output, typically the name of the application that generated the trace event</param>
        /// <param name="eventType">One of the <see cref="TraceEventType"/> values specifying the type of event that has caused the trace</param>
        /// <param name="id">A numeric identifier for the event</param>
        /// <param name="format">A format string that contains zero or more format items, which correspond to objects in the args array</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects to format</param>
        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
        {
            string formatted;
            if (args == null)
            {
                formatted = format;
            }
            else
            {
                try
                {
                    formatted = string.Format(CultureInfo.CurrentCulture, format, args);
                }
                catch
                {
#if DEBUG
                    throw;
#else
                    formatted = string.Format(Strings.MemoryTraceListenerTraceEvent, format, string.Join(",", args.Select(arg => arg.ToString()).ToArray()));
#endif
                }
            }

            this.TraceEvent(eventCache, source, eventType, id, formatted);
        }

        /// <summary>
        /// Writes trace information, a message, and event information to the listener specific output
        /// </summary>
        /// <param name="eventCache">A <see cref="TraceEventCache"/> object that contains the current process ID, thread ID, and stack trace information</param>
        /// <param name="source">A name used to identify the output, typically the name of the application that generated the trace event</param>
        /// <param name="eventType">One of the <see cref="TraceEventType"/> values specifying the type of event that has caused the trace</param>
        /// <param name="id">A numeric identifier for the event</param>
        /// <param name="message">A message to write</param>
        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
        {
            if (this.Filter != null && !this.Filter.ShouldTrace(eventCache, source, eventType, id, message, null, null, null))
            {
                return;
            }

            this.traceEvents.Enqueue(new TraceEvent.MessageEvent(eventCache, source, eventType, id, message));
        }
    }
}
