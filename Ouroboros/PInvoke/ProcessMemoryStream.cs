using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Ouroboros.Defintions;

namespace Ouroboros.PInvoke
{
    public sealed class ProcessMemoryStream : Stream
    {
        private readonly ProcessAccessFlags AccessType;
        private bool Disposed;
        private nint ProcessHandle;

        public override long Position { get; set; }
        public int ProcessId { get; set; }

        ~ProcessMemoryStream() => Dispose(false);

        public override bool CanRead => (AccessType & ProcessAccessFlags.VmRead) > ProcessAccessFlags.None;

        public override bool CanSeek => true;

        public override bool CanWrite =>
            (AccessType & (ProcessAccessFlags.VmOperation | ProcessAccessFlags.VmWrite)) > ProcessAccessFlags.None;

        public override long Length => throw new NotSupportedException("Length unsupported.");

        public ProcessMemoryStream(ProcessInformation procInfo, ProcessAccessFlags access)
        {
            AccessType = access;
            ProcessId = procInfo.ProcessId;
            ProcessHandle = procInfo.ProcessHandle;

            if (ProcessHandle == nint.Zero)
                throw new ArgumentException("Unable to open the process.");
        }

        public override void Flush() => throw new NotSupportedException("Flush unsupported.");

        public override void SetLength(long value) => throw new NotSupportedException("Length unsupported.");

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (Disposed)
                throw new ObjectDisposedException("ProcMemoryStream");

            if (ProcessHandle == nint.Zero)
                throw new InvalidOperationException("Process is not open.");

            var num = Marshal.AllocHGlobal(count);

            if (num == nint.Zero)
                throw new InvalidOperationException("Unable to allocate memory.");

            UnsafeNativeMethods.ReadProcessMemory(ProcessHandle, (nint)Position, num, count, out var bytesRead);
            Position += bytesRead;
            Marshal.Copy(num, buffer, offset, count);
            Marshal.FreeHGlobal(num);

            return bytesRead;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            if (Disposed)
                throw new ObjectDisposedException("ProcMemoryStream");

            switch (origin)
            {
                case SeekOrigin.Begin:
                    Position = offset;

                    break;
                case SeekOrigin.Current:
                    Position += offset;

                    break;
                case SeekOrigin.End:
                    throw new NotSupportedException("SeekOrigin.End unsupported.");
            }

            return Position;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (Disposed)
                throw new ObjectDisposedException("ProcMemoryStream");

            if (ProcessHandle == nint.Zero)
                throw new InvalidOperationException("Process is not open.");

            var allocDestination = Marshal.AllocHGlobal(count);

            if (allocDestination == nint.Zero)
                throw new InvalidOperationException("Unable to allocate memory.");

            Marshal.Copy(buffer, offset, allocDestination, count);

            UnsafeNativeMethods.WriteProcessMemory(ProcessHandle, (nint)Position, allocDestination, count, out var bytes);
            Position += bytes;
            Marshal.FreeHGlobal(allocDestination);
        }

        public override void WriteByte(byte value) => Write(new[] { value }, 0, 1);

        public void WriteString(string value) => Write(Encoding.ASCII.GetBytes(value), 0, value.Length);

        public override void Close()
        {
            if (Disposed)
                throw new ObjectDisposedException("ProcMemoryStream");

            if (ProcessHandle != nint.Zero)
            {
                UnsafeNativeMethods.CloseHandle(ProcessHandle);
                ProcessHandle = nint.Zero;
            }

            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (ProcessHandle != nint.Zero)
                {
                    UnsafeNativeMethods.CloseHandle(ProcessHandle);
                    ProcessHandle = nint.Zero;
                }

                base.Dispose(disposing);
            }

            Disposed = true;
        }
    }
}