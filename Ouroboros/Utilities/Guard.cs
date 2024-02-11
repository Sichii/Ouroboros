using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Ouroboros.Utilities;

public static class Guard
{
    public static void Unreachable([DoesNotReturnIf(true)] bool condition, string message, Exception? inner = null)
    {
        if (condition)
            throw new UnreachableException(message, inner);
    }
}