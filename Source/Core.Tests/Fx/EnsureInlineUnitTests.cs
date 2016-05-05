namespace Fx
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="EnsureInline"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class EnsureInlineUnitTests
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
            var value = new object();
            Assert.AreEqual(value, EnsureInline.NotNull(value, "classname"));
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
            var value = TimeSpan.FromMinutes(1);
            Assert.AreEqual(value, EnsureInline.NotNull(value, "structname"));
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
            Func<string> value = () => "test";
            Assert.AreEqual(value, EnsureInline.NotNull(value, "funcname"));
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
            Action value = () => { };
            Assert.AreEqual(value, EnsureInline.NotNull(value, "actionname"));
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
            var value = DateTimeKind.Local;
            Assert.AreEqual(value, EnsureInline.NotNull(value, "enumname"));
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
            var value = "teststring";
            Assert.AreEqual(value, EnsureInline.NotNullOrEmptyString(value, "stringname"));
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
            var value = new[] { "value" };
            Assert.AreEqual(value, EnsureInline.EnumerableNotEmpty<IEnumerable<string>, string>(value, "enumerablename"));
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
            var value = new[] { "value1", "value2" };
            Assert.AreEqual(value, EnsureInline.EnumerableNotEmpty<IEnumerable<string>, string>(value, "enumerablename"));
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
            var value1 = (sbyte)0x00;
            Assert.AreEqual(value1, EnsureInline.NotNegative(value1, "sbytevalue"));

            var value2 = (short)0;
            Assert.AreEqual(value2, EnsureInline.NotNegative(value2, "shortvalue"));

            var value3 = 0;
            Assert.AreEqual(value3, EnsureInline.NotNegative(value3, "intvalue"));

            var value4 = 0F;
            Assert.AreEqual(value4, EnsureInline.NotNegative(value4, "floatvalue"));

            var value5 = 0L;
            Assert.AreEqual(value5, EnsureInline.NotNegative(value5, "longvalue"));

            var value6 = 0D;
            Assert.AreEqual(value6, EnsureInline.NotNegative(value6, "doublevalue"));

            var value7 = 0M;
            Assert.AreEqual(value7, EnsureInline.NotNegative(value7, "decimalvalue"));
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
            var value1 = (sbyte)0x10;
            Assert.AreEqual(value1, EnsureInline.NotNegative(value1, "sbytevalue"));

            var value2 = (short)100;
            Assert.AreEqual(value2, EnsureInline.NotNegative(value2, "shortvalue"));

            var value3 = 100;
            Assert.AreEqual(value3, EnsureInline.NotNegative(value3, "intvalue"));

            var value4 = 100F;
            Assert.AreEqual(value4, EnsureInline.NotNegative(value4, "floatvalue"));

            var value5 = 100L;
            Assert.AreEqual(value5, EnsureInline.NotNegative(value5, "longvalue"));

            var value6 = 100D;
            Assert.AreEqual(value6, EnsureInline.NotNegative(value6, "doublevalue"));

            var value7 = 100M;
            Assert.AreEqual(value7, EnsureInline.NotNegative(value7, "decimalvalue"));
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
            var value1 = (byte)0x10;
            Assert.AreEqual(value1, EnsureInline.IsPositive(value1, "bytevalue"));

            var value2 = (sbyte)0x10;
            Assert.AreEqual(value2, EnsureInline.IsPositive(value2, "sbytevalue"));

            var value3 = (short)100;
            Assert.AreEqual(value3, EnsureInline.IsPositive(value3, "shortvalue"));

            var value4 = (ushort)100;
            Assert.AreEqual(value4, EnsureInline.IsPositive(value4, "ushortvalue"));

            var value5 = 100;
            Assert.AreEqual(value5, EnsureInline.IsPositive(value5, "intvalue"));

            var value6 = 100U;
            Assert.AreEqual(value6, EnsureInline.IsPositive(value6, "uintvalue"));

            var value7 = 100F;
            Assert.AreEqual(value7, EnsureInline.IsPositive(value7, "floatvalue"));

            var value8 = 100L;
            Assert.AreEqual(value8, EnsureInline.IsPositive(value8, "longvalue"));

            var value9 = 100UL;
            Assert.AreEqual(value9, EnsureInline.IsPositive(value9, "ulongvalue"));

            var value10 = 100D;
            Assert.AreEqual(value10, EnsureInline.IsPositive(value10, "doublevalue"));

            var value11 = 100M;
            Assert.AreEqual(value11, EnsureInline.IsPositive(value11, "decimalvalue"));
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
            var value = DateTimeKind.Local;
            Assert.AreEqual(value, EnsureInline.IsDefinedEnum(value, "enumvalue"));
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
            var value = FileAccess.Read;
            Assert.AreEqual(value, EnsureInline.IsDefinedEnum(value, "enumvalue"));
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
            var value = new MockDerivedClass();
            Assert.AreEqual(value, EnsureInline.IsInstance(typeof(MockDerivedClass), value, "instancename"));
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
            var value = new MockDerivedClass();
            Assert.AreEqual(value, EnsureInline.IsInstance(typeof(MockBaseClass), value, "instancename"));
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
            var value1 = "DEADBEEFDEAD";
            Assert.AreEqual(value1, EnsureInline.IsValidMacAddress(value1, "macaddressname"));

            var value2 = "DEADBEEFDEA1";
            Assert.AreEqual(value2, EnsureInline.IsValidMacAddress(value2, "macaddressname"));

            var value3 = "1EADBEEFDEC2";
            Assert.AreEqual(value3, EnsureInline.IsValidMacAddress(value3, "macaddressname"));

            var value4 = "0123456789AB";
            Assert.AreEqual(value4, EnsureInline.IsValidMacAddress(value4, "macaddressname"));
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
            var value1 = "deadbeefdead";
            Assert.AreEqual(value1, EnsureInline.IsValidMacAddress(value1, "macaddressname"));

            var value2 = "deadbeefdea1";
            Assert.AreEqual(value2, EnsureInline.IsValidMacAddress(value2, "macaddressname"));

            var value3 = "1eadbeefdec2";
            Assert.AreEqual(value3, EnsureInline.IsValidMacAddress(value3, "macaddressname"));

            var value4 = "0123456789ab";
            Assert.AreEqual(value4, EnsureInline.IsValidMacAddress(value4, "macaddressname"));
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
            var value1 = "DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEF";
            Assert.AreEqual(value1, EnsureInline.IsValidSha1(value1, "shaname"));

            var value2 = "DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEE1";
            Assert.AreEqual(value2, EnsureInline.IsValidSha1(value2, "shaname"));

            var value3 = "1EADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEF";
            Assert.AreEqual(value3, EnsureInline.IsValidSha1(value3, "shaname"));

            var value4 = "0123456789ABCDEF0123456789ABCDEF01234567";
            Assert.AreEqual(value4, EnsureInline.IsValidSha1(value4, "shaname"));
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
            var value1 = "deadbeefdeadbeefdeadbeefdeadbeefdeadbeef";
            Assert.AreEqual(value1, EnsureInline.IsValidSha1(value1, "shaname"));

            var value2 = "deadbeefdeadbeefdeadbeefdeadbeefdeadbee1";
            Assert.AreEqual(value2, EnsureInline.IsValidSha1(value2, "shaname"));

            var value3 = "1eadbeefdeadbeefdeadbeefdeadbeefdeadbeef";
            Assert.AreEqual(value3, EnsureInline.IsValidSha1(value3, "shaname"));

            var value4 = "0123456789abcdef0123456789abcdef01234567";
            Assert.AreEqual(value4, EnsureInline.IsValidSha1(value4, "shaname"));
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
            var value1 = "DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEF";
            Assert.AreEqual(value1, EnsureInline.IsValidSha2(value1, "shaname"));

            var value2 = "DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEE1";
            Assert.AreEqual(value2, EnsureInline.IsValidSha2(value2, "shaname"));

            var value3 = "1EADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEF";
            Assert.AreEqual(value3, EnsureInline.IsValidSha2(value3, "shaname"));

            var value4 = "0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF";
            Assert.AreEqual(value4, EnsureInline.IsValidSha2(value4, "shaname"));
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
            var value1 = "deadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeef";
            Assert.AreEqual(value1, EnsureInline.IsValidSha2(value1, "shaname"));

            var value2 = "deadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbee1";
            Assert.AreEqual(value2, EnsureInline.IsValidSha2(value2, "shaname"));

            var value3 = "1eadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeef";
            Assert.AreEqual(value3, EnsureInline.IsValidSha2(value3, "shaname"));

            var value4 = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef";
            Assert.AreEqual(value4, EnsureInline.IsValidSha2(value4, "shaname"));
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
            var value1 = "DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEF";
            Assert.AreEqual(value1, EnsureInline.IsValidSha1OrSha2(value1, "shaname"));

            var value2 = "DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEE1";
            Assert.AreEqual(value2, EnsureInline.IsValidSha1OrSha2(value2, "shaname"));

            var value3 = "1EADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEF";
            Assert.AreEqual(value3, EnsureInline.IsValidSha1OrSha2(value3, "shaname"));

            var value4 = "0123456789ABCDEF0123456789ABCDEF01234567";
            Assert.AreEqual(value4, EnsureInline.IsValidSha1OrSha2(value4, "shaname"));

            var value5 = "DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEF";
            Assert.AreEqual(value5, EnsureInline.IsValidSha1OrSha2(value5, "shaname"));

            var value6 = "DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEE1";
            Assert.AreEqual(value6, EnsureInline.IsValidSha1OrSha2(value6, "shaname"));

            var value7 = "1EADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEF";
            Assert.AreEqual(value7, EnsureInline.IsValidSha1OrSha2(value7, "shaname"));

            var value8 = "0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF";
            Assert.AreEqual(value8, EnsureInline.IsValidSha1OrSha2(value8, "shaname"));
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
            var value1 = "deadbeefdeadbeefdeadbeefdeadbeefdeadbeef";
            Assert.AreEqual(value1, EnsureInline.IsValidSha1OrSha2(value1, "shaname"));

            var value2 = "deadbeefdeadbeefdeadbeefdeadbeefdeadbee1";
            Assert.AreEqual(value2, EnsureInline.IsValidSha1OrSha2(value2, "shaname"));

            var value3 = "1eadbeefdeadbeefdeadbeefdeadbeefdeadbeef";
            Assert.AreEqual(value3, EnsureInline.IsValidSha1OrSha2(value3, "shaname"));

            var value4 = "0123456789abcdef0123456789abcdef01234567";
            Assert.AreEqual(value4, EnsureInline.IsValidSha1OrSha2(value4, "shaname"));

            var value5 = "deadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeef";
            Assert.AreEqual(value5, EnsureInline.IsValidSha1OrSha2(value5, "shaname"));

            var value6 = "deadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbee1";
            Assert.AreEqual(value6, EnsureInline.IsValidSha1OrSha2(value6, "shaname"));

            var value7 = "1eadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeef";
            Assert.AreEqual(value7, EnsureInline.IsValidSha1OrSha2(value7, "shaname"));

            var value8 = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef";
            Assert.AreEqual(value8, EnsureInline.IsValidSha1OrSha2(value8, "shaname"));
        }
    }
}
