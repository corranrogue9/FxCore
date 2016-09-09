namespace System
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="MockRandom"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class MockRandomUnitTests
    {
        /// <summary>
        /// Gets values from a MockRandom when the array is populated with minimum integer values
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Gets values from a MockRandom when the array is populated with minimum integer values")]
        [TestMethod]
        public void MinimumNext()
        {
            var random = new MockRandom(new byte[] { 0x00, 0x00, 0x00, 0x80 });

            Assert.AreEqual(int.MinValue, random.Next(int.MinValue, int.MaxValue));
            Assert.AreEqual(int.MaxValue, random.Next(int.MaxValue, int.MaxValue));
            Assert.AreEqual(int.MaxValue - 1, random.Next(int.MaxValue - 1, int.MaxValue));
            Assert.AreEqual(int.MinValue, random.Next(int.MinValue, int.MinValue));
            Assert.AreEqual(int.MinValue, random.Next(int.MinValue, int.MinValue + 1));
            Assert.AreEqual(int.MinValue, random.Next(int.MinValue, 0));
            Assert.AreEqual(0, random.Next(0, int.MaxValue));

            Assert.AreEqual(0, random.Next());

            Assert.AreEqual(0, random.Next(0));
            Assert.AreEqual(0, random.Next(int.MaxValue));
        }

        /// <summary>
        /// Gets values from a MockRandom when the array is populated with zero integer values
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Gets values from a MockRandom when the array is populated with zero integer values")]
        [TestMethod]
        public void ZeroNext()
        {
            var random = new MockRandom(new byte[] { 0x00, 0x00, 0x00, 0x00 });

            // 0's represent half way between max and min...
            Assert.AreEqual(-1, random.Next(int.MinValue, int.MaxValue));
            Assert.AreEqual(int.MaxValue, random.Next(int.MaxValue, int.MaxValue));
            Assert.AreEqual(int.MaxValue - 1, random.Next(int.MaxValue - 1, int.MaxValue));
            Assert.AreEqual(int.MinValue, random.Next(int.MinValue, int.MinValue));
            Assert.AreEqual(int.MinValue, random.Next(int.MinValue, int.MinValue + 1));
            Assert.AreEqual(int.MinValue / 2, random.Next(int.MinValue, 0));
            Assert.AreEqual(int.MaxValue / 2, random.Next(0, int.MaxValue));

            Assert.AreEqual(int.MaxValue / 2, random.Next());

            Assert.AreEqual(0, random.Next(0));
            Assert.AreEqual(int.MaxValue / 2, random.Next(int.MaxValue));
        }

        /// <summary>
        /// Gets values from a MockRandom when the array is populated with maximum integer values
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Gets values from a MockRandom when the array is populated with maximum integer values")]
        [TestMethod]
        public void MaximumNext()
        {
            var random = new MockRandom(new byte[] { 0xFF, 0xFF, 0xFF, 0x7F });

            Assert.AreEqual(int.MaxValue - 1, random.Next(int.MinValue, int.MaxValue));
            Assert.AreEqual(int.MaxValue, random.Next(int.MaxValue, int.MaxValue));
            Assert.AreEqual(int.MaxValue - 1, random.Next(int.MaxValue - 1, int.MaxValue));
            Assert.AreEqual(int.MinValue, random.Next(int.MinValue, int.MinValue));
            Assert.AreEqual(int.MinValue, random.Next(int.MinValue, int.MinValue + 1));
            Assert.AreEqual(-1, random.Next(int.MinValue, 0));
            Assert.AreEqual(int.MaxValue - 1, random.Next(0, int.MaxValue));

            Assert.AreEqual(int.MaxValue - 1, random.Next());

            Assert.AreEqual(0, random.Next(0));
            Assert.AreEqual(int.MaxValue - 1, random.Next(int.MaxValue));
        }

        /// <summary>
        /// Gets values from a MockRandom when the array is populated with minimum integer values
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Gets values from a MockRandom when the array is populated with minimum integer values")]
        [TestMethod]
        public void MinimumNextDouble()
        {
            var random = new MockRandom(new byte[] { 0x00, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00, 0x80 });

            Assert.AreEqual(0, random.NextDouble());
        }

        /// <summary>
        /// Gets values from a MockRandom when the array is populated with zero integer values
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Gets values from a MockRandom when the array is populated with zero integer values")]
        [TestMethod]
        public void ZeroNextDouble()
        {
            var random = new MockRandom(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            // 0's represent half way between max and min...
            Assert.AreEqual(0.5, random.NextDouble(), 0.00000001);
        }

        /// <summary>
        /// Gets values from a MockRandom when the array is populated with maximum integer values
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Gets values from a MockRandom when the array is populated with maximum integer values")]
        [TestMethod]
        public void MaximumNextDouble()
        {
            var random = new MockRandom(new byte[] { 0xFF, 0xFF, 0xFF, 0x7F, 0xFF, 0xFF, 0xFF, 0x7F, 0xFF, 0xFF, 0xFF, 0x7F, 0xFF, 0xFF, 0xFF, 0x7F, 0xFF, 0xFF, 0xFF, 0x7F, 0xFF, 0xFF, 0xFF, 0x7F, 0xFF, 0xFF, 0xFF, 0x7F, 0xFF, 0xFF, 0xFF, 0x7F, 0xFF, 0xFF, 0xFF, 0x7F, 0xFF, 0xFF, 0xFF, 0x7F });

            Assert.AreEqual(1, random.NextDouble(), 0.00000001);
        }

        /// <summary>
        /// Gets all of the next bytes from a MockRandom
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Gets all of the next bytes from a MockRandom")]
        [TestMethod]
        public void NextBytesAll()
        {
            var data = new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89 };
            var random = new MockRandom(data);

            var buffer = new byte[5];
            random.NextBytes(buffer);
            CollectionAssert.AreEqual(data, buffer);
        }

        /// <summary>
        /// Gets all of the next bytes from a MockRandom
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Gets single bytes from a MockRandom")]
        [TestMethod]
        public void NextBytesSingle()
        {
            var data = new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89 };
            var random = new MockRandom(data);

            var buffer = new byte[1];
            random.NextBytes(buffer);
            CollectionAssert.AreEqual(new byte[] { 0x01 }, buffer);
            random.NextBytes(buffer);
            CollectionAssert.AreEqual(new byte[] { 0x23 }, buffer);
            random.NextBytes(buffer);
            CollectionAssert.AreEqual(new byte[] { 0x45 }, buffer);
            random.NextBytes(buffer);
            CollectionAssert.AreEqual(new byte[] { 0x67 }, buffer);
            random.NextBytes(buffer);
            CollectionAssert.AreEqual(new byte[] { 0x89 }, buffer);
        }

        /// <summary>
        /// Gets bytes from a MockRandom when the bytes go past the end of the data array
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Gets bytes from a MockRandom when the bytes go past the end of the data array")]
        [TestMethod]
        public void NextBytesWrap()
        {
            var data = new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89 };
            var random = new MockRandom(data);

            var buffer = new byte[6];
            random.NextBytes(buffer);
            CollectionAssert.AreEqual(new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89, 0x01 }, buffer);
        }

        /// <summary>
        /// Gets bytes from a MockRandom when the bytes go past the end of the data array
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Gets bytes from a MockRandom when the bytes go past the end of the data array")]
        [TestMethod]
        public void NextBytesWrapMany()
        {
            var data = new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89 };
            var random = new MockRandom(data);

            var buffer = new byte[2];
            random.NextBytes(buffer);
            CollectionAssert.AreEqual(new byte[] { 0x01, 0x23 }, buffer);
            random.NextBytes(buffer);
            CollectionAssert.AreEqual(new byte[] { 0x45, 0x67 }, buffer);
            random.NextBytes(buffer);
            CollectionAssert.AreEqual(new byte[] { 0x89, 0x01 }, buffer);
            random.NextBytes(buffer);
            CollectionAssert.AreEqual(new byte[] { 0x23, 0x45 }, buffer);
            random.NextBytes(buffer);
            CollectionAssert.AreEqual(new byte[] { 0x67, 0x89 }, buffer);
            random.NextBytes(buffer);
            CollectionAssert.AreEqual(new byte[] { 0x01, 0x23 }, buffer);
        }

        /// <summary>
        /// Gets bytes from a MockRandom when the bytes go past the end of the data array
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Gets bytes from a MockRandom when the bytes go past the end of the data array")]
        [TestMethod]
        public void NextBytesWrapLarge()
        {
            var data = new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89 };
            var random = new MockRandom(data);

            var buffer = new byte[18];
            random.NextBytes(buffer);
            CollectionAssert.AreEqual(
                new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89, 0x01, 0x23, 0x45, 0x67, 0x89, 0x01, 0x23, 0x45, 0x67, 0x89, 0x01, 0x23, 0x45 }, 
                buffer);
            buffer = new byte[19];
            random.NextBytes(buffer);
            CollectionAssert.AreEqual(
                new byte[] { 0x67, 0x89, 0x01, 0x23, 0x45, 0x67, 0x89, 0x01, 0x23, 0x45, 0x67, 0x89, 0x01, 0x23, 0x45, 0x67, 0x89, 0x01, 0x23 },
                buffer);
        }
    }
}
