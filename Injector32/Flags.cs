namespace Injector32;

[Flags]
public enum ProcessAccessFlags : uint
{
    None = 0,
    Terminate = 0x0001,
    CreateThread = 0x0002,
    VmOperation = 0x0008,
    VmRead = 0x0010,
    VmWrite = 0x0020,
    DuplicateHandle = 0x0040,
    CreateProcess = 0x0080,
    SetQuota = 0x0100,
    SetInformation = 0x0200,
    QueryInformation = 0x0400,
    SuspendResume = 0x0800,
    QueryLimitedInformation = 0x1000,
    Synchronize = 0x00100000,
    FullAccess = 0x1F0FFF
}

[Flags]
public enum WaitEventResult : uint
{
    Signaled = 0,
    Abandoned = 128,
    Timeout = 258,
    Failed = uint.MaxValue
}