namespace Fx.Serialization
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// A mock type that is serializable to be used for testing
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [Serializable]
    [DataContract(Name = "SerializableType")]
    public sealed class SerializableType : IEquatable<SerializableType>
    {
        /// <summary>
        /// A <see cref="string"/> field for a serializable type
        /// </summary>
        [DataMember(Name = "First", IsRequired = true)]
        private string first;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerializableType"/> class
        /// </summary>
        /// <param name="first">The <see cref="string"/> containing the data that should be included in the new instance</param>
        public SerializableType(string first)
        {
            this.first = first;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="SerializableType"/> class from being created
        /// </summary>
        private SerializableType()
        {
        }

        /// <summary>
        /// Gets or sets a <see cref="string"/> field for a serializable type
        /// </summary>
        public string First
        {
            get
            {
                return this.first;
            }

            set
            {
                this.first = value;
            }
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type
        /// </summary>
        /// <param name="other">An object to compare with this object</param>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false</returns>
        public bool Equals(SerializableType other)
        {
            if (other == null)
            {
                return false;
            }

            if (!string.Equals(other.first, this.first))
            {
                return false;
            }

            return true;
        }
    }
}
