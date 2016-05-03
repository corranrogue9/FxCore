namespace Fx
{
    using System;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="Ensure"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class EnsureUnitTests
    {
        /// <summary>
        /// Ensures that if a class argument is not null, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if a class argument is not null, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void NotNullClass()
        {
            Ensure.NotNull(new object(), "classname");
        }

        /// <summary>
        /// Ensures that if a struct argument is not null, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if a struct argument is not null, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void NotNullStruct()
        {
            Ensure.NotNull(TimeSpan.FromMinutes(1), "structname");
        }

#if NET35
        /// <summary>
        /// Ensures that if a function argument is not null, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if a function argument is not null, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void NotNullFunc()
        {
            Ensure.NotNull<Func<string>>(() => "test", "funcname");
        }

        /// <summary>
        /// Ensures that if an action argument is not null, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if an action argument is not null, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void NotNullAction()
        {
            Ensure.NotNull<Action>(() => { }, "actionname");
        }
#endif

        /// <summary>
        /// Ensures that if an enumeration argument is not null, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if an enumeration argument is not null, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void NotNullEnum()
        {
            Ensure.NotNull(DateTimeKind.Local, "enumname");
        }

        /// <summary>
        /// Ensures that if a string has a value, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if a string has a value, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void NotNullOrEmptyString()
        {
            Ensure.NotNullOrEmptyString("teststring", "stringname");
        }

        /// <summary>
        /// Ensures that if an argument is an enumerable with a single element, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if an argument is an enumerable with a single element, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void EnumerableNotEmptyOneElement()
        {
            Ensure.EnumerableNotEmpty(new[] { "value" }, "enumerablename");
        }

        /// <summary>
        /// Ensures that if an argument is an enumerable with multiple elements, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if an argument is an enumerable with multiple elements, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void EnumerableNotEmptyMultipleElements()
        {
            Ensure.EnumerableNotEmpty(new[] { "value1", "value2" }, "enumerablename");
        }

        /// <summary>
        /// Ensures that if an argument is zero, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if an argument is zero, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void NotNegativeZero()
        {
            Ensure.NotNegative((sbyte)0x00, "sbytevalue");
            Ensure.NotNegative((short)0, "shortvalue");
            Ensure.NotNegative(0, "intvalue");
            Ensure.NotNegative(0F, "floatvalue");
            Ensure.NotNegative(0L, "longvalue");
            Ensure.NotNegative(0D, "doublevalue");
            Ensure.NotNegative(0M, "decimalvalue");
        }

        /// <summary>
        /// Ensures that if an argument is positive, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if an argument is positive, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void NotNegativePositive()
        {
            Ensure.NotNegative((sbyte)0x10, "sbytevalue");
            Ensure.NotNegative((short)100, "shortvalue");
            Ensure.NotNegative(100, "intvalue");
            Ensure.NotNegative(100F, "floatvalue");
            Ensure.NotNegative(100L, "longvalue");
            Ensure.NotNegative(100D, "doublevalue");
            Ensure.NotNegative(100M, "decimalvalue");
        }

        /// <summary>
        /// Ensures that if an argument is positive, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if an argument is positive, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void IsPositive()
        {
            Ensure.IsPositive((byte)0x10, "bytevalue");
            Ensure.IsPositive((sbyte)0x10, "sbytevalue");
            Ensure.IsPositive((short)100, "shortvalue");
            Ensure.IsPositive((ushort)100, "ushortvalue");
            Ensure.IsPositive(100, "intvalue");
            Ensure.IsPositive(100U, "uintvalue");
            Ensure.IsPositive(100F, "floatvalue");
            Ensure.IsPositive(100L, "longvalue");
            Ensure.IsPositive(100UL, "ulongvalue");
            Ensure.IsPositive(100D, "doublevalue");
            Ensure.IsPositive(100M, "decimalvalue");
        }

        /// <summary>
        /// Ensures that if an argument is a defined enumeration value, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if an argument is a defined enumeration value, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void IsDefinedEnum()
        {
            Ensure.IsDefinedEnum(DateTimeKind.Local, "enumvalue");
        }

        /// <summary>
        /// Ensures that if an argument is a defined flag enumeration value, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if an argument is a defined flag enumeration value, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void IsDefinedEnumFileAccess()
        {
            Ensure.IsDefinedEnum(FileAccess.Read, "enumvalue");
        }

        /// <summary>
        /// Ensures that if an argument is the same type as a provided type, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if an argument is the same type as a provided type, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void IsInstanceSameType()
        {
            Ensure.IsInstance(typeof(MockDerivedClass), new MockDerivedClass(), "instancename");
        }

        /// <summary>
        /// Ensures that if an argument is a less derived type than a provided type, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if an argument is a less derived type than a provided type, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void IsInstanceLessDerivedType()
        {
            Ensure.IsInstance(typeof(MockBaseClass), new MockDerivedClass(), "instancename");
        }

        /// <summary>
        /// Ensures that if a string is a valid MAC address with uppercase characters, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if a string is a valid MAC address with uppercase characters, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidMacAddressUppercase()
        {
            Ensure.IsValidMacAddress("DEADBEEFDEAD", "macaddressname");
            Ensure.IsValidMacAddress("DEADBEEFDEA1", "macaddressname");
            Ensure.IsValidMacAddress("1EADBEEFDEC2", "macaddressname");
            Ensure.IsValidMacAddress("0123456789AB", "macaddressname");
        }

        /// <summary>
        /// Ensures that if a string is a valid MAC address with lowercase characters, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if a string is a valid MAC address with lowercase characters, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidMacAddressLowercase()
        {
            Ensure.IsValidMacAddress("deadbeefdead", "macaddressname");
            Ensure.IsValidMacAddress("deadbeefdea1", "macaddressname");
            Ensure.IsValidMacAddress("1eadbeefdec2", "macaddressname");
            Ensure.IsValidMacAddress("0123456789ab", "macaddressname");
        }

        /// <summary>
        /// Ensures that if a string is a valid SHA1 with uppercase characters, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if a string is a valid SHA1 with uppercase characters, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidSha1Uppercase()
        {
            Ensure.IsValidSha1("DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEF", "shaname");
            Ensure.IsValidSha1("DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEE1", "shaname");
            Ensure.IsValidSha1("1EADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEF", "shaname");
            Ensure.IsValidSha1("0123456789ABCDEF0123456789ABCDEF01234567", "shaname");
        }

        /// <summary>
        /// Ensures that if a string is a valid SHA1 with lowercase characters, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if a string is a valid SHA1 with lowercase characters, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidSha1Lowercase()
        {
            Ensure.IsValidSha1("deadbeefdeadbeefdeadbeefdeadbeefdeadbeef", "shaname");
            Ensure.IsValidSha1("deadbeefdeadbeefdeadbeefdeadbeefdeadbee1", "shaname");
            Ensure.IsValidSha1("1eadbeefdeadbeefdeadbeefdeadbeefdeadbeef", "shaname");
            Ensure.IsValidSha1("0123456789abcdef0123456789abcdef01234567", "shaname");
        }

        /// <summary>
        /// Ensures that if a string is a valid SHA2 with uppercase characters, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if a string is a valid SHA2 with uppercase characters, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidSha2Uppercase()
        {
            Ensure.IsValidSha2("DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEF", "shaname");
            Ensure.IsValidSha2("DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEE1", "shaname");
            Ensure.IsValidSha2("1EADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEF", "shaname");
            Ensure.IsValidSha2("0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF", "shaname");
        }

        /// <summary>
        /// Ensures that if a string is a valid SHA2 with lowercase characters, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if a string is a valid SHA2 with lowercase characters, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidSha2Lowercase()
        {
            Ensure.IsValidSha2("deadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeef", "shaname");
            Ensure.IsValidSha2("deadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbee1", "shaname");
            Ensure.IsValidSha2("1eadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeef", "shaname");
            Ensure.IsValidSha2("0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef", "shaname");
        }

        /// <summary>
        /// Ensures that if a string is a valid SHA1 or SHA2 with uppercase characters, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if a string is a valid SHA1 or SHA2 with uppercase characters, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidSha1OrSha2Uppercase()
        {
            Ensure.IsValidSha1OrSha2("DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEF", "shaname");
            Ensure.IsValidSha1OrSha2("DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEE1", "shaname");
            Ensure.IsValidSha1OrSha2("1EADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEF", "shaname");
            Ensure.IsValidSha1OrSha2("0123456789ABCDEF0123456789ABCDEF01234567", "shaname");
            Ensure.IsValidSha1OrSha2("DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEF", "shaname");
            Ensure.IsValidSha1OrSha2("DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEE1", "shaname");
            Ensure.IsValidSha1OrSha2("1EADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEF", "shaname");
            Ensure.IsValidSha1OrSha2("0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF", "shaname");
        }

        /// <summary>
        /// Ensures that if a string is a valid SHA1 or SHA2 with lowercase characters, it will not throw
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if a string is a valid SHA1 or SHA2 with lowercase characters, it will not throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidSha1OrSha2Lowercase()
        {
            Ensure.IsValidSha1OrSha2("deadbeefdeadbeefdeadbeefdeadbeefdeadbeef", "shaname");
            Ensure.IsValidSha1OrSha2("deadbeefdeadbeefdeadbeefdeadbeefdeadbee1", "shaname");
            Ensure.IsValidSha1OrSha2("1eadbeefdeadbeefdeadbeefdeadbeefdeadbeef", "shaname");
            Ensure.IsValidSha1OrSha2("0123456789abcdef0123456789abcdef01234567", "shaname");
            Ensure.IsValidSha1OrSha2("deadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeef", "shaname");
            Ensure.IsValidSha1OrSha2("deadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbee1", "shaname");
            Ensure.IsValidSha1OrSha2("1eadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeef", "shaname");
            Ensure.IsValidSha1OrSha2("0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef", "shaname");
        }
    }
}
