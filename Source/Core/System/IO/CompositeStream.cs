namespace System.IO
{
    using System.Collections.Generic;
    using System.Linq;

    using Fx;

    /// <summary>
    /// 
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed class CompositeStream : Stream
    {
        private readonly IEnumerator<Stream> streams;

        private bool hasCurrent;

        private bool disposed;

        public CompositeStream(IEnumerable<Stream> streams)
        {
            Ensure.NotNull(streams, nameof(streams));
            if (!streams.All(stream => stream.CanRead))
            {
                //// TODO is this a good thing to check here?
                throw new ArgumentException(Strings.CompositeStreamReadable);
            }

            this.streams = streams.GetEnumerator();
            try
            {
                this.hasCurrent = this.streams.MoveNext();
            }
            catch
            {
                this.streams.Dispose();
                throw;
            }

            this.disposed = false;
        }

        public override bool CanRead
        {
            get
            {
                return true;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return false;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        public override long Length
        {
            get
            {
                throw new NotSupportedException("TODO");
            }
        }

        public override long Position
        {
            get
            {
                throw new NotSupportedException("TODO");
            }

            set
            {
                throw new NotSupportedException("TODO");
            }
        }

        public override void Flush()
        {
            throw new NotSupportedException("TODO");
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            while (this.hasCurrent)
            {
                var read = this.streams.Current.Read(buffer, offset, count);
                if (read != 0)
                {
                    return read;
                }

                this.hasCurrent = this.streams.MoveNext();
            }

            return 0;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException("TODO");
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException("TODO");
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException("TODO");
        }

        protected override void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                this.streams.Dispose();
            }

            this.disposed = true;
            base.Dispose(disposing);
        }
    }
}
