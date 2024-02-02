using System.Net.Sockets;
using Chaos.Cryptography.Abstractions;
using Chaos.Networking.Abstractions;
using Chaos.Packets;
using Chaos.Packets.Abstractions;
using Microsoft.Extensions.Logging;

namespace Ouroboros.Networking;

public class ProxyClient : SocketClientBase
{
    public event Action<byte[]>? OnReceive;
    public byte Sequence { get; set; }

    /// <inheritdoc />
    public ProxyClient(
        Socket socket,
        ICrypto crypto,
        IPacketSerializer packetSerializer,
        ILogger<ProxyClient> logger)
        : base(
            socket,
            crypto,
            packetSerializer,
            logger) { }

    /// <inheritdoc />
    protected override ValueTask HandlePacketAsync(Span<byte> buffer)
    {
        var opCode = buffer[3];
        var packet = new Packet(ref buffer, Crypto.IsClientEncrypted(opCode));

        if (packet.IsEncrypted)
            Crypto.ServerDecrypt(ref packet.Buffer, packet.OpCode, packet.Sequence);

        var decryptedBuffer = packet.ToArray();
        OnReceive?.Invoke(decryptedBuffer);

        return default;
    }

    /// <inheritdoc />
    public override bool IsEncrypted(byte opCode) => Crypto.IsServerEncrypted(opCode);

    /// <inheritdoc />
    public override void Encrypt(ref Packet packet) => Crypto.ServerEncrypt(ref packet.Buffer, packet.OpCode, packet.Sequence);
}