// See https://aka.ms/new-console-template for more information

using Injector32;

var processId = int.Parse(args[0]);
const string DLL_NAME = "dawnd.dll";

var accessHandle = UnsafeNativeMethods.OpenProcess(ProcessAccessFlags.FullAccess, true, processId);

//length of string containing the DLL file name +1 byte padding
var nameLength = DLL_NAME.Length + 1;

//allocate memory within the virtual address space of the target process
var allocate = UnsafeNativeMethods.VirtualAllocEx(
    accessHandle,
    (nint)null,
    nameLength,
    0x1000,
    0x40); //allocation pour WriteProcessMemory

//write DLL file name to allocated memory in target process
UnsafeNativeMethods.WriteProcessMemory(
    accessHandle,
    allocate,
    DLL_NAME,
    (nuint)nameLength,
    out _);

//retreive function pointer for remote thread
var injectionPtr = UnsafeNativeMethods.GetProcAddress(UnsafeNativeMethods.GetModuleHandle("kernel32.dll"), "LoadLibraryA");

//if failed to retreive function pointer
if (injectionPtr == nuint.Zero)
    return 0;

//create thread in target process, and store accessHandle in hThread
var thread = UnsafeNativeMethods.CreateRemoteThread(
    accessHandle,
    (nint)null,
    nint.Zero,
    injectionPtr,
    allocate,
    0,
    out _);

//make sure thread accessHandle is valid
if (thread == nint.Zero)
    return 0;

//time-out is 10 seconds...
var result = UnsafeNativeMethods.WaitForSingleObject(thread, 10 * 1000);

//check whether thread timed out...
if (result != WaitEventResult.Signaled)
{
    //thread timed out...
    //make sure thread accessHandle is valid before closing... prevents crashes.
    if (thread != nint.Zero)

        //close thread in target process
        UnsafeNativeMethods.CloseHandle(thread);

    return 0;
}

//free up allocated space ( AllocMem )
UnsafeNativeMethods.VirtualFreeEx(
    accessHandle,
    allocate,
    0,
    0x8000);

//make sure thread accessHandle is valid before closing... prevents crashes.
if (thread != nint.Zero)

    //close thread in target process
    UnsafeNativeMethods.CloseHandle(thread);

//return succeeded
return 1;