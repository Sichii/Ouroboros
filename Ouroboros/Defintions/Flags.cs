namespace Ouroboros.Defintions;

#region PInvoke
[Flags]
public enum WaitEventResult : uint
{
    Signaled = 0,
    Abandoned = 128,
    Timeout = 258,
    Failed = uint.MaxValue
}

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
public enum DwFilterFlag : uint
{
    LIST_MODULES_DEFAULT = 0x00,
    LIST_MODULES_32BIT = 0x01,
    LIST_MODULES_64BIT = 0x02,
    LIST_MODULES_ALL = 0x03,
}

[Flags]
public enum ProcessCreationFlags : uint
{
    DebugProcess = 0x0001,
    DebugOnlyThisProcess = 0x0002,
    Suspended = 0x0004,
    DetachedProcess = 0x0008,
    NewConsole = 0x0010,
    NewProcessGroup = 0x0200,
    UnicodeEnvironment = 0x0400,
    SeparateWowVdm = 0x0800,
    SharedWowVdm = 0x1000,
    InheritParentAffinity = 0x00010000,
    ProtectedProcess = 0x00040000,
    ExtendedStartupInfoPresent = 0x00080000,
    BreakawayFromJob = 0x01000000,
    PreserveCodeAuthZLevel = 0x02000000,
    DefaultErrorMode = 0x04000000,
    NoWindow = 0x08000000
}


[Flags]
public enum ThumbnailFlags
{
    RectDestination = 1,
    RectSource = 2,
    Opacity = 4,
    Visible = 8,
    SourceClientAreaOnly = 16,
    All = RectDestination | RectSource | Opacity | Visible | SourceClientAreaOnly
}

[Flags]
public enum WindowStyleFlags : uint
{
    Border = 0x00800000,
    Caption = 0x00C00000,
    Child = 0x40000000,
    ClipChildren = 0x02000000,
    ClipSiblings = 0x04000000,
    Disabled = 0x08000000,
    DialogFrame = 0x00400000,
    Group = 0x00020000,
    HorizontalScroll = 0x00100000,
    VerticalScroll = 0x00200000,
    Minimized = 0x20000000,
    Maximized = 0x01000000,
    MaximizeBox = 0x00010000,
    MinimizeBox = Group,
    Overlapped = 0x00000000,
    OverlappedWindow = Overlapped | Caption | SystemMenu | Sizeable | MinimizeBox | MaximizeBox | Visible,
    Popup = 0x80000000,
    PopupWindow = Popup | Border | SystemMenu | Visible,
    Sizeable = 0x00040000,
    SystemMenu = 0x00080000,
    TabStop = MaximizeBox,
    Visible = 0x10000000
}

[Flags]
public enum WindowFlags
{
    None = 0,
    WndProc = -4,
    InstanceHandle = -6,
    ID = -12,
    Style = -16,
    ExtendedStyle = -20,
    UserData = -21
}

[Flags]
public enum ShowWindowFlags
{
    Hide = 0,
    ActiveNormal = 1,
    ActiveMinimized = 2,
    ActiveMaximized = 3,
    InactiveNormal = 4,
    ActiveShow = 5,
    MinimizeNext = 6,
    InactiveMinimized = 7,
    InactiveShow = 8,
    ActiveRestore = 9,
    Default = 10,
    ForceMinimized = 11
}

#endregion

[Flags]
public enum MemoryEditFlags
{
    SkipLoadWall = 0x0001,
    ForceJumpIp = 0x0002,
    OverwriteIp = 0x0004,
    OverwritePort = 0x0008,
    SkipIntro = 0x0010,
    ForceJumpInstanceCheck = 0x0020,
    AllExceptWalls = ForceJumpIp | OverwriteIp | OverwritePort | SkipIntro | ForceJumpInstanceCheck
}

[Flags]
public enum CheatFlags
{
    None = 0,
    NoBlind = 1,
    SeeHide = 2,
    SeeGhost = 4,
    MapZoom = 8,
    NoCollision = 16
}

[Flags]
public enum WeaponFlags : uint
{
    /// <summary>
    ///     Not a special weapon.
    /// </summary>
    None = 0,

    /// <summary>
    ///     The same as barehand. Can use kicks.
    /// </summary>
    Barehand = 1,

    /// <summary>
    ///     A weapon usable with claw slash.
    /// </summary>
    Claw = 2,

    /// <summary>
    ///     A weapon usable with stabs
    /// </summary>
    Dagger = 4,

    /// <summary>
    ///     A weapon usable with arrow shot, special arrow attack, star arrow, etc
    /// </summary>
    Bow = 8 | TwoHanded,

    /// <summary>
    ///     A weapon that takes both hands.
    /// </summary>
    TwoHanded = 16
}

/// <summary>
///     Flags for status that would need to be tracked on the local user.
/// </summary>
[Flags]
public enum ClientStatus : ulong
{
    None = 0UL,
    Dall = 1UL,
    BeagSuain = 1UL << 1,
    Suain = 1UL << 2,
    Sleep = 1UL << 3,
    Halt = 1UL << 4,
    Pause = 1UL << 5,
    Coma = 1UL << 6,
    Poison = 1UL << 7,
    Purify = 1UL << 8,
    NaomhAite = 1UL << 9,
    FasNadur = 1UL << 10,
    Armachd = 1UL << 11,
    DeireasFaileas = 1UL << 12,
    AsgallFaileas = 1UL << 13,
    PerfectDefense = 1UL << 14,
    Dion = 1UL << 15,
    Hide = 1UL << 16,
    InnerFire = 1UL << 17,
    CatsHearing = 1UL << 18,
    MantidScent = 1UL << 19,
    BeagCradh = 1UL << 20,
    Cradh = 1UL << 21,
    MorCradh = 1UL << 22,
    ArdCradh = 1UL << 23,
    DarkSeal = 1UL << 24,
    DarkerSeal = 1UL << 25,
    Demise = 1UL << 26,
    Stuck = 1UL << 27,
    OutOfMana = 1UL << 28,
    OutOfLabor = 1UL << 29,
    ExchangeOpen = 1UL << 30,
    Skulled = 1UL << 31,
    Rescued = 1UL << 32
}