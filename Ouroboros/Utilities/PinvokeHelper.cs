using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Chaos.Extensions.Common;
using Ouroboros.Defintions;
using Ouroboros.PInvoke;

namespace Ouroboros.Utilities;

public static class PinvokeHelper
{
    private const int MAX_PATH = 260;
    
    private static nint[] EnumerateProcessModules(nint processHandle)
    {
        var modules = new nint[1024];

        if (!UnsafeNativeMethods.EnumProcessModulesEx(
                processHandle,
                modules,
                Marshal.SizeOf(typeof(nint)) * modules.Length,
                out var bytesNeeded,
                DwFilterFlag.LIST_MODULES_32BIT))
            throw new Win32Exception(Marshal.GetLastWin32Error());
        
        var totalModules = bytesNeeded / Marshal.SizeOf(typeof(nint));
        var resultModules = new nint[totalModules];
        Array.Copy(modules, resultModules, totalModules);

        return resultModules;
    }
    
    // ReSharper disable once ParameterTypeCanBeEnumerable.Global
    private static nint GetSpecificModuleHandle(nint processHandle, nint[] modules, string moduleName)
    {
        var moduleNameBuilder = new StringBuilder(MAX_PATH);
        
        foreach (var module in modules)
        {
            _ = UnsafeNativeMethods.GetModuleFileNameEx(processHandle, module, moduleNameBuilder, MAX_PATH);
            if (moduleNameBuilder.ToString().ContainsI(moduleName))
                return module; // Found the module handle
        }
        return nint.Zero; // Module not found
    }
    
    public static nint[] EnumerateModules(int processId)
    {
        var processHandle = UnsafeNativeMethods.OpenProcess(
            ProcessAccessFlags.QueryInformation | ProcessAccessFlags.VmRead,
            false,
            processId);
        
        var modules = EnumerateProcessModules(processHandle);
        UnsafeNativeMethods.CloseHandle(processHandle);
        
        return modules;
    }
    
    public static nint GetModuleHandle(nint processHandle, string moduleName)
    {
        var modules = EnumerateProcessModules(processHandle);
        return GetSpecificModuleHandle(processHandle, modules, moduleName);
    }
    
    public static nint GetModuleHandle(int processId, string moduleName)
    {
        var processHandle = UnsafeNativeMethods.OpenProcess(
            ProcessAccessFlags.QueryInformation | ProcessAccessFlags.VmRead,
            false,
            processId);

        var modules = EnumerateProcessModules(processHandle);
        
        var moduleHandle = GetSpecificModuleHandle(processHandle, modules, moduleName);
        UnsafeNativeMethods.CloseHandle(processHandle);
        
        return moduleHandle;
    }
}