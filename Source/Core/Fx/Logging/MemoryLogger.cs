namespace Fx.Logging
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    /// <summary>
    /// A <see cref="ILogger"/> that stores all of the events emitted to it in memory
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed class MemoryLogger : ILogger
    {
        /// <summary>
        /// The collection of <see cref="MemoryEvent"/>s that have been emitted to this <see cref="ILogger"/> so far
        /// </summary>
        /// <remarks>We use a <see cref="ConcurrentQueue{T}"/> here since it is actually a linked list underneath</remarks>
        private readonly ConcurrentQueue<MemoryEvent> events;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryLogger"/> class
        /// </summary>
        public MemoryLogger()
        {
            this.events = new ConcurrentQueue<MemoryEvent>();
        }

        /// <summary>
        /// Gets the collection of <see cref="MemoryEvent"/>s that have been emitted to this <see cref="ILogger"/> so far
        /// </summary>
        public IEnumerable<MemoryEvent> Events
        {
            get
            {
                foreach (var @event in this.events)
                {
                    yield return @event;
                }
            }
        }

        /// <summary>
        /// Emits a verbose event to memory
        /// </summary>
        /// <param name="id">The ID of the event that is being emitted</param>
        /// <param name="message">The message containing the specifics about the event being emitted</param>
        public void EmitDetail(int id, string message)
        {
            this.events.Enqueue(new MemoryEvent.DetailEvent(id, message));
        }

        /// <summary>
        /// Emits an error event to memory
        /// </summary>
        /// <param name="id">The ID of the event that is being emitted</param>
        /// <param name="message">The message containing the specifics about the event being emitted</param>
        public void EmitError(int id, string message)
        {
            this.events.Enqueue(new MemoryEvent.ErrorEvent(id, message));
        }

        /// <summary>
        /// Emits an information event to memory
        /// </summary>
        /// <param name="id">The ID of the event that is being emitted</param>
        /// <param name="message">The message containing the specifics about the event being emitted</param>
        public void EmitInformation(int id, string message)
        {
            this.events.Enqueue(new MemoryEvent.InformationEvent(id, message));
        }

        /// <summary>
        /// Emits a warning event to memory
        /// </summary>
        /// <param name="id">The ID of the event that is being emitted</param>
        /// <param name="message">The message containing the specifics about the event being emitted</param>
        public void EmitWarning(int id, string message)
        {
            this.events.Enqueue(new MemoryEvent.WarningEvent(id, message));
        }
    }
}
