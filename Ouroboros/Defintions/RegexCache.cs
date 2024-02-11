using System.Text.RegularExpressions;

namespace Ouroboros.Defintions;

public static partial class RegexCache
{
    public static readonly Regex IDLOCATION_REGEX = CreateIdLocationRegex();
    
    [GeneratedRegex(@"(\d+)(?::| )\(?(\d+)(?:,| |, )(\d+)\)?", RegexOptions.Compiled)]
    private static partial Regex CreateIdLocationRegex();
}