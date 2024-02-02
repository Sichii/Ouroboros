using System.Net.Sockets;
using Chaos.Common.Abstractions;
using Chaos.Packets.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Ouroboros.Networking;
using Ouroboros.Services.Managers;

namespace Ouroboros.Services.Factories;

public sealed class ClientFactory
{
    private readonly IServiceProvider Provider;
    private readonly IFactory<ProxyClient> ProxyClientFactory;
    private readonly IFactory<ProxyServer> ProxyServerFactory;
    private readonly IPacketSerializer PacketSerializer;
    private readonly RedirectManager RedirectManager;

    public ClientFactory(IServiceProvider provider)
    {
        Provider = provider;
        ProxyClientFactory = provider.GetRequiredService<IFactory<ProxyClient>>();
        ProxyServerFactory = provider.GetRequiredService<IFactory<ProxyServer>>();
        PacketSerializer = provider.GetRequiredService<IPacketSerializer>();
        RedirectManager = provider.GetRequiredService<RedirectManager>();
    }
    
    public Client Create(Socket proxySocket)
    {
        var proxyServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        proxyServerSocket.NoDelay = true;
        
        var proxyClient = ProxyClientFactory.Create(proxySocket);
        var proxyServer = ProxyServerFactory.Create(proxyServerSocket);
        var manager = Provider.GetRequiredService<ClientManager>();

        return new Client(
            proxyClient,
            proxyServer,
            PacketSerializer,
            RedirectManager,
            manager);
    }
}