using System.Runtime.InteropServices;
using System.Text;
using Ouroboros.Defintions;

namespace Ouroboros.PInvoke;

public static partial class UnsafeNativeMethods
{
    [LibraryImport("kernel32.dll")]
    public static partial WaitEventResult WaitForSingleObject(nint hObject, int timeout);

    #region Thumbnail Manipulation

    [LibraryImport("dwmapi.dll")]
    public static partial int DwmRegisterThumbnail(nint dest, nint src, out nint thumb);

    [DllImport("dwmapi.dll")]
    public static extern int DwmUpdateThumbnailProperties(nint hThumb, ref ThumbnailProperties props);

    [LibraryImport("dwmapi.dll")]
    public static partial int DwmUnregisterThumbnail(nint thumb);

    #endregion

    #region Thread Manipulation

    [LibraryImport("kernel32")]
    public static partial nint CreateRemoteThread(
        nint hProcess, nint lpThreadAttributes, nint dwStackSize, nuint lpStartAddress, nint lpParameter, uint dwCreationFlags,
        out nint lpThreadId);

    [LibraryImport("kernel32.dll")]
    public static partial int ResumeThread(nint hThread);

    #endregion

    #region Process Manipulation

    [LibraryImport("kernel32.dll")]
    public static partial nuint GetProcAddress(nint hModule, [MarshalAs(UnmanagedType.LPStr)] string procName);

    [LibraryImport("kernel32.dll", EntryPoint = "CreateProcessW", StringMarshalling = StringMarshalling.Utf16)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool CreateProcess(
        string applicationName, string? commandLine, nint processAttributes, nint threadAttributes, [MarshalAs(UnmanagedType.Bool)] bool inheritHandles,
        ProcessCreationFlags creationFlags, nint environment, string? currentDirectory, ref StartupInformation startupInfo,
        out ProcessInformation processInfo);

    [LibraryImport("kernel32.dll")]
    public static partial nint OpenProcess(ProcessAccessFlags access, [MarshalAs(UnmanagedType.Bool)] bool inheritHandle, int processId);

    [LibraryImport("kernel32.dll", EntryPoint = "GetModuleHandleA")]
    public static partial nint GetModuleHandle([MarshalAs(UnmanagedType.LPStr)] string lpModuleName);
    
    [DllImport("psapi.dll", SetLastError = true)]
    public static extern bool EnumProcessModulesEx(nint hProcess, [Out] nint[] lphModule, int cb, out int lpcbNeeded, DwFilterFlag dwFilterFlag);
    
    [DllImport("psapi.dll", SetLastError = true)]
    public static extern uint GetModuleFileNameEx(nint hProcess, nint hModule, [Out] StringBuilder lpBaseName, int nSize);

    [LibraryImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool CloseHandle(nint handle);

    #endregion

    #region Memory Manipulation

    [LibraryImport("kernel32.dll", SetLastError = true)]
    public static partial nint VirtualAllocEx(nint hProcess, nint lpAddress, nint dwSize, uint flAllocationType, uint flProtect);

    [LibraryImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool VirtualFreeEx(nint hProcess, nint lpAddress, nuint dwSize, uint dwFreeType);

    [LibraryImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool WriteProcessMemory(
        nint hProcess,
        nint lpBaseAddress,
        [MarshalAs(UnmanagedType.LPStr)] string lpBuffer,
        nuint nSize,
        out nint lpNumberOfBytesWritten);

    [LibraryImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool WriteProcessMemory(nint hProcess, nint baseAddress, nint buffer, nint count, out int bytesWritten);

    [LibraryImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool ReadProcessMemory(nint hProcess, nint baseAddress, nint buffer, nint count, out int bytesRead);

    #endregion

    #region Window Manipulation

    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool ShowWindowAsync(nint hWnd, ShowWindowFlags nCmdShow);

    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool ShowWindow(nint hWnd, ShowWindowFlags nCmdShow);

    [LibraryImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool MoveWindow(nint hwnd, int x, int y, int nWidth, int nHeight, [MarshalAs(UnmanagedType.Bool)] bool bRepaint);

    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool IsWindowVisible(nint hWnd);
    
    [LibraryImport("user32.dll")]
    public static partial uint GetDpiForWindow(nint hwnd);
    
    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool AdjustWindowRectEx(ref Rect lpRect, WindowStyleFlags dwStyle, [MarshalAs(UnmanagedType.Bool)] bool bMenu, uint dwExStyle);
    
    [LibraryImport("Shcore.dll")]
    public static partial nint GetDpiForMonitor(nint hmonitor, int dpiType, out uint dpiX, out uint dpiY);

    [LibraryImport("user32.dll")]
    public static partial nint MonitorFromWindow(nint hwnd, uint dwFlags);
    
    #endregion

    #region GetWindow

    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool GetWindowRect(nint hwnd, ref Rect rectangle);

    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool GetClientRect(nint hWnd, ref Rect rectangle);

    [LibraryImport("user32.dll", EntryPoint = "GetWindowLongW")]
    public static partial WindowStyleFlags GetWindowLong(nint hWnd, WindowFlags nIndex);

    #endregion

    #region SetWindow

    [LibraryImport("user32.dll", StringMarshalling = StringMarshalling.Utf16)]
    public static partial int SetWindowText(nint hWnd, string text);

    [LibraryImport("user32.dll")]
    public static partial int SetWindowLong(nint hWnd, WindowFlags nIndex, WindowStyleFlags dwNewLong);

    [LibraryImport("User32.dll")]
    public static partial int SetForegroundWindow(int hWnd);

    #endregion
}