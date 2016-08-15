#if NET40
namespace Fx.Logging
{
    using System.Diagnostics;

    /// <summary>
    /// A <see cref="ILogger"/> that delegates each of its calls to the corresponding <see cref="TraceSource"/> calls
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed class TraceSourceLogger : ILogger
    {
        /// <summary>
        /// The <see cref="TraceSource"/> that this <see cref="ILogger"/> will delegate each of its calls to
        /// </summary>
        private readonly TraceSource traceSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="TraceSourceLogger"/> class
        /// </summary>
        /// <param name="traceSource">The <see cref="TraceSource"/> that each of the new <see cref="TraceSourceLogger"/>s calls will be delegated to</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="traceSource"/> is null</exception>
        public TraceSourceLogger(TraceSource traceSource)
        {
            Ensure.NotNull(traceSource, nameof(traceSource));

            this.traceSource = traceSource;
        }

        /// <summary>
        /// Emits a verbose event to the underlying <see cref="TraceSource"/>
        /// </summary>
        /// <param name="id">The ID of the event that is being emitted</param>
        /// <param name="message">The message containing the specifics about the event being emitted</param>
        public void EmitDetail(int id, string message)
        {
            this.traceSource.TraceEvent(TraceEventType.Verbose, id, message);
        }

        /// <summary>
        /// Emits an error event to the underlying <see cref="TraceSource"/>
        /// </summary>
        /// <param name="id">The ID of the event that is being emitted</param>
        /// <param name="message">The message containing the specifics about the event being emitted</param>
        public void EmitError(int id, string message)
        {
            this.traceSource.TraceEvent(TraceEventType.Error, id, message);
        }

        /// <summary>
        /// Emits an information event to the underlying <see cref="TraceSource"/>
        /// </summary>
        /// <param name="id">The ID of the event that is being emitted</param>
        /// <param name="message">The message containing the specifics about the event being emitted</param>
        public void EmitInformation(int id, string message)
        {
            this.traceSource.TraceEvent(TraceEventType.Information, id, message);
        }

        /// <summary>
        /// Emits a warning event to the underlying <see cref="TraceSource"/>
        /// </summary>
        /// <param name="id">The ID of the event that is being emitted</param>
        /// <param name="message">The message containing the specifics about the event being emitted</param>
        public void EmitWarning(int id, string message)
        {
            this.traceSource.TraceEvent(TraceEventType.Warning, id, message);
        }
    }
}
#endif