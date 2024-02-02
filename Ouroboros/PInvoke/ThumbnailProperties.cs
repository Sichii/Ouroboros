using System.Runtime.InteropServices;
using Ouroboros.Defintions;

namespace Ouroboros.PInvoke;

[StructLayout(LayoutKind.Sequential)]
public struct ThumbnailProperties
{
    #region Do Not ReOrder

    public ThumbnailFlags Flags;
    public Rect DestinationRect;
    public Rect SourceRect;
    public byte Opacity;
    public bool Visible;
    public bool OnlyClientRect;

    #endregion
}