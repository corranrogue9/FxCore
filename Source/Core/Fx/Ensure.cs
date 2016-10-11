namespace Fx
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
#if NET45
    using System.Runtime.CompilerServices;
#endif
    using System.Text.RegularExpressions;

    /// <summary>
    /// Provides utilities for validating the preconditions of arguments prior to their use
    /// </summary>
    /// <threadsafety static="true"/>
    public static class Ensure
    {
        /// <summary>
        /// A <see cref="Regex"/> that matches valid MAC addresses
        /// </summary>
        private static readonly Regex MacAddressExpression = new Regex("^[0-9A-Fa-f]{12}$", RegexOptions.Compiled);

        /// <summary>
        /// A <see cref="Regex"/> that matches valid SHA1s
        /// </summary>
        private static readonly Regex Sha1Expression = new Regex("^[0-9A-Fa-f]{40}$", RegexOptions.Compiled);

        /// <summary>
        /// A <see cref="Regex"/> that matches valid SHA1s
        /// </summary>
        private static readonly Regex Sha2Expression = new Regex("^[0-9A-Fa-f]{64}$", RegexOptions.Compiled);

        /// <summary>
        /// Ensures that <paramref name="value"/> is not null
        /// </summary>
        /// <typeparam name="T">The type of the value being validated</typeparam>
        /// <param name="value">The value to ensure is not null</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void NotNull<T>([ValidatedNotNull] T value, string name)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is not null and is not <see cref="string.Empty"/>
        /// </summary>
        /// <param name="value">The <see cref="string"/> to ensure is not null and is not <see cref="string.Empty"/></param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is <see cref="string.Empty"/></exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void NotNullOrEmptyString([ValidatedNotNull] string value, string name)
        {
            NotNull(value, name);

            if (value.Length == 0)
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Strings.EnsureNotNullOrEmptyString, name));
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is not null and contains at least one element
        /// </summary>
        /// <typeparam name="T">The type of the values in the <see cref="IEnumerable{T}"/> being validated</typeparam>
        /// <param name="value">The <see cref="IEnumerable{T}"/> to ensure is not null or and contains at least one element</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> contains no elements</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void EnumerableNotEmpty<T>([ValidatedNotNull] IEnumerable<T> value, string name)
        {
            NotNull(value, name);

            if (!value.Any())
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Strings.EnsureEnumerableNotEmpty, name));
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="byte"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void IsPositive(byte value, string name)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.CurrentCulture, Strings.EnsureIsPositive, name));
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is not a negative value
        /// </summary>
        /// <param name="value">The <see cref="sbyte"/> to ensure is not a negative value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is negative</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif

#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static void NotNegative(sbyte value, string name)
#pragma warning restore CS3001 // Argument type is not CLS-compliant
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.CurrentCulture, Strings.EnsureNotNegative, name));
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="sbyte"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif

#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static void IsPositive(sbyte value, string name)
#pragma warning restore CS3001 // Argument type is not CLS-compliant
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.CurrentCulture, Strings.EnsureIsPositive, name));
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is not a negative value
        /// </summary>
        /// <param name="value">The <see cref="short"/> to ensure is not a negative value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is negative</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void NotNegative(short value, string name)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.CurrentCulture, Strings.EnsureNotNegative, name));
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="short"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void IsPositive(short value, string name)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.CurrentCulture, Strings.EnsureIsPositive, name));
            }
        }
        
        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="ushort"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif

#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static void IsPositive(ushort value, string name)
#pragma warning restore CS3001 // Argument type is not CLS-compliant
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.CurrentCulture, Strings.EnsureIsPositive, name));
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is not a negative value
        /// </summary>
        /// <param name="value">The <see cref="int"/> to ensure is not a negative value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is negative</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void NotNegative(int value, string name)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.CurrentCulture, Strings.EnsureNotNegative, name));
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="int"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void IsPositive(int value, string name)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.CurrentCulture, Strings.EnsureIsPositive, name));
            }
        }
        
        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="uint"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif

#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static void IsPositive(uint value, string name)
#pragma warning restore CS3001 // Argument type is not CLS-compliant
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.CurrentCulture, Strings.EnsureIsPositive, name));
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is not a negative value
        /// </summary>
        /// <param name="value">The <see cref="long"/> to ensure is not a negative value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is negative</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void NotNegative(long value, string name)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.CurrentCulture, Strings.EnsureNotNegative, name));
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="long"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void IsPositive(long value, string name)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.CurrentCulture, Strings.EnsureIsPositive, name));
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="ulong"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static void IsPositive(ulong value, string name)
#pragma warning restore CS3001 // Argument type is not CLS-compliant
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.CurrentCulture, Strings.EnsureIsPositive, name));
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="decimal"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void NotNegative(decimal value, string name)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.CurrentCulture, Strings.EnsureNotNegative, name));
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="decimal"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void IsPositive(decimal value, string name)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.CurrentCulture, Strings.EnsureIsPositive, name));
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="double"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void NotNegative(double value, string name)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.CurrentCulture, Strings.EnsureNotNegative, name));
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="double"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void IsPositive(double value, string name)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.CurrentCulture, Strings.EnsureIsPositive, name));
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="float"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void NotNegative(float value, string name)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.CurrentCulture, Strings.EnsureNotNegative, name));
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="float"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void IsPositive(float value, string name)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.CurrentCulture, Strings.EnsureIsPositive, name));
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a valid enumeration
        /// </summary>
        /// <param name="value">The enumeration value to ensure is a valid value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not a valid value</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void IsDefinedEnum([ValidatedNotNull] Enum value, string name)
        {
            NotNull(value, name);

            var type = value.GetType();
            if (!Enum.IsDefined(type, value))
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.CurrentCulture, Strings.EnsureIsDefinedEnum, name, value.ToString()));
            }
        }

        /// <summary>
        /// Ensures that the type of <paramref name="value"/> is at least as derived as <paramref name="parent"/>
        /// </summary>
        /// <typeparam name="T">The type of the value that is ensured to be at least as derived as <paramref name="parent"/></typeparam>
        /// <param name="parent">the type to ensure that <paramref name="value"/>'s type is at least as derived as</param>
        /// <param name="value">The value of the type to ensure is at least as derived as <paramref name="parent"/></param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null or <paramref name="parent"/> is null</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the type of <paramref name="value"/> is not at least as derived as <paramref name="parent"/>
        /// </exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void IsInstance<T>([ValidatedNotNull] Type parent, [ValidatedNotNull] T value, string name)
        {
            NotNull(parent, nameof(parent));
            NotNull(value, name);

            if (!parent.IsInstanceOfType(value))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Strings.EnsureIsInstance, name, typeof(T).ToString(), parent.ToString()));
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a valid MAC address
        /// </summary>
        /// <param name="value">The <see cref="string"/> to ensure is a valid MAC address</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not a valid MAC address</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void IsValidMacAddress([ValidatedNotNull] string value, string name)
        {
            NotNull(value, name);

            if (!MacAddressExpression.IsMatch(value))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Strings.EnsureIsValidMacAddress, name, value, MacAddressExpression.ToString()));
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a valid SHA1
        /// </summary>
        /// <param name="value">The <see cref="string"/> to ensure is a valid SHA1</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not a valid SHA1</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void IsValidSha1([ValidatedNotNull] string value, string name)
        {
            NotNull(value, name);

            if (!Sha1Expression.IsMatch(value))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Strings.EnsureIsValidSha1, name, value, Sha1Expression.ToString()));
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a valid SHA2
        /// </summary>
        /// <param name="value">The <see cref="string"/> to ensure is a valid SHA2</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not a valid SHA1</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void IsValidSha2([ValidatedNotNull] string value, string name)
        {
            NotNull(value, name);

            if (!Sha2Expression.IsMatch(value))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Strings.EnsureIsValidSha2, name, value, Sha2Expression.ToString()));
            }
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a valid SHA1 or SHA2
        /// </summary>
        /// <param name="value">The <see cref="string"/> to ensure is a valid SHA1 or SHA2</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not a valid SHA1 and not a valid SHA2</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void IsValidSha1OrSha2([ValidatedNotNull] string value, string name)
        {
            NotNull(value, name);

            if (!Sha1Expression.IsMatch(value) && !Sha2Expression.IsMatch(value))
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.CurrentCulture, Strings.EnsureIsValidSha1OrSha2, name, value, Sha1Expression.ToString(), Sha2Expression.ToString()));
            }
        }
    }
}
