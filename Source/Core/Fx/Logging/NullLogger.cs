namespace Fx.Logging
{
    /// <summary>
    /// A <see cref="ILogger"/> that swallows all of the events that are emitted to it, rather than passing those events to a log
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed class NullLogger : ILogger
    {
        /// <summary>
        /// A singleton instance of the <see cref="NullLogger"/>
        /// </summary>
        private static readonly NullLogger Singleton = new NullLogger();

        /// <summary>
        /// Prevents a default instance of the <see cref="NullLogger"/> class from being created
        /// </summary>
        private NullLogger()
        {
        }

        /// <summary>
        /// Gets a singleton instance of the <see cref="NullLogger"/>
        /// </summary>
        public static NullLogger Instance
        {
            get
            {
                return Singleton;
            }
        }

        /// <summary>
        /// Swallows a verbose event
        /// </summary>
        /// <param name="id">The ID of the event that is being swallowed</param>
        /// <param name="message">The message containing the specifics about the event being swallowed</param>
        public void EmitDetail(int id, string message)
        {
        }

        /// <summary>
        /// Swallows an error event
        /// </summary>
        /// <param name="id">The ID of the event that is being swallowed</param>
        /// <param name="message">The message containing the specifics about the event being swallowed</param>
        public void EmitError(int id, string message)
        {
        }

        /// <summary>
        /// Swallows an information event
        /// </summary>
        /// <param name="id">The ID of the event that is being swallowed</param>
        /// <param name="message">The message containing the specifics about the event being swallowed</param>
        public void EmitInformation(int id, string message)
        {
        }

        /// <summary>
        /// Swallows a warning event
        /// </summary>
        /// <param name="id">The ID of the event that is being swallowed</param>
        /// <param name="message">The message containing the specifics about the event being swallowed</param>
        public void EmitWarning(int id, string message)
        {
        }
    }
}
