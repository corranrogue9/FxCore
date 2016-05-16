namespace System.Diagnostics
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using Fx;
    
    /// <summary>
    /// A single event that has been emitted by a <see cref="TraceListener"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [DataContract(Name = "TraceEvent")]
    [KnownType(typeof(TraceEvent.DataEvent))]
    [KnownType(typeof(TraceEvent.MessageEvent))]
    [KnownType(typeof(TraceEvent.WriteEvent))]
    public abstract class TraceEvent
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="TraceEvent"/> class from being created
        /// </summary>
        private TraceEvent()
        {
        }

        /// <summary>
        /// A <see cref="TraceEvent"/> that represents an event that was emitted by a <see cref="TraceListener"/> using the <see cref="TraceListener.Write(string)"/> 
        /// call
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        [DataContract(Name = "WriteEvent")]
        public sealed class WriteEvent : TraceEvent
        {
            /// <summary>
            /// The message that was emitted as part of this event
            /// </summary>
            [DataMember(Name = "Message", IsRequired = true)]
            private readonly string message;

            /// <summary>
            /// Initializes a new instance of the <see cref="WriteEvent"/> class
            /// </summary>
            /// <param name="message">The message being published by this event</param>
            public WriteEvent(string message)
            {
                this.message = message;
            }

            /// <summary>
            /// Gets the message that was emitted as part of this event
            /// </summary>
            public string Message
            {
                get
                {
                    return this.message;
                }
            }
        }

        /// <summary>
        /// A <see cref="TraceEvent"/> that represents an event that was emitted by a <see cref="TraceListener"/> using the 
        /// <see cref="TraceListener.TraceData(TraceEventCache, string, TraceEventType, int, object[])"/> call
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        [DataContract(Name = "DataEvent")]
        public sealed class DataEvent : TraceEvent
        {
            /// <summary>
            /// The call stack at the time that this event was emitted
            /// </summary>
            [DataMember(Name = "CallStack", IsRequired = true)]
            private readonly string callStack;

            /// <summary>
            /// The time at which this event was emitted
            /// </summary>
            [DataMember(Name = "DateTime", IsRequired = true)]
            private readonly DateTime dateTime;

            /// <summary>
            /// The correlation data at the time this event was emitted
            /// </summary>
            [DataMember(Name = "LogicalOperationStack", IsRequired = true)]
            private readonly Stack logicalOperationStack;

            /// <summary>
            /// The ID of the process that emitted this event
            /// </summary>
            [DataMember(Name = "ProcessId", IsRequired = true)]
            private readonly int processId;

            /// <summary>
            /// The ID of the thread that emitted this event
            /// </summary>
            [DataMember(Name = "ThreadId", IsRequired = true)]
            private readonly string threadId;

            /// <summary>
            /// The number of ticks on the machine when this event was emitted
            /// </summary>
            [DataMember(Name = "Timestamp", IsRequired = true)]
            private readonly long timestamp;

            /// <summary>
            /// The name of the <see cref="TraceSource"/> that emitted this event
            /// </summary>
            [DataMember(Name = "Source", IsRequired = true)]
            private readonly string source;

            /// <summary>
            /// The <see cref="TraceEventType"/> of this event
            /// </summary>
            [DataMember(Name = "EventType", IsRequired = true)]
            private readonly TraceEventType eventType;

            /// <summary>
            /// The ID of this event
            /// </summary>
            [DataMember(Name = "Id", IsRequired = true)]
            private readonly int id;

            /// <summary>
            /// The data that was emitted as part of this event
            /// </summary>
            [DataMember(Name = "Data", IsRequired = true)]
            private readonly IEnumerable<object> data;

            /// <summary>
            /// Initializes a new instance of the <see cref="DataEvent"/> class
            /// </summary>
            /// <param name="eventCache">The <see cref="TraceEventCache"/> that was populated to emit this event</param>
            /// <param name="source">The name of <see cref="TraceSource"/> that is emitting this event</param>
            /// <param name="eventType">The <see cref="TraceEventType"/> of this event</param>
            /// <param name="id">The ID of this event</param>
            /// <param name="data">The data being publishing by this event</param>
            /// <exception cref="ArgumentNullException">Thrown if <paramref name="eventCache"/> is null</exception>
            /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="eventType"/> is not a valid <see cref="TraceEvent"/></exception>
            public DataEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, IEnumerable<object> data)
            {
                Ensure.NotNull(eventCache, nameof(eventCache));
                Ensure.IsDefinedEnum(eventType, nameof(eventType));

                this.callStack = eventCache.Callstack;
                this.dateTime = eventCache.DateTime;
                this.logicalOperationStack = new Stack(eventCache.LogicalOperationStack);
                this.processId = eventCache.ProcessId;
                this.threadId = eventCache.ThreadId;
                this.timestamp = eventCache.Timestamp;
                this.source = source;
                this.eventType = eventType;
                this.id = id;
                this.data = new List<object>(data);
            }

            /// <summary>
            /// Gets the call stack at the time that this event was emitted
            /// </summary>
            public string CallStack
            {
                get
                {
                    return this.callStack;
                }
            }

            /// <summary>
            /// Gets the time at which this event was emitted
            /// </summary>
            public DateTime DateTime
            {
                get
                {
                    return this.dateTime;
                }
            }

            /// <summary>
            /// Gets the correlation data at the time this event was emitted
            /// </summary>
            public Stack LogicalOperationStack
            {
                get
                {
                    return new Stack(this.logicalOperationStack);
                }
            }

            /// <summary>
            /// Gets the ID of the process that emitted this event
            /// </summary>
            public int ProcessId
            {
                get
                {
                    return this.processId;
                }
            }

            /// <summary>
            /// Gets the ID of the thread that emitted this event
            /// </summary>
            public string ThreadId
            {
                get
                {
                    return this.threadId;
                }
            }

            /// <summary>
            /// Gets the number of ticks on the machine when this event was emitted
            /// </summary>
            public long Timestamp
            {
                get
                {
                    return this.timestamp;
                }
            }

            /// <summary>
            /// Gets the name of the <see cref="TraceSource"/> that emitted this event
            /// </summary>
            public string Source
            {
                get
                {
                    return this.source;
                }
            }

            /// <summary>
            /// Gets the <see cref="TraceEventType"/> of this event
            /// </summary>
            public TraceEventType EventType
            {
                get
                {
                    return this.eventType;
                }
            }

            /// <summary>
            /// Gets the ID of this event
            /// </summary>
            public int Id
            {
                get
                {
                    return this.id;
                }
            }

            /// <summary>
            /// Gets the data that was emitted as part of this event
            /// </summary>
            public IEnumerable<object> Data
            {
                get
                {
                    foreach (var obj in this.data)
                    {
                        yield return obj;
                    }
                }
            }
        }

        /// <summary>
        /// A <see cref="TraceEvent"/> that represents an event that was emitted by a <see cref="TraceListener"/> using the 
        /// <see cref="TraceListener.TraceEvent(TraceEventCache, string, TraceEventType, int, string)"/> call
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        [DataContract(Name = "MessageEvent")]
        public sealed class MessageEvent : TraceEvent
        {
            /// <summary>
            /// The call stack at the time that this event was emitted
            /// </summary>
            [DataMember(Name = "CallStack", IsRequired = true)]
            private readonly string callStack;

            /// <summary>
            /// The time at which this event was emitted
            /// </summary>
            [DataMember(Name = "DateTime", IsRequired = true)]
            private readonly DateTime dateTime;

            /// <summary>
            /// The correlation data at the time this event was emitted
            /// </summary>
            [DataMember(Name = "LogicalOperationStack", IsRequired = true)]
            private readonly Stack logicalOperationStack;

            /// <summary>
            /// The ID of the process that emitted this event
            /// </summary>
            [DataMember(Name = "ProcessId", IsRequired = true)]
            private readonly int processId;

            /// <summary>
            /// The ID of the thread that emitted this event
            /// </summary>
            [DataMember(Name = "ThreadId", IsRequired = true)]
            private readonly string threadId;

            /// <summary>
            /// The number of ticks on the machine when this event was emitted
            /// </summary>
            [DataMember(Name = "Timestamp", IsRequired = true)]
            private readonly long timestamp;

            /// <summary>
            /// The name of the <see cref="TraceSource"/> that emitted this event
            /// </summary>
            [DataMember(Name = "Source", IsRequired = true)]
            private readonly string source;

            /// <summary>
            /// The <see cref="TraceEventType"/> of this event
            /// </summary>
            [DataMember(Name = "EventType", IsRequired = true)]
            private readonly TraceEventType eventType;

            /// <summary>
            /// The ID of this event
            /// </summary>
            [DataMember(Name = "Id", IsRequired = true)]
            private readonly int id;

            /// <summary>
            /// The message that was emitted as part of this event
            /// </summary>
            [DataMember(Name = "Message", IsRequired = true)]
            private readonly string message;

            /// <summary>
            /// Initializes a new instance of the <see cref="MessageEvent"/> class
            /// </summary>
            /// <param name="eventCache">The <see cref="TraceEventCache"/> that was populated to emit this event</param>
            /// <param name="source">The name of <see cref="TraceSource"/> that is emitting this event</param>
            /// <param name="eventType">The <see cref="TraceEventType"/> of this event</param>
            /// <param name="id">The ID of this event</param>
            /// <param name="message">The message being published by this event</param>
            /// <exception cref="ArgumentNullException">Thrown if <paramref name="eventCache"/> is null</exception>
            /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="eventType"/> is not a valid <see cref="TraceEventType"/></exception>
            public MessageEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
            {
                Ensure.NotNull(eventCache, nameof(eventCache));
                Ensure.IsDefinedEnum(eventType, nameof(eventType));

                this.callStack = eventCache.Callstack;
                this.dateTime = eventCache.DateTime;
                this.logicalOperationStack = new Stack(eventCache.LogicalOperationStack);
                this.processId = eventCache.ProcessId;
                this.threadId = eventCache.ThreadId;
                this.timestamp = eventCache.Timestamp;
                this.source = source;
                this.eventType = eventType;
                this.id = id;
                this.message = message;
            }

            /// <summary>
            /// Gets the call stack at the time that this event was emitted
            /// </summary>
            public string CallStack
            {
                get
                {
                    return this.callStack;
                }
            }

            /// <summary>
            /// Gets the time at which this event was emitted
            /// </summary>
            public DateTime DateTime
            {
                get
                {
                    return this.dateTime;
                }
            }

            /// <summary>
            /// Gets the correlation data at the time this event was emitted
            /// </summary>
            public Stack LogicalOperationStack
            {
                get
                {
                    return new Stack(this.logicalOperationStack);
                }
            }

            /// <summary>
            /// Gets the ID of the process that emitted this event
            /// </summary>
            public int ProcessId
            {
                get
                {
                    return this.processId;
                }
            }

            /// <summary>
            /// Gets the ID of the thread that emitted this event
            /// </summary>
            public string ThreadId
            {
                get
                {
                    return this.threadId;
                }
            }

            /// <summary>
            /// Gets the number of ticks on the machine when this event was emitted
            /// </summary>
            public long Timestamp
            {
                get
                {
                    return this.timestamp;
                }
            }

            /// <summary>
            /// Gets the name of the <see cref="TraceSource"/> that emitted this event
            /// </summary>
            public string Source
            {
                get
                {
                    return this.source;
                }
            }

            /// <summary>
            /// Gets the <see cref="TraceEventType"/> of this event
            /// </summary>
            public TraceEventType EventType
            {
                get
                {
                    return this.eventType;
                }
            }

            /// <summary>
            /// Gets the ID of this event
            /// </summary>
            public int Id
            {
                get
                {
                    return this.id;
                }
            }

            /// <summary>
            /// Gets the message that was emitted as part of this event
            /// </summary>
            public string Message
            {
                get
                {
                    return this.message;
                }
            }
        }
    }
}
