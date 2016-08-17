namespace System.IO
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="ChunkedMemoryStream"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class ChunkedMemoryStreamFailureTests
    {
        /// <summary>
        /// Gets the length of a disposed stream
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Gets the length of a disposed stream")]
        [TestMethod]
        public void DisposedLength()
        {
            ChunkedMemoryStream stream = null;
            try
            {
                stream = new ChunkedMemoryStream();
            }
            finally
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
            }

            ExceptionAssert.Throws<ObjectDisposedException>(() => { var length = stream.Length; });
        }

        /// <summary>
        /// Gets and sets the position of a disposed stream
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Gets and sets the position of a disposed stream")]
        [TestMethod]
        public void DisposedPosition()
        {
            ChunkedMemoryStream stream = null;
            try
            {
                stream = new ChunkedMemoryStream();
            }
            finally
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
            }

            ExceptionAssert.Throws<ObjectDisposedException>(() => { var position = stream.Position; });
            ExceptionAssert.Throws<ObjectDisposedException>(() => { stream.Position = 0; });
        }

        /// <summary>
        /// Reads from a stream when a null buffer is provided
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Reads from a stream when a null buffer is provided")]
        [TestMethod]
        public void ReadNullBuffer()
        {
            using (var stream = new ChunkedMemoryStream())
            {
                ExceptionAssert.Throws<ArgumentNullException>(() => stream.Read(null, 0, 5));
            }
        }

        /// <summary>
        /// Reads from a stream when a negative offset is provided
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Reads from a stream when a negative offset is provided")]
        [TestMethod]
        public void ReadNegativeOffset()
        {
            using (var stream = new ChunkedMemoryStream())
            {
                ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => stream.Read(new byte[5], -1, 5));
            }
        }

        /// <summary>
        /// Reads from a stream when a negative count is provided
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Reads from a stream when a negative count is provided")]
        [TestMethod]
        public void ReadNegativeCount()
        {
            using (var stream = new ChunkedMemoryStream())
            {
                ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => stream.Read(new byte[5], 0, -5));
            }
        }

        /// <summary>
        /// Reads from a stream when the buffer is not large enough
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Reads from a stream when the buffer is not large enough")]
        [TestMethod]
        public void ReadBadBufferLength()
        {
            using (var stream = new ChunkedMemoryStream())
            {
                ExceptionAssert.Throws<ArgumentException>(() => stream.Read(new byte[5], 1, 6));
            }
        }

        /// <summary>
        /// Reads from a disposed stream
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Reads from a disposed stream")]
        [TestMethod]
        public void ReadDisposed()
        {
            ChunkedMemoryStream stream = null;
            try
            {
                stream = new ChunkedMemoryStream();
            }
            finally
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
            }

            ExceptionAssert.Throws<ObjectDisposedException>(() => stream.Read(new byte[5], 0, 5));
        }

        /// <summary>
        /// Seeks within a stream when a bad origin is provided
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Seeks within a stream when a bad origin is provided")]
        [TestMethod]
        public void SeekBadOrigin()
        {
            using (var stream = new ChunkedMemoryStream())
            {
                ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => stream.Seek(5, (SeekOrigin)6));
            }
        }

        /// <summary>
        /// Seeks within a stream when a negative position would be found
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Seeks within a stream when a negative position would be found")]
        [TestMethod]
        public void SeekNegativePosition()
        {
            using (var stream = new ChunkedMemoryStream())
            {
                ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => stream.Seek(-1, SeekOrigin.Begin));
                ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => stream.Seek(-1, SeekOrigin.Current));
                ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => stream.Seek(-1, SeekOrigin.End));
            }
        }

        /// <summary>
        /// Seeks within a disposed stream
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Seeks within a disposed stream")]
        [TestMethod]
        public void SeekDisposed()
        {
            ChunkedMemoryStream stream = null;
            try
            {
                stream = new ChunkedMemoryStream();
            }
            finally
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
            }

            ExceptionAssert.Throws<ObjectDisposedException>(() => stream.Seek(5, SeekOrigin.Begin));
        }

        /// <summary>
        /// Sets the length of a stream to be a negative value
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Sets the length of a stream to be a negative value")]
        [TestMethod]
        public void SetLengthNegative()
        {
            using (var stream = new ChunkedMemoryStream())
            {
                ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => stream.SetLength(-1));
            }
        }

        /// <summary>
        /// Sets the length of a stream that is read-only
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Sets the length of a stream that is read-only")]
        [TestMethod]
        public void SetLengthReadOnly()
        {
            using (var stream = new ChunkedMemoryStream(new byte[0], false))
            {
                ExceptionAssert.Throws<NotSupportedException>(() => stream.SetLength(100));
            }
        }

        /// <summary>
        /// Sets the length of a disposed stream
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Sets the length of a disposed stream")]
        [TestMethod]
        public void SetLengthDisposed()
        {
            ChunkedMemoryStream stream = null;
            try
            {
                stream = new ChunkedMemoryStream();
            }
            finally
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
            }

            ExceptionAssert.Throws<ObjectDisposedException>(() => stream.SetLength(5));
        }

        /// <summary>
        /// Writes a null buffer to a stream
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes a null buffer to a stream")]
        [TestMethod]
        public void WriteNullBuffer()
        {
            using (var stream = new ChunkedMemoryStream())
            {
                ExceptionAssert.Throws<ArgumentNullException>(() => stream.Write(null, 0, 5));
            }
        }

        /// <summary>
        /// Writes to a stream when a negative offset is provided
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to a stream when a negative offset is provided")]
        [TestMethod]
        public void WriteNegativeOffset()
        {
            using (var stream = new ChunkedMemoryStream())
            {
                ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => stream.Write(new byte[5], -1, 5));
            }
        }

        /// <summary>
        /// Writes to a stream when a negative count is provided
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to a stream when a negative count is provided")]
        [TestMethod]
        public void WriteNegativeCount()
        {
            using (var stream = new ChunkedMemoryStream())
            {
                ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => stream.Write(new byte[5], 0, -1));
            }
        }

        /// <summary>
        /// Writes to a stream when the buffer is not large enough
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to a stream when the buffer is not large enough")]
        [TestMethod]
        public void WriteBadBufferLength()
        {
            using (var stream = new ChunkedMemoryStream())
            {
                ExceptionAssert.Throws<ArgumentException>(() => stream.Write(new byte[5], 1, 6));
            }
        }

        /// <summary>
        /// Writes to a stream that is read-only
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to a stream that is read-only")]
        [TestMethod]
        public void WriteReadOnly()
        {
            using (var stream = new ChunkedMemoryStream(new byte[0], false))
            {
                ExceptionAssert.Throws<NotSupportedException>(() => stream.Write(new byte[5], 0, 5));
            }
        }

        /// <summary>
        /// Writes to a disposed stream
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to a disposed stream")]
        [TestMethod]
        public void WriteDisposed()
        {
            ChunkedMemoryStream stream = null;
            try
            {
                stream = new ChunkedMemoryStream();
            }
            finally
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
            }

            ExceptionAssert.Throws<ObjectDisposedException>(() => stream.Write(new byte[5], 0, 5));
        }

        /// <summary>
        /// Gets the array of a disposed stream
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Gets the array of a disposed stream")]
        [TestMethod]
        public void ToArrayDisposed()
        {
            ChunkedMemoryStream stream = null;
            try
            {
                stream = new ChunkedMemoryStream();
            }
            finally
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
            }

            ExceptionAssert.Throws<ObjectDisposedException>(() => stream.ToArray());
        }
    }
}
