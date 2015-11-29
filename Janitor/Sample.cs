using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Janitor
{
    class Sample : IDisposable
    {
        MemoryStream stream;
        IntPtr handle;

        public Sample()
        {
            stream = new MemoryStream();
            handle = new IntPtr();
        }

        public void Method()
        {
            // Some code
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        void DisposeUnmanaged()
        {
            CloseHandle(handle);
            handle = IntPtr.Zero;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hObject);
    }
}