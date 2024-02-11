using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using Chaos.Extensions.Common;
using Microsoft.Extensions.Hosting;
using Ouroboros.Defintions;
using Ouroboros.Memory;
using Ouroboros.Networking;
using Ouroboros.Services.Factories;

namespace Ouroboros.Services.Managers;

public sealed class ClientManager : BackgroundService
{
    private readonly Socket LobbyListener;
    private readonly ClientFactory ClientFactory;
    private readonly ConcurrentDictionary<string, Client.DarkAgesClient> Clients;
    private readonly ConcurrentDictionary<int, DaWindow> Windows;

    public ClientManager(ClientFactory clientFactory)
    {
        ClientFactory = clientFactory;
        LobbyListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Clients = new ConcurrentDictionary<string, Client.DarkAgesClient>();
        Windows = new ConcurrentDictionary<int, DaWindow>();
    }
    
    public void AddClient(Client.DarkAgesClient client)
    {
        Clients.TryAdd(client.Guid, client);

        //when the client disconnects, remove it from the client collection
        client.OnDisconnect += (_, _) => RemoveClient(client);
    }
    
    public void RemoveClient(Client.DarkAgesClient client) => Clients.TryRemove(client.Guid, out _);

    public void AddWindow(DaWindow daWindow)
    {
        Windows.TryAdd(daWindow.Process.Id, daWindow);
        
        //when the window closes, remove it from the window collection
        daWindow.Process.Exited += (_, _) => RemoveWindow(daWindow);
    }

    public void SynchronizeClient(string clientGuid, string daWindowCharacterName)
    {
        if (!Clients.TryGetValue(clientGuid, out var client))
            throw new InvalidOperationException("Unable to find client.");
        
        var daWindow = Windows.Values.FirstOrDefault(d => d.ReadName().EqualsI(daWindowCharacterName));
        
        if (daWindow == null)
            throw new InvalidOperationException($"Unable to find dark ages window with the name {daWindowCharacterName}");

        client.DaWindow = daWindow;
    }

    public void RemoveWindow(DaWindow daWindow) => Windows.TryRemove(daWindow.Process.Id, out _);

    /// <inheritdoc />
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        LobbyListener.Bind(CONSTANTS.LOOPBACK_LOBBY_ENDPOINT);
        LobbyListener.Listen(10);
        LobbyListener.BeginAccept(OnConnection, LobbyListener);
        
        await stoppingToken.WaitTillCanceled();
    }

    private void OnConnection(IAsyncResult ar)
    {
        var socket = (Socket)ar.AsyncState!;
        
        try
        {
            var clientSocket = socket.EndAccept(ar);
            
            clientSocket.NoDelay = true;
            
            var client = ClientFactory.Create(clientSocket);
            client.Connect();
        } catch
        {
            //ignored
        }

        socket.BeginAccept(OnConnection, socket);
    }
}