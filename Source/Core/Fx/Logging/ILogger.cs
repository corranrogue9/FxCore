namespace Fx.Logging
{
    /// <summary>
    /// An abstraction layer for emitting events to a log
    /// </summary>
    /// <threadsafety instance="true"/>
    public interface ILogger
    {
        /// <summary>
        /// Emits a verbose event to a log
        /// </summary>
        /// <param name="id">The ID of the event that is being emitted</param>
        /// <param name="message">The message containing the specifics about the event being emitted</param>
        /// <remarks>Please note that this method is critical to instrumentation and therefore should throw no exceptions, regardless of the quality of the input</remarks>
        void EmitDetail(int id, string message);

        /// <summary>
        /// Emits an information event to a log
        /// </summary>
        /// <param name="id">The ID of the event that is being emitted</param>
        /// <param name="message">The message containing the specifics about the event being emitted</param>
        /// <remarks>Please note that this method is critical to instrumentation and therefore should throw no exceptions, regardless of the quality of the input</remarks>
        void EmitInformation(int id, string message);

        /// <summary>
        /// Emits a warning event to a log
        /// </summary>
        /// <param name="id">The ID of the event that is being emitted</param>
        /// <param name="message">The message containing the specifics about the event being emitted</param>
        /// <remarks>Please note that this method is critical to instrumentation and therefore should throw no exceptions, regardless of the quality of the input</remarks>
        void EmitWarning(int id, string message);

        /// <summary>
        /// Emits an error event to a log
        /// </summary>
        /// <param name="id">The ID of the event that is being emitted</param>
        /// <param name="message">The message containing the specifics about the event being emitted</param>
        /// <remarks>Please note that this method is critical to instrumentation and therefore should throw no exceptions, regardless of the quality of the input</remarks>
        void EmitError(int id, string message);
    }
}
