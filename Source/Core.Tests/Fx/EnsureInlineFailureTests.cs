namespace Fx
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="EnsureInline"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class EnsureInlineFailureTests
    {
        /// <summary>
        /// Ensures that if a class argument is null, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a class argument is null, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void NotNullClass()
        {
            string value = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => EnsureInline.NotNull(value, "classname"));
        }

        /// <summary>
        /// Ensures that if a function argument is null, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a function argument is null, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void NotNullFunc()
        {
            Func<string> func = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => EnsureInline.NotNull(func, "funcname"));
        }

        /// <summary>
        /// Ensures that if an action argument is null, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if an action argument is null, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void NotNullAction()
        {
            Action action = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => EnsureInline.NotNull(action, "actionname"));
        }

        /// <summary>
        /// Ensures that if a string has a null value, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a string has a null value, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void NotNullOrEmptyStringNull()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => EnsureInline.NotNullOrEmptyString(null, "stringname"));
        }

        /// <summary>
        /// Ensures that if a string has an empty value, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a string has an empty value, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void NotNullOrEmptyStringEmpty()
        {
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.NotNullOrEmptyString(string.Empty, "stringname"));
        }

        /// <summary>
        /// Ensures that if an argument is a null enumerable, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if an argument is a null enumerable, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void EnumerableNotEmptyNull()
        {
            string[] valueArray = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => EnsureInline.EnumerableNotEmpty<IEnumerable<string>, string>(valueArray, "arrayname"));

            IEnumerable<string> valueEnumerable = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => EnsureInline.EnumerableNotEmpty<IEnumerable<string>, string>(valueEnumerable, "enumerablename"));

            IList<string> valueList = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => EnsureInline.EnumerableNotEmpty<IEnumerable<string>, string>(valueList, "listname"));

            ICollection<string> valueCollection = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => EnsureInline.EnumerableNotEmpty<IEnumerable<string>, string>(valueCollection, "collectionname"));
        }

        /// <summary>
        /// Ensures that if an argument is an empty enumerable, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if an argument is an empty enumerable, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void EnumerableNotEmptyEmpty()
        {
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.EnumerableNotEmpty<IEnumerable<string>, string>(new string[0], "arrayname"));
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.EnumerableNotEmpty<IEnumerable<string>, string>(Enumerable.Empty<string>(), "enumerablename"));
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.EnumerableNotEmpty<IEnumerable<string>, string>(new List<string>(), "listname"));
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.EnumerableNotEmpty<IEnumerable<string>, string>(new Collection<string>(), "collectionname"));
        }

        /// <summary>
        /// Ensures that if an argument is negative, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if an argument is negative, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void NotNegativeNegative()
        {
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => EnsureInline.NotNegative((sbyte)-0x10, "sbytevalue"));
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => EnsureInline.NotNegative((short)-100, "shortvalue"));
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => EnsureInline.NotNegative(-100, "intvalue"));
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => EnsureInline.NotNegative(-100F, "floatvalue"));
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => EnsureInline.NotNegative(-100L, "longvalue"));
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => EnsureInline.NotNegative(-100D, "doublevalue"));
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => EnsureInline.NotNegative(-100M, "decimalvalue"));
        }

        /// <summary>
        /// Ensures that if an argument is zero, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if an argument is zero, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsPositiveZero()
        {
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => EnsureInline.IsPositive((byte)0x00, "bytevalue"));
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => EnsureInline.IsPositive((sbyte)0x00, "sbytevalue"));
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => EnsureInline.IsPositive((short)0, "shortvalue"));
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => EnsureInline.IsPositive((ushort)0, "ushortvalue"));
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => EnsureInline.IsPositive(0, "intvalue"));
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => EnsureInline.IsPositive(0U, "uintvalue"));
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => EnsureInline.IsPositive(0F, "floatvalue"));
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => EnsureInline.IsPositive(0L, "longvalue"));
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => EnsureInline.IsPositive(0UL, "ulongvalue"));
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => EnsureInline.IsPositive(0D, "doublevalue"));
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => EnsureInline.IsPositive(0M, "decimalvalue"));
        }

        /// <summary>
        /// Ensures that if an argument is not a defined enumeration value, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if an argument is not a defined enumeration value, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsDefinedEnumBadValue()
        {
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => EnsureInline.IsDefinedEnum((DateTimeKind)(-1), "enumname"));
        }

        /// <summary>
        /// Ensures that if an argument is null, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if an argument is null, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsDefinedEnumNull()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => EnsureInline.IsDefinedEnum(null, "enumname"));
        }

        /// <summary>
        /// Ensures that if an argument is not derived from the provided type, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if an argument is not derived from the provided type, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsInstance()
        {
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.IsInstance(typeof(MockDerivedClass), new MockBaseClass(), "instancename"));
        }

        /// <summary>
        /// Ensures that if the provided type is null, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if the provided type is null, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsInstanceNullType()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => EnsureInline.IsInstance(null, new MockBaseClass(), "instancename"));
        }

        /// <summary>
        /// Ensures that if an argument is null, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if an argument is null, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsInstanceNullInstance()
        {
            MockBaseClass value = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => EnsureInline.IsInstance(typeof(MockDerivedClass), value, "instancename"));
        }

        /// <summary>
        /// Ensures that if a string has a null value, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a string is null, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidMacAddressNull()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => EnsureInline.IsValidMacAddress(null, "macaddressname"));
        }

        /// <summary>
        /// Ensures that if a string is empty, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a string is empty, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidMacAddressEmpty()
        {
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.IsValidMacAddress(string.Empty, "macaddressname"));
        }

        /// <summary>
        /// Ensures that if a string is too long, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a string is too long, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidMacAddressTooLong()
        {
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.IsValidMacAddress("DEADBEEFDEADB", "macaddressname"));
        }

        /// <summary>
        /// Ensures that if a string is too short, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a string is too short, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidMacAddressTooShort()
        {
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.IsValidMacAddress("DEADBEEFDEA", "macaddressname"));
        }

        /// <summary>
        /// Ensures that if a string contains an invalid character, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a string contains an invalid character, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidMacAddressInvalidCharacter()
        {
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.IsValidMacAddress("DEADBEEGDEAD", "macaddressname"));
        }

        /// <summary>
        /// Ensures that if a string is null, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a string is null, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidSha1Null()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => EnsureInline.IsValidSha1(null, "shaname"));
        }

        /// <summary>
        /// Ensures that if a string is empty, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a string is empty, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidSha1Empty()
        {
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.IsValidSha1(string.Empty, "shaname"));
        }

        /// <summary>
        /// Ensures that if a string is too long, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a string is too long, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidSha1TooLong()
        {
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.IsValidSha1("DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFA", "shaname"));
        }

        /// <summary>
        /// Ensures that if a string is too short, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a string is too short, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidSha1TooShort()
        {
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.IsValidSha1("DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEE", "shaname"));
        }

        /// <summary>
        /// Ensures that if a string contains an invalid character, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a string contains an invalid character, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidSha1InvalidCharacter()
        {
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.IsValidSha1("DEADBEEFDEADBEEFDEADBEEFDGADBEEFDEADBEE", "shaname"));
        }

        /// <summary>
        /// Ensures that if a string is null, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a string is null, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidSha2Null()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => EnsureInline.IsValidSha2(null, "shaname"));
        }

        /// <summary>
        /// Ensures that if a string is empty, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a string is empty, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidSha2Empty()
        {
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.IsValidSha2(string.Empty, "shaname"));
        }

        /// <summary>
        /// Ensures that if a string is too long, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a string is too long, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidSha2TooLong()
        {
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.IsValidSha2("DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFA", "shaname"));
        }

        /// <summary>
        /// Ensures that if a string is too short, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a string is too short, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidSha2TooShort()
        {
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.IsValidSha2("DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEE", "shaname"));
        }

        /// <summary>
        /// Ensures that if a string contains an invalid character, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a string contains an invalid character, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidSha2InvalidCharacter()
        {
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.IsValidSha2("DEADBEEFDEADBEEFDEADBEEFDGADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEF", "shaname"));
        }

        /// <summary>
        /// Ensures that if a string is null, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a string is null, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidSha1OrSha2Null()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => EnsureInline.IsValidSha1OrSha2(null, "shaname"));
        }

        /// <summary>
        /// Ensures that if a string is empty, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a string is empty, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidSha1OrSha2Empty()
        {
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.IsValidSha1OrSha2(string.Empty, "shaname"));
        }

        /// <summary>
        /// Ensures that if a string is too long, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a string is too long, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidSha1OrSha2TooLong()
        {
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.IsValidSha1OrSha2("DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFA", "shaname"));
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.IsValidSha1OrSha2("DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFA", "shaname"));
        }

        /// <summary>
        /// Ensures that if a string is too short, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a string is too short, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidSha1OrSha2TooShort()
        {
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.IsValidSha1OrSha2("DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEE", "shaname"));
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.IsValidSha1OrSha2("DEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEE", "shaname"));
        }

        /// <summary>
        /// Ensures that if a string contains an invalid character, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a string contains an invalid character, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void IsValidSha1OrSha2InvalidCharacter()
        {
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.IsValidSha1OrSha2("DEADBEEFDEADBEEFDEADBEEFDGADBEEFDEADBEE", "shaname"));
            ExceptionAssert.Throws<ArgumentException>(() => EnsureInline.IsValidSha1OrSha2("DEADBEEFDEADBEEFDEADBEEFDGADBEEFDEADBEEFDEADBEEFDEADBEEFDEADBEEF", "shaname"));
        }
    }
}
