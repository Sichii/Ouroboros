using System.Runtime.InteropServices;

namespace Injector32;

public static class UnsafeNativeMethods
{
    [DllImport("kernel32.dll")]
    public static extern WaitEventResult WaitForSingleObject(nint hObject, int timeout);
    
    [DllImport("kernel32")]
    public static extern nint CreateRemoteThread(
        nint hProcess,
        nint lpThreadAttributes,
        nint dwStackSize,
        nuint lpStartAddress,
        nint lpParameter,
        uint dwCreationFlags,
        out nint lpThreadId);

    [DllImport("kernel32.dll")]
    public static extern int ResumeThread(nint hThread);

    [DllImport(
        "kernel32.dll",
        ExactSpelling = true,
        BestFitMapping = false,
        ThrowOnUnmappableChar = true)]
    public static extern nuint GetProcAddress(nint hModule, string procName);

    [DllImport("kernel32.dll")]
    public static extern nint OpenProcess(ProcessAccessFlags access, bool inheritHandle, int processId);

    [DllImport(
        "kernel32.dll",
        CharSet = CharSet.Auto,
        BestFitMapping = false,
        ThrowOnUnmappableChar = true)]
    public static extern nint GetModuleHandle(string lpModuleName);

    [DllImport("kernel32.dll")]
    public static extern bool CloseHandle(nint handle);
    
    [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
    public static extern nint VirtualAllocEx(
        nint hProcess,
        nint lpAddress,
        nint dwSize,
        uint flAllocationType,
        uint flProtect);

    [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
    public static extern bool VirtualFreeEx(
        nint hProcess,
        nint lpAddress,
        nuint dwSize,
        uint dwFreeType);

    [DllImport("kernel32.dll", BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern bool WriteProcessMemory(
        nint hProcess,
        nint lpBaseAddress,
        string lpBuffer,
        nuint nSize,
        out nint lpNumberOfBytesWritten);
}