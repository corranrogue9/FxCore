namespace Fx.Logging
{
    using System.Runtime.Serialization;

    /// <summary>
    /// A data type that indicates specific kind of event that may be emitted to a <see cref="ILogger"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [DataContract(Name = "EventIdentifier")]
    public sealed class EventIdentifier
    {
        /// <summary>
        /// The numeric representation that uniquely identifies this kind of event from other kinds of events
        /// </summary>
        [DataMember(Name = "Id", IsRequired = true)]
        private readonly int id;

        /// <summary>
        /// The format of the messages that events of this kind will have
        /// </summary>
        [DataMember(Name = "MessageFormat", IsRequired = true)]
        private readonly string messageFormat;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventIdentifier"/> class
        /// </summary>
        /// <param name="id">The numeric representation that uniquely identifies this kind of event from other kinds of events</param>
        /// <param name="messageFormat">The format of the messages that events of this kind will have</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="messageFormat"/> is null</exception>
        public EventIdentifier(int id, string messageFormat)
        {
            Ensure.NotNull(messageFormat, nameof(messageFormat));

            this.id = id;
            this.messageFormat = messageFormat;
        }

        /// <summary>
        /// Gets the numeric representation that uniquely identifies this kind of event from other kinds of events
        /// </summary>
        public int Id
        {
            get
            {
                return this.id;
            }
        }

        /// <summary>
        /// Gets the format of the messages that events of this kind will have
        /// </summary>
        public string MessageFormat
        {
            get
            {
                return this.messageFormat;
            }
        }
    }
}
