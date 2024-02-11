using System.Net.Sockets;
using Chaos.Common.Abstractions;
using Chaos.Packets.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Ouroboros.Abstractions;
using Ouroboros.Networking;
using Ouroboros.Services.Managers;
using Ouroboros.ViewModel;

namespace Ouroboros.Services.Factories;

public sealed class ClientFactory
{
    private readonly IServiceProvider Provider;
    private readonly IFactory<ProxyClient> ProxyClientFactory;
    private readonly IFactory<ProxyServer> ProxyServerFactory;

    public ClientFactory(IServiceProvider provider)
    {
        Provider = provider;
        ProxyClientFactory = provider.GetRequiredService<IFactory<ProxyClient>>();
        ProxyServerFactory = provider.GetRequiredService<IFactory<ProxyServer>>();
    }
    
    public Client.DarkAgesClient Create(Socket proxySocket)
    {
        var proxyServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        proxyServerSocket.NoDelay = true;
        
        var proxyClient = ProxyClientFactory.Create(proxySocket);
        var proxyServer = ProxyServerFactory.Create(proxyServerSocket);

        return ActivatorUtilities.CreateInstance<Client.DarkAgesClient>(Provider, proxyClient, proxyServer);
    }
}