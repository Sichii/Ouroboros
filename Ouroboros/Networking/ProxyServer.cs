using System.Net;
using System.Net.Sockets;
using Chaos.Cryptography.Abstractions;
using Chaos.Networking.Abstractions;
using Chaos.Packets;
using Chaos.Packets.Abstractions;
using Microsoft.Extensions.Logging;

namespace Ouroboros.Networking;

public class ProxyServer : SocketClientBase
{
    public event Action<byte[]>? OnReceive;
    public byte Sequence { get; set; }
    
    /// <inheritdoc />
    public ProxyServer(
        Socket socket,
        ICrypto crypto,
        IPacketSerializer packetSerializer,
        ILogger<ProxyServer> logger)
        : base(
            socket,
            crypto,
            packetSerializer,
            logger) { }

    public void Connect(IPEndPoint endPoint) => Socket.Connect(endPoint);

    /// <inheritdoc />
    protected override ValueTask HandlePacketAsync(Span<byte> buffer)
    {
        var opCode = buffer[3];
        var packet = new Packet(ref buffer, Crypto.IsServerEncrypted(opCode));

        if (packet.IsEncrypted)
            Crypto.ClientDecrypt(ref packet.Buffer, packet.OpCode, packet.Sequence);

        var decryptedBuffer = packet.ToArray();

        OnReceive?.Invoke(decryptedBuffer);

        return default;
    }
    
    /// <inheritdoc />
    public override bool IsEncrypted(byte opCode) => Crypto.IsClientEncrypted(opCode);

    /// <inheritdoc />
    public override void Encrypt(ref Packet packet) => Crypto.ClientEncrypt(ref packet.Buffer, packet.OpCode, packet.Sequence);
}