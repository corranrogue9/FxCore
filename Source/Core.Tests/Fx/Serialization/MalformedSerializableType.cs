namespace Fx.Serialization
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// A mock type that is not serializable to be used for testing
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [DataContract(Name = "MalformedSerializableType")]
    public sealed class MalformedSerializableType
    {
        /// <summary>
        /// A singleton instance of the <see cref="MalformedSerializableType"/>
        /// </summary>
        private static readonly MalformedSerializableType Singleton = new Func<MalformedSerializableType>(() =>
        {
            var first = new MalformedSerializableType();
            var second = new MalformedSerializableType();
            first.Data = second;
            second.Data = first;
            return first;
        }).Invoke();

        /// <summary>
        /// Prevents a default instance of the <see cref="MalformedSerializableType"/> class from being created
        /// </summary>
        private MalformedSerializableType()
        {
        }

        /// <summary>
        /// Gets a singleton instance of the <see cref="MalformedSerializableType"/>
        /// </summary>
        public static MalformedSerializableType Instance
        {
            get
            {
                return Singleton;
            }
        }

        /// <summary>
        /// Gets or sets <see cref="MalformedSerializableType"/> that represents a nested data type
        /// </summary>
        [DataMember(Name = "Data", IsRequired = true)]
        public MalformedSerializableType Data { get; set; }
    }
}
