namespace System.IO
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MemoryStreamToTest = System.IO.ChunkedMemoryStream;

    /// <summary>
    /// Unit tests for the <see cref="ChunkedMemoryStream"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class ChunkedMemoryStreamUnitTests
    {
        /// <summary>
        /// Flushes the stream
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Flushes the stream")]
        [TestMethod]
        public void Flush()
        {
            using (var stream = new MemoryStreamToTest())
            {
                stream.Flush();
            }
        }

        /// <summary>
        /// Verifies the capabilities of the stream
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Verifies the capabilities of the stream")]
        [TestMethod]
        public void Capabilities()
        {
            using (var stream = new MemoryStreamToTest())
            {
                Assert.IsTrue(stream.CanRead);
                Assert.IsTrue(stream.CanSeek);
                Assert.IsTrue(stream.CanWrite);
            }

            using (var stream = new MemoryStreamToTest(new byte[0], false))
            {
                Assert.IsTrue(stream.CanRead);
                Assert.IsTrue(stream.CanSeek);
                Assert.IsFalse(stream.CanWrite);
            }
        }

        /// <summary>
        /// Verifies the capabilities of the disposed stream
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Verifies the capabilities of the disposed stream")]
        [TestMethod]
        public void DisposedCapabilities()
        {
            MemoryStreamToTest stream = null;
            try
            {
                stream = new MemoryStreamToTest();
            }
            finally
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
            }

            Assert.IsTrue(stream.CanRead);
            Assert.IsTrue(stream.CanSeek);
            Assert.IsTrue(stream.CanWrite);

            stream = null;
            try
            {
                stream = new MemoryStreamToTest(new byte[0], false);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
            }

            Assert.IsTrue(stream.CanRead);
            Assert.IsTrue(stream.CanSeek);
            Assert.IsFalse(stream.CanWrite);
        }

        /// <summary>
        /// Verifies the length of a stream with no data
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Verifies the length of a stream with no data")]
        [TestMethod]
        public void UninitializedLength()
        {
            using (var stream = new MemoryStreamToTest())
            {
                Assert.AreEqual(0, stream.Length);
            }
        }

        /// <summary>
        /// Seeks beyond the current length of the stream
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Seeks beyond the current length of the stream")]
        [TestMethod]
        public void SeekBeyondLength()
        {
            using (var stream = new MemoryStreamToTest())
            {
                stream.Seek(10, SeekOrigin.Begin);
                Assert.AreEqual(0, stream.Length);
                var bytes = stream.ToArray();
                Assert.AreEqual(0, bytes.Length);
            }
        }

        /// <summary>
        /// Seeks beyond the current length of the stream and then writes data
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Seeks beyond the current length of the stream and then writes data")]
        [TestMethod]
        public void SeekBeyondLengthAndWrite()
        {
            using (var stream = new MemoryStreamToTest())
            {
                stream.Seek(10, SeekOrigin.Begin);
                stream.Write(new byte[] { 1, 2, 3, 4 }, 0, 4);
                var bytes = stream.ToArray();
                Assert.AreEqual(14, bytes.Length);
            }
        }

        /// <summary>
        /// Sets the current position beyond the current length of the stream
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Sets the current position beyond the current length of the stream")]
        [TestMethod]
        public void SetPositionBeyondLength()
        {
            using (var stream = new MemoryStreamToTest())
            {
                stream.Position = 10;
                Assert.AreEqual(0, stream.Length);
                var bytes = stream.ToArray();
                Assert.AreEqual(0, bytes.Length);
            }
        }

        /// <summary>
        /// Sets the current length of the stream
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Sets the current length of the stream")]
        [TestMethod]
        public void SetLength()
        {
            using (var stream = new MemoryStreamToTest())
            {
                stream.SetLength(100);
                Assert.AreEqual(100, stream.Length);
                var bytes = stream.ToArray();
                Assert.AreEqual(100, bytes.Length);
            }
        }

        /// <summary>
        /// Sets the current length of the stream to a 4MB boundary
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Sets the current length of the stream to a 4MB boundary")]
        [TestMethod]
        public void SetLengthFourMegBoundary()
        {
            using (var stream = new MemoryStreamToTest())
            {
                stream.SetLength(1024 * 1024 * 8);
                Assert.AreEqual(1024 * 1024 * 8, stream.Length);
                var bytes = stream.ToArray();
                Assert.AreEqual(1024 * 1024 * 8, bytes.Length);
            }
        }

        /// <summary>
        /// Sets the current length of the stream to a non-4MB boundary
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Sets the current length of the stream to a non-4MB boundary")]
        [TestMethod]
        public void SetLengthNonFourMegBoundary()
        {
            using (var stream = new MemoryStreamToTest())
            {
                stream.SetLength(1024 * 1024 * 50);
                Assert.AreEqual(1024 * 1024 * 50, stream.Length);
                var bytes = stream.ToArray();
                Assert.AreEqual(1024 * 1024 * 50, bytes.Length);
            }
        }

        /// <summary>
        /// Sets the current length of the stream and then verifies the position
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Sets the current length of the stream and then verifies the position")]
        [TestMethod]
        public void SetLengthPosition()
        {
            using (var stream = new MemoryStreamToTest())
            {
                stream.SetLength(1024 * 1024 * 50);
                Assert.AreEqual(0, stream.Position);
            }
        }

        /// <summary>
        /// Seeks to a position in the stream and then verifies the position
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Seeks to a position in the stream and then verifies the position")]
        [TestMethod]
        public void SeekPosition()
        {
            using (var stream = new MemoryStreamToTest())
            {
                stream.Seek(0, SeekOrigin.Begin);
                Assert.AreEqual(0, stream.Position);

                stream.Seek(1000000, SeekOrigin.Begin);
                Assert.AreEqual(1000000, stream.Position);

                stream.Seek(1000000, SeekOrigin.Current);
                Assert.AreEqual(1000000 + 1000000, stream.Position);

                stream.Seek(100, SeekOrigin.End);
                Assert.AreEqual(100, stream.Position);

                stream.SetLength(10 * 1024 * 1024);
                stream.Seek(100, SeekOrigin.End);
                Assert.AreEqual((10 * 1024 * 1024) + 100, stream.Position);
            }
        }

        /// <summary>
        /// Reads 100MB from an uninitialized stream
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Reads 100MB from an uninitialized stream")]
        [TestMethod]
        public void ReadUninitialized()
        {
            using (var stream = new MemoryStreamToTest())
            {
                var buffer = new byte[1024 * 1024 * 100];
                Assert.AreEqual(0, stream.Read(buffer, 0, 1024 * 1024 * 100));
            }
        }

        /// <summary>
        /// Reads 100MB from a 5MB stream that has only 0's
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Reads 100MB from a 5MB stream that has only 0's")]
        [TestMethod]
        public void ReadZeroesNonFourMegBoundary()
        {
            using (var stream = new MemoryStreamToTest())
            {
                stream.SetLength(5 * 1024 * 1024);

                var buffer = new byte[1024 * 1024 * 100];
                for (int i = 0; i < buffer.Length; ++i)
                {
                    buffer[i] = 1;
                }

                Assert.AreEqual(5 * 1024 * 1024, stream.Read(buffer, 0, 1024 * 1024 * 100));
                for (int i = 0; i < 5 * 1024 * 1024; ++i)
                {
                    Assert.AreEqual(0, buffer[i]);
                }

                for (int i = 5 * 1024 * 1024; i < buffer.Length; ++i)
                {
                    Assert.AreEqual(1, buffer[i]);
                }
            }
        }

        /// <summary>
        /// Reads 100MB from a 8MB stream that has only 0's
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Reads 100MB from a 8MB stream that has only 0's")]
        [TestMethod]
        public void ReadZeroesFourMegBoundary()
        {
            using (var stream = new MemoryStreamToTest())
            {
                stream.SetLength(8 * 1024 * 1024);

                var buffer = new byte[1024 * 1024 * 100];
                for (int i = 0; i < buffer.Length; ++i)
                {
                    buffer[i] = 1;
                }

                Assert.AreEqual(8 * 1024 * 1024, stream.Read(buffer, 0, 1024 * 1024 * 100));
                for (int i = 0; i < 8 * 1024 * 1024; ++i)
                {
                    Assert.AreEqual(0, buffer[i]);
                }

                for (int i = 8 * 1024 * 1024; i < buffer.Length; ++i)
                {
                    Assert.AreEqual(1, buffer[i]);
                }
            }
        }

        /// <summary>
        /// Reads 50MB from a 5MB stream that has only 0's into the middle of the 100MB array
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Reads 50MB from a 5MB stream that has only 0's into the middle of the 100MB array")]
        [TestMethod]
        public void ReadZeroesIntoMiddleOfArray()
        {
            using (var stream = new MemoryStreamToTest())
            {
                stream.SetLength(5 * 1024 * 1024);

                var buffer = new byte[1024 * 1024 * 100];
                for (int i = 0; i < buffer.Length; ++i)
                {
                    buffer[i] = 1;
                }

                Assert.AreEqual(5 * 1024 * 1024, stream.Read(buffer, 1024 * 1024 * 50, 1024 * 1024 * 50));
                for (int i = 0; i < 50 * 1024 * 1024; ++i)
                {
                    Assert.AreEqual(1, buffer[i]);
                }

                for (int i = 50 * 1024 * 1024; i < (50 * 1024 * 1024) + (5 * 1024 * 1024); ++i)
                {
                    Assert.AreEqual(0, buffer[i]);
                }

                for (int i = (50 * 1024 * 1024) + (5 * 1024 * 1024); i < buffer.Length; ++i)
                {
                    Assert.AreEqual(1, buffer[i]);
                }
            }
        }

        /// <summary>
        /// Reads 1MB from a 5MB stream that has only 0's into the middle of the 100MB array
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Reads 1MB from a 5MB stream that has only 0's into the middle of the 100MB array")]
        [TestMethod]
        public void ReadZeroesIntoMiddleOfArraySmall()
        {
            using (var stream = new MemoryStreamToTest())
            {
                stream.SetLength(5 * 1024 * 1024);

                var buffer = new byte[1024 * 1024 * 100];
                for (int i = 0; i < buffer.Length; ++i)
                {
                    buffer[i] = 1;
                }

                Assert.AreEqual(1 * 1024 * 1024, stream.Read(buffer, 1024 * 1024 * 50, 1024 * 1024 * 1));
                for (int i = 0; i < 50 * 1024 * 1024; ++i)
                {
                    Assert.AreEqual(1, buffer[i]);
                }

                for (int i = 50 * 1024 * 1024; i < (50 * 1024 * 1024) + (1 * 1024 * 1024); ++i)
                {
                    Assert.AreEqual(0, buffer[i]);
                }

                for (int i = (50 * 1024 * 1024) + (1 * 1024 * 1024); i < buffer.Length; ++i)
                {
                    Assert.AreEqual(1, buffer[i]);
                }
            }
        }

        /// <summary>
        /// Seeks beyond the end of the stream and then attempts to read
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Seeks beyond the end of the stream and then attempts to read")]
        [TestMethod]
        public void ReadAfterSeek()
        {
            using (var stream = new MemoryStreamToTest())
            {
                stream.Seek(100, SeekOrigin.Begin);
                Assert.AreEqual(0, stream.Length);
                Assert.AreEqual(100, stream.Position);
                var buffer = new byte[10 * 1024 * 1024];
                Assert.AreEqual(0, stream.Read(buffer, 0, buffer.Length));
            }
        }

        /// <summary>
        /// Writes to a non-4MB boundary, seeks to the middle, and reads from there
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Writes to a non-4MB boundary, seeks to the middle, and reads from there")]
        [TestMethod]
        public void ReadAfterSeekAndPartialWrite()
        {
            using (var stream = new MemoryStreamToTest())
            {
                var buffer = new byte[4179928];
                stream.Write(buffer, 0, buffer.Length);
                stream.Seek(4132856, SeekOrigin.Begin);
                buffer = new byte[65536];
                stream.Read(buffer, 0, buffer.Length);
            }
        }

        /// <summary>
        /// Seeks beyond the end of the stream and then attempts to read
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Seeks beyond the end of the stream and then attempts to read")]
        [TestMethod]
        public void ReadAfterLengthChange()
        {
            using (var stream = new MemoryStreamToTest())
            {
                stream.SetLength(100);
                var buffer = new byte[10 * 1024 * 1024];
                Assert.AreEqual(100, stream.Read(buffer, 0, buffer.Length));
            }
        }

        /// <summary>
        /// Attempts to write
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Attempts to write")]
        [TestMethod]
        public void Write()
        {
            using (var stream = new MemoryStreamToTest())
            {
                Assert.AreEqual(0, stream.Length);
                Assert.AreEqual(0, stream.Position);
                stream.Write(new byte[1000], 0, 1000);
                Assert.AreEqual(1000, stream.Length);
                Assert.AreEqual(1000, stream.Position);
            }
        }

        /// <summary>
        /// Attempts to write to the edge of a 4MB boundary
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Attempts to write to the edge of a 4MB boundary")]
        [TestMethod]
        public void WriteFourMegBoundary()
        {
            using (var stream = new MemoryStreamToTest())
            {
                Assert.AreEqual(0, stream.Length);
                Assert.AreEqual(0, stream.Position);
                stream.Write(new byte[4 * 1024 * 1024], 0, 4 * 1024 * 1024);
                Assert.AreEqual(4 * 1024 * 1024, stream.Length);
                Assert.AreEqual(4 * 1024 * 1024, stream.Position);
            }
        }

        /// <summary>
        /// Attempts to write to the edge of a 4MB boundary
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Attempts to write to the edge of a 4MB boundary")]
        [TestMethod]
        public void WriteLargeFourMegBoundary()
        {
            using (var stream = new MemoryStreamToTest())
            {
                Assert.AreEqual(0, stream.Length);
                Assert.AreEqual(0, stream.Position);
                stream.Write(new byte[2 * 1024 * 1024], 0, 2 * 1024 * 1024);
                Assert.AreEqual(2 * 1024 * 1024, stream.Length);
                Assert.AreEqual(2 * 1024 * 1024, stream.Position);
            }
        }

        /// <summary>
        /// Attempts to write more than 4MB to the edge of a 4MB boundary
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Attempts to write more than 4MB to the edge of a 4MB boundary")]
        [TestMethod]
        public void WriteMoreThanFourMegToFourMegBoundary()
        {
            using (var stream = new MemoryStreamToTest())
            {
                Assert.AreEqual(0, stream.Length);
                Assert.AreEqual(0, stream.Position);
                stream.Write(new byte[10 * 1024 * 1024], 0, 10 * 1024 * 1024);
                Assert.AreEqual(10 * 1024 * 1024, stream.Length);
                Assert.AreEqual(10 * 1024 * 1024, stream.Position);
            }
        }

        /// <summary>
        /// Attempts to write more than 4MB to beyond a 4MB boundary
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Attempts to write more than 4MB to beyond a 4MB boundary")]
        [TestMethod]
        public void WriteMoreThanFourMegToBeyondFourMegBoundary()
        {
            using (var stream = new MemoryStreamToTest())
            {
                Assert.AreEqual(0, stream.Length);
                Assert.AreEqual(0, stream.Position);
                stream.Write(new byte[12 * 1024 * 1024], 0, 12 * 1024 * 1024);
                Assert.AreEqual(12 * 1024 * 1024, stream.Length);
                Assert.AreEqual(12 * 1024 * 1024, stream.Position);
            }
        }

        /// <summary>
        /// Seeks beyond the end of the stream and then attempts to write
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Seeks beyond the end of the stream and then attempts to write")]
        [TestMethod]
        public void WriteAfterSeek()
        {
            using (var stream = new MemoryStreamToTest())
            {
                stream.Seek(100, SeekOrigin.Begin);
                Assert.AreEqual(0, stream.Length);
                Assert.AreEqual(100, stream.Position);
                stream.Write(new byte[1000], 0, 1000);
                Assert.AreEqual(1100, stream.Length);
                Assert.AreEqual(1100, stream.Position);
            }
        }

        /// <summary>
        /// Seeks beyond the end of the stream and then attempts to write to the edge of a 4MB boundary
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Seeks beyond the end of the stream and then attempts to write to the edge of a 4MB boundary")]
        [TestMethod]
        public void WriteAfterSeekFourMegBoundary()
        {
            using (var stream = new MemoryStreamToTest())
            {
                stream.Seek(100, SeekOrigin.Begin);
                Assert.AreEqual(0, stream.Length);
                Assert.AreEqual(100, stream.Position);
                stream.Write(new byte[(4 * 1024 * 1024) - 100], 0, (4 * 1024 * 1024) - 100);
                Assert.AreEqual(4 * 1024 * 1024, stream.Length);
                Assert.AreEqual(4 * 1024 * 1024, stream.Position);
            }
        }

        /// <summary>
        /// Seeks beyond the end of the stream by many chunks and then attempts to write to the edge of a 4MB boundary
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Seeks beyond the end of the stream by many chunks and then attempts to write to the edge of a 4MB boundary")]
        [TestMethod]
        public void WriteAfterSeekLargeFourMegBoundary()
        {
            using (var stream = new MemoryStreamToTest())
            {
                stream.Seek(50 * 1024 * 1024, SeekOrigin.Begin);
                Assert.AreEqual(0, stream.Length);
                Assert.AreEqual(50 * 1024 * 1024, stream.Position);
                stream.Write(new byte[2 * 1024 * 1024], 0, 2 * 1024 * 1024);
                Assert.AreEqual(52 * 1024 * 1024, stream.Length);
                Assert.AreEqual(52 * 1024 * 1024, stream.Position);
            }
        }

        /// <summary>
        /// Seeks beyond the end of the stream by many chunks and then attempts to write more than 4MB to the edge of a 4MB boundary
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Seeks beyond the end of the stream by many chunks and then attempts to write more than 4MB to the edge of a 4MB boundary")]
        [TestMethod]
        public void WriteAfterSeekMoreThanFourMegToFourMegBoundary()
        {
            using (var stream = new MemoryStreamToTest())
            {
                stream.Seek(50 * 1024 * 1024, SeekOrigin.Begin);
                Assert.AreEqual(0, stream.Length);
                Assert.AreEqual(50 * 1024 * 1024, stream.Position);
                stream.Write(new byte[10 * 1024 * 1024], 0, 10 * 1024 * 1024);
                Assert.AreEqual(60 * 1024 * 1024, stream.Length);
                Assert.AreEqual(60 * 1024 * 1024, stream.Position);
            }
        }

        /// <summary>
        /// Seeks beyond the end of the stream by many chunks and then attempts to write more than 4MB to beyond a 4MB boundary
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Seeks beyond the end of the stream by many chunks and then attempts to write more than 4MB to beyond a 4MB boundary")]
        [TestMethod]
        public void WriteAfterSeekMoreThanFourMegToBeyondFourMegBoundary()
        {
            using (var stream = new MemoryStreamToTest())
            {
                stream.Seek(50 * 1024 * 1024, SeekOrigin.Begin);
                Assert.AreEqual(0, stream.Length);
                Assert.AreEqual(50 * 1024 * 1024, stream.Position);
                stream.Write(new byte[12 * 1024 * 1024], 0, 12 * 1024 * 1024);
                Assert.AreEqual(62 * 1024 * 1024, stream.Length);
                Assert.AreEqual(62 * 1024 * 1024, stream.Position);
            }
        }

        /// <summary>
        /// Generates an array for a stream that is on a 4MB boundary
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Generates an array for a stream that is on a 4MB boundary")]
        [TestMethod]
        public void GenerateArrayOnFourMegBoundary()
        {
            using (var stream = new MemoryStreamToTest())
            {
                stream.SetLength(12 * 1024 * 1024);
                var data = stream.ToArray();
                Assert.AreEqual(12 * 1024 * 1024, data.Length);
            }
        }

        /// <summary>
        /// Initializes a new stream with a byte array
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Initializes a new stream with a byte array")]
        [TestMethod]
        public void InitializeWithData()
        {
            var data = new byte[10 * 1024 * 1024];
            using (var stream = new MemoryStreamToTest(data, true))
            {
                Assert.IsTrue(stream.CanWrite);

                using (var stream2 = new MemoryStreamToTest())
                {
                    Assert.IsTrue(stream.CanWrite);
                    stream2.Write(data, 0, data.Length);

                    CollectionAssert.AreEqual(data, stream.ToArray());
                    CollectionAssert.AreEqual(data, stream2.ToArray());
                    CollectionAssert.AreEqual(stream.ToArray(), stream2.ToArray());
                }
            }
        }

        /// <summary>
        /// Initializes a new stream with a byte array and then writes more data
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Initializes a new stream with a byte array and then writes more data")]
        [TestMethod]
        public void InitializeWithDataAndWrite()
        {
            var data = new byte[10 * 1024 * 1024];
            using (var stream = new MemoryStreamToTest(data, true))
            {
                Assert.IsTrue(stream.CanWrite);
                var data2 = new byte[100 * 1024];
                stream.Seek(0, SeekOrigin.End);
                stream.Write(data2, 0, data2.Length);
                var completeData = new List<byte>(data);
                completeData.AddRange(data2);
                CollectionAssert.AreEqual(completeData, stream.ToArray());
            }
        }

        /// <summary>
        /// Initializes a new stream with a byte array and ensures that it is read-only
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Initializes a new stream with a byte array and ensures that it is read-only")]
        [TestMethod]
        public void InitializeWithDataReadOnly()
        {
            var data = new byte[10 * 1024 * 1024];
            using (var stream = new MemoryStreamToTest(data, false))
            {
                Assert.IsFalse(stream.CanWrite);

                ExceptionAssert.Throws<NotSupportedException>(() => stream.Write(data, 0, data.Length));

                stream.Seek(0, SeekOrigin.End);
                ExceptionAssert.Throws<NotSupportedException>(() => stream.Write(data, 0, data.Length));

                ExceptionAssert.Throws<NotSupportedException>(() => stream.SetLength(stream.Length + 10));
            }
        }
    }
}
