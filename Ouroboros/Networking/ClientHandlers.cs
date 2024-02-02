using Chaos.Cryptography;
using Chaos.Extensions.Common;
using Chaos.Networking.Entities.Client;
using Chaos.Packets;
using Chaos.Packets.Abstractions;
using Chaos.Packets.Abstractions.Definitions;
using Ouroboros.Defintions;
using Ouroboros.Utilities;

namespace Ouroboros.Networking;

public sealed class ClientHandlers
{
    private readonly Client Client;
    private readonly IPacketSerializer PacketSerializer;

    public ClientHandlers(Client client, IPacketSerializer packetSerializer)
    {
        Client = client;
        PacketSerializer = packetSerializer;
    }

    public Client.PacketHandler?[] GetIndexedHandlers()
    {
        var handlers = new Client.PacketHandler?[byte.MaxValue];
        
        handlers[(byte)ClientOpCode.Version] = OnVersion;
        handlers[(byte)ClientOpCode.CreateCharInitial] = OnCreateCharInitial;
        handlers[(byte)ClientOpCode.Login] = OnLogin;
        handlers[(byte)ClientOpCode.CreateCharFinalize] = OnCreateCharFinalize;
        handlers[(byte)ClientOpCode.MapDataRequest] = OnMapDataRequest;
        handlers[(byte)ClientOpCode.ClientWalk] = OnClientWalk;
        handlers[(byte)ClientOpCode.Pickup] = OnPickup;
        handlers[(byte)ClientOpCode.ItemDrop] = OnItemDrop;
        handlers[(byte)ClientOpCode.ExitRequest] = OnExitRequest;
        handlers[(byte)ClientOpCode.DisplayEntityRequest] = OnDisplayEntityRequest;
        handlers[(byte)ClientOpCode.Ignore] = OnIgnore;
        handlers[(byte)ClientOpCode.PublicMessage] = OnPublicMessage;
        handlers[(byte)ClientOpCode.SpellUse] = OnSpellUse;
        handlers[(byte)ClientOpCode.ClientRedirected] = OnClientRedirected;
        handlers[(byte)ClientOpCode.Turn] = OnTurn;
        handlers[(byte)ClientOpCode.Spacebar] = OnSpacebar;
        handlers[(byte)ClientOpCode.WorldListRequest] = OnWorldListRequest;
        handlers[(byte)ClientOpCode.Whisper] = OnWhisper;
        handlers[(byte)ClientOpCode.OptionToggle] = OnOptionToggle;
        handlers[(byte)ClientOpCode.ItemUse] = OnItemUse;
        handlers[(byte)ClientOpCode.Emote] = OnEmote;
        handlers[(byte)ClientOpCode.SetNotepad] = OnSetNotepad;
        handlers[(byte)ClientOpCode.GoldDrop] = OnGoldDrop;
        handlers[(byte)ClientOpCode.PasswordChange] = OnPasswordChange;
        handlers[(byte)ClientOpCode.ItemDroppedOnCreature] = OnItemDroppedOnCreature;
        handlers[(byte)ClientOpCode.GoldDroppedOnCreature] = OnGoldDroppedOnCreature;
        handlers[(byte)ClientOpCode.SelfProfileRequest] = OnSelfProfileRequest;
        handlers[(byte)ClientOpCode.GroupInvite] = OnGroupInvite;
        handlers[(byte)ClientOpCode.ToggleGroup] = OnToggleGroup;
        handlers[(byte)ClientOpCode.SwapSlot] = OnSwapSlot;
        handlers[(byte)ClientOpCode.RefreshRequest] = OnRefreshRequest;
        handlers[(byte)ClientOpCode.MenuInteraction] = OnMenuInteraction;
        handlers[(byte)ClientOpCode.DialogInteraction] = OnDialogInteraction;
        handlers[(byte)ClientOpCode.BoardInteraction] = OnBoardInteraction;
        handlers[(byte)ClientOpCode.SkillUse] = OnSkillUse;
        handlers[(byte)ClientOpCode.WorldMapClick] = OnWorldMapClick;
        handlers[(byte)ClientOpCode.ClientException] = OnClientException;
        handlers[(byte)ClientOpCode.Click] = OnClick;
        handlers[(byte)ClientOpCode.Unequip] = OnUnequip;
        handlers[(byte)ClientOpCode.HeartBeat] = OnHeartBeat;
        handlers[(byte)ClientOpCode.RaiseStat] = OnRaiseStat;
        handlers[(byte)ClientOpCode.ExchangeInteraction] = OnExchangeInteraction;
        handlers[(byte)ClientOpCode.NoticeRequest] = OnNoticeRequest;
        handlers[(byte)ClientOpCode.BeginChant] = OnBeginChant;
        handlers[(byte)ClientOpCode.Chant] = OnChant;
        handlers[(byte)ClientOpCode.EditableProfile] = OnEditableProfile;
        handlers[(byte)ClientOpCode.ServerTableRequest] = OnServerTableRequest;
        handlers[(byte)ClientOpCode.SequenceChange] = OnSequenceChange;
        handlers[(byte)ClientOpCode.HomepageRequest] = OnHomepageRequest;
        handlers[(byte)ClientOpCode.SynchronizeTicks] = OnSynchronizeTicks;
        handlers[(byte)ClientOpCode.SocialStatus] = OnSocialStatus;
        handlers[(byte)ClientOpCode.MetaDataRequest] = OnMetaDataRequest;

        return handlers;
    }

    private HandlerResult OnSetNotepad(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<SetNotepadArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnClientException(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<ClientExceptionArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnHeartBeat(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<HeartBeatArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnSequenceChange(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<SequenceChangeArgs>(packet);
        serialized = args;

        Client.SetServerSequence(packet.Sequence);
        
        //this is the first thing the client tries to send to the server. When it does, make a connection to the server. 
        Client.Connect(CONSTANTS.DARKAGES_ENDPOINT);

        return HandlerResult.Default;
    }

    private HandlerResult OnSynchronizeTicks(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<SynchronizeTicksArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnBeginChant(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<BeginChantArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnBoardInteraction(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<BoardInteractionArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnChant(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<ChantArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnClick(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<ClickArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnClientRedirected(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<ClientRedirectedArgs>(packet);
        serialized = args;

        var redirect = Client.RedirectManager.GetRedirect(args.Id);

        if (redirect is null)
            throw new InvalidOperationException($"Unable to find redirect with id {args.Id}");
        
        var crypto = new Crypto(args.Seed, args.Key, args.Name);
        Client.SetCrypto(crypto);

        //this is the first thing the client tries to send to the server. When it does, make a connection to the server.
        Client.Connect(redirect);

        //if an actual name is provided here, it means we're logging into the world
        //synchronize this client with the da window that has the same name
        if (!args.Name.ContainsI("["))
            Client.Manager.SynchronizeClient(Client.Guid, args.Name);
        
        return HandlerResult.Default;
    }

    private HandlerResult OnClientWalk(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<ClientWalkArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnDialogInteraction(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<DialogInteractionArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnDisplayEntityRequest(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<DisplayEntityRequestArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnEmote(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<EmoteArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnExchangeInteraction(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<ExchangeInteractionArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnExitRequest(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<ExitRequestArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnGoldDrop(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<GoldDropArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnGoldDroppedOnCreature(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<GoldDroppedOnCreatureArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnGroupInvite(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<GroupInviteArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnIgnore(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<IgnoreArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnItemDrop(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<ItemDropArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnItemDroppedOnCreature(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<ItemDroppedOnCreatureArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnMapDataRequest(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<MapDataRequestArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnMetaDataRequest(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<MetaDataRequestArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnPickup(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<PickupArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnEditableProfile(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<EditableProfileArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnSelfProfileRequest(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<SelfProfileRequestArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnPublicMessage(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<PublicMessageArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnMenuInteraction(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<MenuInteractionArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnRaiseStat(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<RaiseStatArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnRefreshRequest(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<RefreshRequestArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnSocialStatus(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<SocialStatusArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnSpacebar(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<SpacebarArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnSwapSlot(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<SwapSlotArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnToggleGroup(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<ToggleGroupArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnTurn(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<TurnArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnUnequip(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<UnequipArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnItemUse(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<ItemUseArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnOptionToggle(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<OptionToggleArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnSkillUse(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<SkillUseArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnSpellUse(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<SpellUseArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnWhisper(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<WhisperArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnWorldListRequest(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<WorldListRequestArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnWorldMapClick(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<WorldMapClickArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnCreateCharFinalize(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<CreateCharFinalizeArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnCreateCharInitial(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<CreateCharInitialArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnHomepageRequest(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<HomepageRequestArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnLogin(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<LoginArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnNoticeRequest(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<NoticeRequestArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnPasswordChange(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<PasswordChangeArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnServerTableRequest(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<ServerTableRequestArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnVersion(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<VersionArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }
}