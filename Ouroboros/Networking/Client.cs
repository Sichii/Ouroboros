using System.Collections.Concurrent;
using System.Net;
using Chaos.Cryptography.Abstractions;
using Chaos.Geometry;
using Chaos.Geometry.Abstractions;
using Chaos.Geometry.Abstractions.Definitions;
using Chaos.Networking.Entities.Server;
using Chaos.Packets;
using Chaos.Packets.Abstractions;
using Ouroboros.Memory;
using Ouroboros.Model;
using Ouroboros.Services.Managers;
using Ouroboros.Utilities;

namespace Ouroboros.Networking;

public sealed class Client : IEquatable<Client>
{
    public string Guid { get; } = System.Guid.NewGuid().ToString();
    public DaWindow? DaWindow { get; set; }
    public event EventHandler? OnDisconnect;
    private readonly ConcurrentQueue<byte[]> ClientReceiveQueue;
    private readonly ConcurrentQueue<byte[]> ServerReceiveQueue;
    private readonly ConcurrentQueue<IPacketSerializable> ClientSendQueue;
    private readonly ConcurrentQueue<IPacketSerializable> ServerSendQueue;
    private readonly ProxyServer ProxyServer;
    private readonly ProxyClient ProxyClient;
    private readonly IPacketSerializer PacketSerializer;
    private readonly PacketHandler?[] ClientPacketHandlers;
    private readonly PacketHandler?[] ServerPacketHandlers;
    private readonly AsyncSignal Signal;
    private int NotifiedDisconnect;
    public ClientManager Manager { get; }
    public RedirectManager RedirectManager { get; }
    // ReSharper disable once NotAccessedField.Local
    private Task? ProcessLoopTask;
    public ClientActions ClientActions { get; }
    public ServerActions ServerActions { get; }
    public Aisling? Aisling { get; set; }
    public Direction ClientDirection { get; set; }
    public Point ClientPoint { get; set; }
    public Direction ServerDirection { get; set; }
    public Point ServerPoint { get; set; }

    public delegate HandlerResult PacketHandler(in Packet packet, out IPacketSerializable serialized);

    public Client(
        ProxyClient proxyClient,
        ProxyServer proxyServer,
        IPacketSerializer packetSerializer,
        RedirectManager redirectManager,
        ClientManager manager)
    {
        ProxyClient = proxyClient;
        ProxyServer = proxyServer;
        PacketSerializer = packetSerializer;
        RedirectManager = redirectManager;
        Manager = manager;
        ClientActions = new ClientActions(this);
        ServerActions = new ServerActions(this);
        ClientReceiveQueue = new ConcurrentQueue<byte[]>();
        ServerReceiveQueue = new ConcurrentQueue<byte[]>();
        ClientSendQueue = new ConcurrentQueue<IPacketSerializable>();
        ServerSendQueue = new ConcurrentQueue<IPacketSerializable>();
        ProxyClient.OnReceive += EnqueueClientReceive;
        ProxyServer.OnReceive += EnqueueServerReceive;
        ClientPacketHandlers = new ClientHandlers(this, packetSerializer).GetIndexedHandlers();
        ServerPacketHandlers = new ServerHandlers(this, packetSerializer).GetIndexedHandlers();
        Signal = new AsyncSignal();
        
        ProxyClient.LogRawPackets = true;
        ProxyServer.LogRawPackets = true;
        
        SetupDisconnectEvent();
    }

    private void SetupDisconnectEvent()
    {
        ProxyClient.OnDisconnected += (_, _) =>
        {
            ProxyServer.Disconnect();
            NotifyDisconnected();
        };
        ProxyServer.OnDisconnected += (_, _) =>
        {
            ProxyClient.Disconnect();
            NotifyDisconnected();
        };

        return;

        void NotifyDisconnected()
        {
            if(Interlocked.CompareExchange(ref NotifiedDisconnect, 1, 0) == 0)
                OnDisconnect?.Invoke(this, EventArgs.Empty);
        }
    }

    private async Task ProcessLoop()
    {
        while (ProxyClient.Connected)
        {
            await Signal.WaitAsync();
            
            ProcessPacketsFromClient();
            ProcessPacketsFromServer();
            ProcessPacketsToClient();
            ProcessPacketsToServer();
        }
    }
    
    public void SetServerSequence(byte sequence) => ProxyServer.Sequence = sequence;

    public void SetCrypto(ICrypto crypto)
    {
        ProxyClient.Crypto = crypto;
        ProxyServer.Crypto = crypto;
    }

    public void Connect(IPEndPoint? serverEndPoint = null)
    {
        if (serverEndPoint is null)
        {
            ProxyClient.BeginReceive();
            ProcessLoopTask = ProcessLoop();

            ClientActions.SendAcceptConnection(
                new AcceptConnectionArgs
                {
                    Message = "CONNECTED SERVER"
                });
        } else
        {
            //start receiving from the client
            ProxyServer.Connect(serverEndPoint);

            ProxyServer.BeginReceive();
        }
    }

    private void ProcessPacketsFromClient()
    {
        while (ClientReceiveQueue.TryDequeue(out var buffer))
        {
            var span = buffer.AsSpan();
            var opCode = span[3];
            var packet = new Packet(ref span, ProxyServer.IsEncrypted(opCode));
            
            var handler = ClientPacketHandlers[packet.OpCode];

            //if there's no handler, just act as a pass through for the packet
            if (handler is null)
            {
                ProxyServer.Send(ref packet);

                continue;
            }

            var ret = handler(packet, out var serialized);
                
            //if the handler wants to cancel the packet, continue
            if (ret.Cancel)
                continue;

            //if the packet is marked as a passthrough, send the original
            if (ret.UseOriginal)
            {
                ProxyServer.Send(ref packet);

                continue;
            }
            
            //re-serialize the converted type and send it
            ProxyServer.Send(serialized);
        }
    }
    
    private void ProcessPacketsFromServer()
    {
        while (ServerReceiveQueue.TryDequeue(out var buffer))
        {
            var span = buffer.AsSpan();
            var opCode = span[3];
            var packet = new Packet(ref span, ProxyClient.IsEncrypted(opCode));
            var handler = ServerPacketHandlers[packet.OpCode];
            
            //if there's no handler, just act as a pass through for the packet
            if (handler is null)
            {
                ProxyClient.Send(ref packet);

                continue;
            }

            var ret = handler(packet, out var serialized);
                
            //if the handler wants to cancel the packet, continue
            if (ret.Cancel)
                continue;

            //if the packet is marked as a passthrough, send the original
            if (ret.UseOriginal)
            {
                ProxyClient.Send(ref packet);

                continue;
            }
            
            //re-serialize the converted type and send it
            ProxyClient.Send(serialized);
        }
    }
    
    private void ProcessPacketsToClient()
    {
        while (ClientSendQueue.TryDequeue(out var data))
        {
            var packet = PacketSerializer.Serialize(data);
            ProxyClient.Send(ref packet);
        }
    }

    private void ProcessPacketsToServer()
    {
        while (ServerSendQueue.TryDequeue(out var data))
        {
            var packet = PacketSerializer.Serialize(data);
            ProxyServer.Send(ref packet);
        }
    }
    
    public void ClientEnqueue(IPacketSerializable data)
    {
        ClientSendQueue.Enqueue(data);
        Signal.Pulse();
    }

    public void ServerEnqueue(IPacketSerializable data)
    {
        ServerSendQueue.Enqueue(data);
        Signal.Pulse();
    }

    private void EnqueueClientReceive(byte[] buffer)
    {
        ClientReceiveQueue.Enqueue(buffer);
        Signal.Pulse();
    }

    private void EnqueueServerReceive(byte[] buffer)
    {
        ServerReceiveQueue.Enqueue(buffer);
        Signal.Pulse();
    }

    #region IEquatable
    /// <inheritdoc />
    public bool Equals(Client? other)
    {
        if (ReferenceEquals(null, other))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return Guid == other.Guid;
    }

    /// <inheritdoc />
    public override bool Equals(object? obj) => ReferenceEquals(this, obj) || obj is Client other && Equals(other);

    /// <inheritdoc />
    public override int GetHashCode() => Guid.GetHashCode();

    public static bool operator ==(Client? left, Client? right) => Equals(left, right);
    public static bool operator !=(Client? left, Client? right) => !Equals(left, right);
    #endregion
}