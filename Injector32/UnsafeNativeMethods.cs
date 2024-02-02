using System.Runtime.InteropServices;

namespace Injector32;

public static partial class UnsafeNativeMethods
{
    [LibraryImport("kernel32.dll")]
    public static partial WaitEventResult WaitForSingleObject(nint hObject, int timeout);
    
    [LibraryImport("kernel32")]
    public static partial nint CreateRemoteThread(
        nint hProcess,
        nint lpThreadAttributes,
        nint dwStackSize,
        nuint lpStartAddress,
        nint lpParameter,
        uint dwCreationFlags,
        out nint lpThreadId);

    [LibraryImport("kernel32.dll")]
    public static partial int ResumeThread(nint hThread);

    [LibraryImport("kernel32.dll")]
    public static partial nuint GetProcAddress(nint hModule, [MarshalAs(UnmanagedType.LPStr)] string procName);

    [LibraryImport("kernel32.dll")]
    public static partial nint OpenProcess(ProcessAccessFlags access, [MarshalAs(UnmanagedType.Bool)] bool inheritHandle, int processId);

    [LibraryImport("kernel32.dll", EntryPoint = "GetModuleHandleA")]
    public static partial nint GetModuleHandle([MarshalAs(UnmanagedType.LPStr)] string lpModuleName);

    [LibraryImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool CloseHandle(nint handle);
    
    [LibraryImport("kernel32.dll", SetLastError = true)]
    public static partial nint VirtualAllocEx(
        nint hProcess,
        nint lpAddress,
        nint dwSize,
        uint flAllocationType,
        uint flProtect);

    [LibraryImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool VirtualFreeEx(
        nint hProcess,
        nint lpAddress,
        nuint dwSize,
        uint dwFreeType);

    [LibraryImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool WriteProcessMemory(
        nint hProcess,
        nint lpBaseAddress,
        [MarshalAs(UnmanagedType.LPStr)] string lpBuffer,
        nuint nSize,
        out nint lpNumberOfBytesWritten);
}