using System.Runtime.InteropServices;

namespace Ouroboros.PInvoke;

[StructLayout(LayoutKind.Sequential)]
public struct Rect
{
    #region Do Not ReOrder

    public int Left, Top, Right, Bottom;

    #endregion
}