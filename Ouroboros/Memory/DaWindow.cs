using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Chaos.Geometry;
using Ouroboros.Defintions;
using Ouroboros.PInvoke;

namespace Ouroboros.Memory;

public class DaWindow : IDisposable
{
    public Process Process { get; }
    public nint WindowHandle => Process.MainWindowHandle;
    public nint ThreadHandle { get; }
    public ProcessMemoryStream Pms { get; }
    private const string INJECTOR_EXE = "Injector32.exe";

    private DaWindow(ProcessInformation processInfo)
    {
        Process = Process.GetProcessById(processInfo.ProcessId);
        ThreadHandle = processInfo.ThreadHandle;
        Pms = new ProcessMemoryStream(processInfo, ProcessAccessFlags.FullAccess);
    }

    public static unsafe DaWindow Create(string path)
    {
        var startupInfo = new StartupInformation
        {
            Size = sizeof(StartupInformation)
        };
        var dir = Path.GetDirectoryName(path);

        UnsafeNativeMethods.CreateProcess(
            path,
            null,
            nint.Zero,
            nint.Zero,
            false,
            ProcessCreationFlags.Suspended | ProcessCreationFlags.DetachedProcess | ProcessCreationFlags.NewProcessGroup,
            nint.Zero,
            dir,
            ref startupInfo,
            out var processInfo);

        return new DaWindow(processInfo);
    }

    public async Task InjectDawndAsync()
    {
        var tcs = new TaskCompletionSource();
        var startInfo = new ProcessStartInfo(INJECTOR_EXE, Process.Id.ToString())
        {
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var proc = new Process();
        proc.StartInfo = startInfo;
        proc.EnableRaisingEvents = true;
        proc.Exited += (_, _) => tcs.TrySetResult();
        
        proc.Start();
        
        await tcs.Task;
    }
    
    public void ApplyMemoryEdits(MemoryEditFlags memoryEditFlags)
    {
        if (memoryEditFlags.HasFlag(MemoryEditFlags.SkipLoadWall))
        {
            Pms.Seek(CONSTANTS.SKIP_LOAD_WALLS_OFFSET, SeekOrigin.Begin);
            Pms.WriteByte(0x90);
            Pms.WriteByte(0x90);
            Pms.WriteByte(0x90);
            Pms.WriteByte(0x90);
            Pms.WriteByte(0x90);
        }

        if (memoryEditFlags.HasFlag(MemoryEditFlags.ForceJumpIp))
        {
            Pms.Seek(CONSTANTS.FORCEJUMP_IP_OFFSET, SeekOrigin.Begin);
            Pms.WriteByte(0xEB);
        }

        if (memoryEditFlags.HasFlag(MemoryEditFlags.OverwriteIp))
        {
            Pms.Seek(CONSTANTS.OVERWRITE_IP_OFFSET, SeekOrigin.Begin);
            Pms.WriteByte(106);
            Pms.WriteByte(1);
            Pms.WriteByte(106);
            Pms.WriteByte(0);
            Pms.WriteByte(106);
            Pms.WriteByte(0);
            Pms.WriteByte(106);
            Pms.WriteByte(127);
        }

        if (memoryEditFlags.HasFlag(MemoryEditFlags.OverwritePort))
        {
            Pms.Seek(CONSTANTS.PORT_OFFSET, SeekOrigin.Begin);
            Pms.WriteByte(CONSTANTS.LOOPBACK_LOBBY_PORT % 256);
            Pms.WriteByte(CONSTANTS.LOOPBACK_LOBBY_PORT / 256);
        }

        if (memoryEditFlags.HasFlag(MemoryEditFlags.SkipIntro))
        {
            Pms.Seek(CONSTANTS.SKIP_INTRO_OFFSET, SeekOrigin.Begin);
            Pms.WriteByte(0x90);
            Pms.WriteByte(0x90);
            Pms.WriteByte(0x90);
            Pms.WriteByte(0x90);
            Pms.WriteByte(0x90);
            Pms.WriteByte(0x90);
        }

        if (memoryEditFlags.HasFlag(MemoryEditFlags.ForceJumpInstanceCheck))
        {
            Pms.Seek(CONSTANTS.FORCEJUMP_INSTANCE_CHECK_OFFSET, SeekOrigin.Begin);
            Pms.WriteByte(0xEB);
        }
    }

    public async Task WaitForHandleAsync()
    {
        _ = UnsafeNativeMethods.ResumeThread(ThreadHandle);

        while (Process.MainWindowHandle == nint.Zero)
            await Task.Delay(25);
    }

    public void Resize(WindowSize windowSize)
    {
        switch (windowSize)
        {
            case WindowSize.Small:
                Resize(
                    Process.MainWindowHandle,
                    640,
                    480,
                    false);

                break;
            case WindowSize.Large:
                Resize(
                    Process.MainWindowHandle,
                    1280,
                    960,
                    false);

                break;
            case WindowSize.Large4k:
                Resize(
                    Process.MainWindowHandle,
                    2560,
                    1920,
                    false);

                break;
            case WindowSize.WindowedFullscreen:
                Resize(
                    Process.MainWindowHandle,
                    0,
                    0,
                    true);

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Resize(
        nint mainWindowHandle,
        int width,
        int height,
        bool fullScreen)
    {
        //if fullscreen, we arent resizing, we're just removing the titlebar and maximizing
        if (fullScreen)
        {
            //set borderless windowed fullscreen
            _ = UnsafeNativeMethods.SetWindowLong(mainWindowHandle, WindowFlags.Style, WindowStyleFlags.Visible);
            _ = UnsafeNativeMethods.ShowWindowAsync(mainWindowHandle, ShowWindowFlags.ActiveMaximized);
        } else
        {
            //otherwise
            var clientRect = new Rect();
            var windowRect = new Rect();

            UnsafeNativeMethods.GetClientRect(mainWindowHandle, ref clientRect);
            UnsafeNativeMethods.GetWindowRect(mainWindowHandle, ref windowRect);
            
            //if it doesnt have a titlebar, set the window back to a normal state (overlappedwindow)
            if (!UnsafeNativeMethods.GetWindowLong(mainWindowHandle, WindowFlags.Style)
                                    .HasFlag(WindowStyleFlags.Caption))
                _ = UnsafeNativeMethods.SetWindowLong(mainWindowHandle, WindowFlags.Style, WindowStyleFlags.OverlappedWindow);

            AdjustForDpiAndWindowStyle(ref width, ref height);
            
            //set window size
            UnsafeNativeMethods.MoveWindow(
                mainWindowHandle,
                windowRect.Left,
                windowRect.Top,
                width,
                height,
                true);
        }
    }
    
    private void AdjustForDpiAndWindowStyle(ref int width, ref int height)
    {
        var monitorHandle = UnsafeNativeMethods.MonitorFromWindow(Process.MainWindowHandle, 0 /* MONITOR_DEFAULTTONEAREST */);
        
        UnsafeNativeMethods.GetDpiForMonitor(monitorHandle, 0, out var dpiX, out _);
        
        var scalingFactor = dpiX / 96.0m;
        
        width = (int)Math.Ceiling(width * scalingFactor);
        height = (int)Math.Ceiling(height * scalingFactor);
        
        var rect = new Rect
        {
            Right = width - 1,
            Bottom = height - 1
        };
        
        var wStyle = UnsafeNativeMethods.GetWindowLong(Process.MainWindowHandle, WindowFlags.Style);
        var wStyleEx = UnsafeNativeMethods.GetWindowLong(Process.MainWindowHandle, WindowFlags.ExtendedStyle);
        
        UnsafeNativeMethods.AdjustWindowRectEx(ref rect, wStyle, false, (uint)wStyleEx);
        
        width = rect.Right - rect.Left + 1;
        height = rect.Bottom - rect.Top + 1;
    }

    public string ReadName()
    {
        var buffer = new byte[13];
        Pms.Seek(CONSTANTS.AISLING_NAME_OFFSET, SeekOrigin.Begin);
        // ReSharper disable once MustUseReturnValue
        Pms.Read(buffer, 0, 13);

        return Encoding.UTF8
                       .GetString(buffer)
                       .Trim('\0')
                       .Split('\0')[0];
    }

    public void WriteName(string name)
    {
        var data = Encoding.UTF8.GetBytes(name);
        Pms.Seek(CONSTANTS.AISLING_NAME_OFFSET, SeekOrigin.Begin);
        Pms.Write(data, 0, data.Length);
    }

    #region IDisposable Support
    private bool DisposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!DisposedValue)
        {
            if (disposing)
            {
                Pms.Dispose();
                Process.Dispose();
            }

            if (ThreadHandle != nint.Zero)
                Marshal.FreeHGlobal(ThreadHandle);

            DisposedValue = true;
        }
    }

    ~DaWindow() => Dispose(false);

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    #endregion
}