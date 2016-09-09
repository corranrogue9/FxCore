namespace System
{
    using System.Threading;

    using Fx;

    /// <summary>
    /// A <see cref="Random"/> implementation that reads from a predictable set of data bytes for testing purposes
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed class MockRandom : Random
    {
        /// <summary>
        /// The range of the <see cref="int"/> values
        /// </summary>
        private const long IntegerRange = (long)int.MaxValue - int.MinValue + 1;

        /// <summary>
        /// The <see cref="T:byte[]"/> that will be the source of the resulting "random" values
        /// </summary>
        private readonly byte[] data;

        /// <summary>
        /// The current index within <see cref="data"/> that should be read from next
        /// </summary>
        private int index;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockRandom"/> class
        /// </summary>
        /// <param name="data">The <see cref="T:byte[]"/> that will be the source of the resulting "random" values</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="data"/> is null</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="data"/> is empty</exception>
        public MockRandom(byte[] data)
        {
            Ensure.NotNull(data, nameof(data));
            Ensure.EnumerableNotEmpty(data, nameof(data));

            this.data = data.Clone() as byte[];

            this.index = 0;
        }

        /// <summary>
        /// Returns a non-negative random integer
        /// </summary>
        /// <returns>A 32-bit signed integer that is greater than or equal to 0 and less than <see cref="int.MaxValue"/></returns>
        public override int Next()
        {
            return this.Next(0, int.MaxValue);
        }

        /// <summary>
        /// Returns a non-negative random integer that is less than the specified maximum
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the random number generated</param>
        /// <returns>A 32-bit signed integer that is greater than or equal to 0, and less than <paramref name="maxValue"/>; that is, the range of the return values ordinarily includes 0 but not <paramref name="maxValue"/>. However, if <paramref name="maxValue"/> equals 0, <paramref name="maxValue"/> is returned</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="maxValue"/> is less than 0</exception>
        public override int Next(int maxValue)
        {
            Ensure.NotNegative(maxValue, nameof(maxValue));

            return this.Next(0, maxValue);
        }

        /// <summary>
        /// Returns a random integer that is within a specified range
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned</param>
        /// <param name="maxValue">The exclusive upper bound of the random number returned</param>
        /// <returns>A 32-bit signed integer greater than or equal to <paramref name="minValue"/> and less than <paramref name="maxValue"/>; that is, the range of return values includes <paramref name="minValue"/> but not <paramref name="maxValue"/>. If <paramref name="minValue"/> equals <paramref name="maxValue"/>, <paramref name="minValue"/> is returned</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="minValue"/> is greater than <paramref name="maxValue"/></exception>
        public override int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(minValue));
            }

            var buffer = new byte[4];
            this.NextBytes(buffer);

            var a = BitConverter.ToInt32(buffer, 0);
            //// int.MinValue <= a <= int.MaxValue
            var b = a - (long)int.MinValue;
            //// 0 <= b <= int.MaxValue - int.MinValue
            var c = b * (1.0 / IntegerRange);
            //// 0 <= c < 1
            var d = c * ((long)maxValue - minValue);
            //// 0 <= d < maxValue - minValue
            var e = (long)d + minValue;
            //// minValue <= thing7 < maxValue
            return (int)e;
        }

        /// <summary>
        /// Fills the elements of a specified array of bytes with random numbers
        /// </summary>
        /// <param name="buffer">An array of bytes to contain random numbers</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="buffer"/> is null</exception>
        public override void NextBytes(byte[] buffer)
        {
            Ensure.NotNull(buffer, nameof(buffer));

            var end = Interlocked.Add(ref this.index, buffer.Length);
            var start = (end - buffer.Length) % this.data.Length;

            var written = 0;
            while (written < buffer.Length)
            {
                var dataLength = this.data.Length - start;
                var bufferLength = buffer.Length - written;
                var length = dataLength < bufferLength ? dataLength : bufferLength;
                Array.Copy(this.data, start, buffer, written, length);
                written += length;
                start = 0;
            }
        }

        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0
        /// </summary>
        /// <returns>A double-precision floating point number that is greater than or equal to 0.0, and less than 1.0</returns>
        public override double NextDouble()
        {
            return this.Next() * (1.0 / int.MaxValue);
        }
    }
}
