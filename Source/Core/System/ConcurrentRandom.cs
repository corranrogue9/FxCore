#if NET40
namespace System
{
    using System.Threading;

    /// <summary>
    /// A pseudo-random number generator which can be accessed from multiple threads concurrently
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed class ConcurrentRandom : Random, IDisposable
    {
        /// <summary>
        /// The <see cref="Random"/> that we should delegate to for each thread that is requesting random numbers
        /// </summary>
        private readonly ThreadLocal<Random> random;

        /// <summary>
        /// Whether or not this object is disposed
        /// </summary>
        private bool disposed;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ConcurrentRandom"/> class
        /// </summary>
        public ConcurrentRandom()
        {
            this.random = new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));
            this.disposed = false;
        }
        
        /// <summary>
        /// Returns a non-negative random integer
        /// </summary>
        /// <returns>A 32-bit signed integer that is greater than or equal to 0 and less than <see cref="int.MaxValue"/></returns>
        public override int Next()
        {
            return this.random.Value.Next();
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
            return this.random.Value.Next(minValue, maxValue);
        }

        /// <summary>
        /// Returns a non-negative random integer that is less than the specified maximum
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the random number generated</param>
        /// <returns>A 32-bit signed integer that is greater than or equal to 0, and less than <paramref name="maxValue"/>; that is, the range of the return values ordinarily includes 0 but not <paramref name="maxValue"/>. However, if <paramref name="maxValue"/> equals 0, <paramref name="maxValue"/> is returned</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="maxValue"/> is less than 0</exception>
        public override int Next(int maxValue)
        {
            return this.random.Value.Next(maxValue);
        }

        /// <summary>
        /// Fills the elements of a specified array of bytes with random numbers
        /// </summary>
        /// <param name="buffer">An array of bytes to contain random numbers</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="buffer"/> is null</exception>
        public override void NextBytes(byte[] buffer)
        {
            this.random.Value.NextBytes(buffer);
        }

        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0
        /// </summary>
        /// <returns>A double-precision floating point number that is greater than or equal to 0.0, and less than 1.0</returns>
        public override double NextDouble()
        {
            return this.random.Value.NextDouble();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources
        /// </summary>
        public void Dispose()
        {
            if (this.disposed)
            {
                return;
            }

            this.random.Dispose();

            this.disposed = true;
        }
    }
}
#endif