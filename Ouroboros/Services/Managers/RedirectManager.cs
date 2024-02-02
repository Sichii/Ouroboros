using System.Collections.Concurrent;
using System.Net;

namespace Ouroboros.Services.Managers;

public sealed class RedirectManager
{
    private readonly ConcurrentDictionary<uint, IPEndPoint> Redirects = new();
    
    public IPEndPoint? GetRedirect(uint id) => Redirects.TryRemove(id, out var port) ? port : null;

    public void AddRedirect(uint id, IPEndPoint endPoint) => Redirects.TryAdd(id, endPoint);
}