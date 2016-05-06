namespace System
{
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Security;

    using Fx;

    /// <summary>
    /// A <see cref="IEqualityComparer{T}"/> that compares <see cref="T:byte[]"/>s for equality
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed class ByteArrayComparer : IEqualityComparer<byte[]>
    {
        /// <summary>
        /// A singleton instance of the <see cref="ByteArrayComparer"/>
        /// </summary>
        private static readonly ByteArrayComparer Singleton = new ByteArrayComparer();
        
        /// <summary>
        /// Prevents a default instance of the <see cref="ByteArrayComparer"/> class from being created
        /// </summary>
        private ByteArrayComparer()
        {
        }

        /// <summary>
        /// Gets a singleton instance of the <see cref="ByteArrayComparer"/>
        /// </summary>
        public static ByteArrayComparer Instance
        {
            get
            {
                return Singleton;
            }
        }

        /// <summary>
        /// Determines whether or not the specified objects are equals
        /// </summary>
        /// <param name="x">The first object of type <see cref="T:byte[]"/> to compare</param>
        /// <param name="y">The second object of type <see cref="T:byte[]"/> to compare</param>
        /// <returns>true if the specified objects are equal; otherwise, false</returns>
        public bool Equals(byte[] x, byte[] y)
        {
            if (x == y)
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            if (x.Length != y.Length)
            {
                return false;
            }

            return SafeNativeMethods.memcmp(x, y, new UIntPtr(Convert.ToUInt32(x.Length))) == 0;
        }

        /// <summary>
        /// Returns a hash code for the specified object
        /// </summary>
        /// <param name="obj">The <see cref="object"/> for which a hash code is to be returned</param>
        /// <returns>A hash code for the specified object</returns>
        /// <exception cref="ArgumentNullException">The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null</exception>
        public int GetHashCode(byte[] obj)
        {
            Ensure.NotNull(obj, nameof(obj));

            var result = 0;
            for (int i = 0; i < obj.Length; ++i)
            {
                result ^= obj[i];
            }

            return result;
        }

        /// <summary>
        /// Unmanaged methods that are used for interacting with byte arrays in memory
        /// </summary>
        [SuppressUnmanagedCodeSecurity]
        private static class SafeNativeMethods
        {
#if !NET40
            // this message is a bug in pre-.NET 4.0 versions
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA5122:PInvokesShouldNotBeSafeCriticalFxCopRule")]
#endif
            [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int memcmp(byte[] ptr1, byte[] ptr2, UIntPtr num);
        }
    }
}
