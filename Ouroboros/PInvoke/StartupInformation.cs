using System.Runtime.InteropServices;

namespace Ouroboros.PInvoke;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct StartupInformation
{
    public int Size;
    public char* Reserved;
    public char* Desktop;
    public char* Title;
    public int X;
    public int Y;
    public int Width;
    public int Height;
    public int XCountChars;
    public int YCountChars;
    public int FillAttribute;
    public int Flags;
    public short ShowWindow;
    public short Reserved2;
    public nint Reserved3;
    public nint StdInputHandle;
    public nint StdOutputHandle;
    public nint StdErrorHandle;
}