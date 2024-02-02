using System.Runtime.InteropServices;
using System.Text;
using Ouroboros.Defintions;

namespace Ouroboros.PInvoke;

public static class UnsafeNativeMethods
{
    [DllImport("kernel32.dll")]
    public static extern WaitEventResult WaitForSingleObject(nint hObject, int timeout);

    #region Thumbnail Manipulation

    [DllImport("dwmapi.dll")]
    public static extern int DwmRegisterThumbnail(nint dest, nint src, out nint thumb);

    [DllImport("dwmapi.dll")]
    public static extern int DwmUpdateThumbnailProperties(nint hThumb, ref ThumbnailProperties props);

    [DllImport("dwmapi.dll")]
    public static extern int DwmUnregisterThumbnail(nint thumb);

    #endregion

    #region Thread Manipulation

    [DllImport("kernel32")]
    public static extern nint CreateRemoteThread(
        nint hProcess, nint lpThreadAttributes, nint dwStackSize, nuint lpStartAddress, nint lpParameter, uint dwCreationFlags,
        out nint lpThreadId);

    [DllImport("kernel32.dll")]
    public static extern int ResumeThread(nint hThread);

    #endregion

    #region Process Manipulation

    [DllImport("kernel32.dll", ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern nuint GetProcAddress(nint hModule, string procName);

    [DllImport("kernel32.dll", BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern bool CreateProcess(
        string applicationName, string? commandLine, nint processAttributes, nint threadAttributes, bool inheritHandles,
        ProcessCreationFlags creationFlags, nint environment, string? currentDirectory, ref StartupInformation startupInfo,
        out ProcessInformation processInfo);

    [DllImport("kernel32.dll")]
    public static extern nint OpenProcess(ProcessAccessFlags access, bool inheritHandle, int processId);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern nint GetModuleHandle(string lpModuleName);
    
    [DllImport("psapi.dll", SetLastError = true)]
    public static extern bool EnumProcessModulesEx(nint hProcess, [Out] nint[] lphModule, int cb, out int lpcbNeeded, DwFilterFlag dwFilterFlag);
    
    [DllImport("psapi.dll", SetLastError = true)]
    public static extern uint GetModuleFileNameEx(nint hProcess, nint hModule, [Out] StringBuilder lpBaseName, int nSize);

    [DllImport("kernel32.dll")]
    public static extern bool CloseHandle(nint handle);

    #endregion

    #region Memory Manipulation

    [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
    public static extern nint VirtualAllocEx(nint hProcess, nint lpAddress, nint dwSize, uint flAllocationType, uint flProtect);

    [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
    public static extern bool VirtualFreeEx(nint hProcess, nint lpAddress, nuint dwSize, uint dwFreeType);

    [DllImport("kernel32.dll", BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern bool WriteProcessMemory(
        nint hProcess, nint lpBaseAddress, string lpBuffer, nuint nSize, out nint lpNumberOfBytesWritten);

    [DllImport("kernel32.dll")]
    public static extern bool WriteProcessMemory(nint hProcess, nint baseAddress, nint buffer, nint count, out int bytesWritten);

    [DllImport("kernel32.dll")]
    public static extern bool ReadProcessMemory(nint hProcess, nint baseAddress, nint buffer, nint count, out int bytesRead);

    #endregion

    #region Window Manipulation

    [DllImport("user32.dll")]
    public static extern bool ShowWindowAsync(nint hWnd, ShowWindowFlags nCmdShow);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool ShowWindow(nint hWnd, ShowWindowFlags nCmdShow);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool MoveWindow(nint hwnd, int x, int y, int nWidth, int nHeight, bool bRepaint);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool IsWindowVisible(nint hWnd);
    
    [DllImport("user32.dll")]
    public static extern uint GetDpiForWindow(nint hwnd);
    
    [DllImport("user32.dll")]
    public static extern bool AdjustWindowRectEx(ref Rect lpRect, WindowStyleFlags dwStyle, bool bMenu, uint dwExStyle);
    
    [DllImport("Shcore.dll")]
    public static extern nint GetDpiForMonitor(nint hmonitor, int dpiType, out uint dpiX, out uint dpiY);

    [DllImport("user32.dll")]
    public static extern nint MonitorFromWindow(nint hwnd, uint dwFlags);
    
    #endregion

    #region GetWindow

    [DllImport("user32.dll")]
    public static extern bool GetWindowRect(nint hwnd, ref Rect rectangle);

    [DllImport("user32.dll")]
    public static extern bool GetClientRect(nint hWnd, ref Rect rectangle);

    [DllImport("user32.dll")]
    public static extern WindowStyleFlags GetWindowLong(nint hWnd, WindowFlags nIndex);

    #endregion

    #region SetWindow

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern int SetWindowText(nint hWnd, string text);

    [DllImport("user32.dll")]
    public static extern int SetWindowLong(nint hWnd, WindowFlags nIndex, WindowStyleFlags dwNewLong);

    [DllImport("User32.dll")]
    public static extern int SetForegroundWindow(int hWnd);

    #endregion
}