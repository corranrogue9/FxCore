namespace Fx.Logging
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Events that are emitted to a log that exists only in memory
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [DataContract(Name = "MemoryEvent")]
    [KnownType(typeof(MemoryEvent.DetailEvent))]
    [KnownType(typeof(MemoryEvent.ErrorEvent))]
    [KnownType(typeof(MemoryEvent.InformationEvent))]
    [KnownType(typeof(MemoryEvent.WarningEvent))]
    public abstract class MemoryEvent
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="MemoryEvent"/> class from being created
        /// </summary>
        private MemoryEvent()
        {
        }

        /// <summary>
        /// A <see cref="MemoryEvent"/> that stores the specifics of a detail event emitted to a log
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        [DataContract(Name = "DetailEvent")]
        public sealed class DetailEvent : MemoryEvent
        {
            /// <summary>
            /// The ID of the event that was emitted
            /// </summary>
            [DataMember(Name = "Id", IsRequired = true)]
            private readonly int id;

            /// <summary>
            /// The message containing the specifics about the event that was emitted
            /// </summary>
            [DataMember(Name = "Message", IsRequired = true)]
            private readonly string message;

            /// <summary>
            /// Initializes a new instance of the <see cref="DetailEvent"/> class
            /// </summary>
            /// <param name="id">The ID of the event that was emitted</param>
            /// <param name="message">The message containing the specifics about the event that was emitted</param>
            public DetailEvent(int id, string message)
            {
                this.id = id;
                this.message = message;
            }

            /// <summary>
            /// Gets the ID of the event that was emitted
            /// </summary>
            public int Id
            {
                get
                {
                    return this.id;
                }
            }

            /// <summary>
            /// Gets the message containing the specifics about the event that was emitted
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
        /// A <see cref="MemoryEvent"/> that stores the specifics of an information event emitted to a log
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        [DataContract(Name = "InformationEvent")]
        public sealed class InformationEvent : MemoryEvent
        {
            /// <summary>
            /// The ID of the event that was emitted
            /// </summary>
            [DataMember(Name = "Id", IsRequired = true)]
            private readonly int id;

            /// <summary>
            /// The message containing the specifics about the event that was emitted
            /// </summary>
            [DataMember(Name = "Message", IsRequired = true)]
            private readonly string message;

            /// <summary>
            /// Initializes a new instance of the <see cref="InformationEvent"/> class
            /// </summary>
            /// <param name="id">The ID of the event that was emitted</param>
            /// <param name="message">The message containing the specifics about the event that was emitted</param>
            public InformationEvent(int id, string message)
            {
                this.id = id;
                this.message = message;
            }

            /// <summary>
            /// Gets the ID of the event that was emitted
            /// </summary>
            public int Id
            {
                get
                {
                    return this.id;
                }
            }

            /// <summary>
            /// Gets the message containing the specifics about the event that was emitted
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
        /// A <see cref="MemoryEvent"/> that stores the specifics of a warning event emitted to a log
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        [DataContract(Name = "WarningEvent")]
        public sealed class WarningEvent : MemoryEvent
        {
            /// <summary>
            /// The ID of the event that was emitted
            /// </summary>
            [DataMember(Name = "Id", IsRequired = true)]
            private readonly int id;

            /// <summary>
            /// The message containing the specifics about the event that was emitted
            /// </summary>
            [DataMember(Name = "Message", IsRequired = true)]
            private readonly string message;

            /// <summary>
            /// Initializes a new instance of the <see cref="WarningEvent"/> class
            /// </summary>
            /// <param name="id">The ID of the event that was emitted</param>
            /// <param name="message">The message containing the specifics about the event that was emitted</param>
            public WarningEvent(int id, string message)
            {
                this.id = id;
                this.message = message;
            }

            /// <summary>
            /// Gets the ID of the event that was emitted
            /// </summary>
            public int Id
            {
                get
                {
                    return this.id;
                }
            }

            /// <summary>
            /// Gets the message containing the specifics about the event that was emitted
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
        /// A <see cref="MemoryEvent"/> that stores the specifics of an error event emitted to a log
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        [DataContract(Name = "ErrorEvent")]
        public sealed class ErrorEvent : MemoryEvent
        {
            /// <summary>
            /// The ID of the event that was emitted
            /// </summary>
            [DataMember(Name = "Id", IsRequired = true)]
            private readonly int id;

            /// <summary>
            /// The message containing the specifics about the event that was emitted
            /// </summary>
            [DataMember(Name = "Message", IsRequired = true)]
            private readonly string message;

            /// <summary>
            /// Initializes a new instance of the <see cref="ErrorEvent"/> class
            /// </summary>
            /// <param name="id">The ID of the event that was emitted</param>
            /// <param name="message">The message containing the specifics about the event that was emitted</param>
            public ErrorEvent(int id, string message)
            {
                this.id = id;
                this.message = message;
            }

            /// <summary>
            /// Gets the ID of the event that was emitted
            /// </summary>
            public int Id
            {
                get
                {
                    return this.id;
                }
            }

            /// <summary>
            /// Gets the message containing the specifics about the event that was emitted
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
