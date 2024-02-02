using Chaos.Cryptography;
using Chaos.Networking.Entities.Server;
using Chaos.Packets;
using Chaos.Packets.Abstractions;
using Chaos.Packets.Abstractions.Definitions;
using Ouroboros.Defintions;
using Ouroboros.Utilities;

namespace Ouroboros.Networking;

public sealed class ServerHandlers
{
    private readonly Client Client;
    private readonly IPacketSerializer PacketSerializer;

    public ServerHandlers(Client client, IPacketSerializer packetSerializer)
    {
        Client = client;
        PacketSerializer = packetSerializer;
    }

    public Client.PacketHandler?[] GetIndexedHandlers()
    {
        var handlers = new Client.PacketHandler?[byte.MaxValue];

        handlers[(byte)ServerOpCode.ConnectionInfo] = OnConnectionInfo;
        handlers[(byte)ServerOpCode.LoginMessage] = OnLoginMessage;
        handlers[(byte)ServerOpCode.Redirect] = OnRedirect;
        handlers[(byte)ServerOpCode.Location] = OnLocation;
        handlers[(byte)ServerOpCode.UserId] = OnUserId;
        handlers[(byte)ServerOpCode.DisplayVisibleEntities] = OnDisplayVisibleEntities;
        handlers[(byte)ServerOpCode.Attributes] = OnAttributes;
        handlers[(byte)ServerOpCode.ServerMessage] = OnServerMessage;
        handlers[(byte)ServerOpCode.ClientWalkResponse] = OnClientWalkResponse;
        handlers[(byte)ServerOpCode.CreatureWalk] = OnCreatureWalk;
        handlers[(byte)ServerOpCode.DisplayPublicMessage] = OnDisplayPublicMessage;
        handlers[(byte)ServerOpCode.RemoveEntity] = OnRemoveEntity;
        handlers[(byte)ServerOpCode.AddItemToPane] = OnAddItemToPane;
        handlers[(byte)ServerOpCode.RemoveItemFromPane] = OnRemoveItemFromPane;
        handlers[(byte)ServerOpCode.CreatureTurn] = OnCreatureTurn;
        handlers[(byte)ServerOpCode.HealthBar] = OnHealthBar;
        handlers[(byte)ServerOpCode.MapInfo] = OnMapInfo;
        handlers[(byte)ServerOpCode.AddSpellToPane] = OnAddSpellToPane;
        handlers[(byte)ServerOpCode.RemoveSpellFromPane] = OnRemoveSpellFromPane;
        handlers[(byte)ServerOpCode.Sound] = OnSound;
        handlers[(byte)ServerOpCode.BodyAnimation] = OnBodyAnimation;
        handlers[(byte)ServerOpCode.Notepad] = OnNotepad;
        handlers[(byte)ServerOpCode.MapChangeComplete] = OnMapChangeComplete;
        handlers[(byte)ServerOpCode.LightLevel] = OnLightLevel;
        handlers[(byte)ServerOpCode.RefreshResponse] = OnRefreshResponse;
        handlers[(byte)ServerOpCode.Animation] = OnAnimation;
        handlers[(byte)ServerOpCode.AddSkillToPane] = OnAddSkillToPane;
        handlers[(byte)ServerOpCode.RemoveSkillFromPane] = OnRemoveSkillFromPane;
        handlers[(byte)ServerOpCode.WorldMap] = OnWorldMap;
        handlers[(byte)ServerOpCode.DisplayMenu] = OnDisplayMenu;
        handlers[(byte)ServerOpCode.DisplayDialog] = OnDisplayDialog;
        handlers[(byte)ServerOpCode.DisplayBoard] = OnDisplayBoard;
        handlers[(byte)ServerOpCode.Door] = OnDoor;
        handlers[(byte)ServerOpCode.DisplayAisling] = OnDisplayAisling;
        handlers[(byte)ServerOpCode.OtherProfile] = OnOtherProfile;
        handlers[(byte)ServerOpCode.WorldList] = OnWorldList;
        handlers[(byte)ServerOpCode.Equipment] = OnEquipment;
        handlers[(byte)ServerOpCode.DisplayUnequip] = OnDisplayUnequip;
        handlers[(byte)ServerOpCode.SelfProfile] = OnSelfProfile;
        handlers[(byte)ServerOpCode.Effect] = OnEffect;
        handlers[(byte)ServerOpCode.HeartBeatResponse] = OnHeartBeatResponse;
        handlers[(byte)ServerOpCode.MapData] = OnMapData;
        handlers[(byte)ServerOpCode.Cooldown] = OnCooldown;
        handlers[(byte)ServerOpCode.DisplayExchange] = OnDisplayExchange;
        handlers[(byte)ServerOpCode.CancelCasting] = OnCancelCasting;
        handlers[(byte)ServerOpCode.EditableProfileRequest] = OnEditableProfileRequest;
        handlers[(byte)ServerOpCode.ForceClientPacket] = OnForceClientPacket;
        handlers[(byte)ServerOpCode.ExitResponse] = OnExitResponse;
        handlers[(byte)ServerOpCode.ServerTableResponse] = OnServerTableResponse;
        handlers[(byte)ServerOpCode.MapLoadComplete] = OnMapLoadComplete;
        handlers[(byte)ServerOpCode.LoginNotice] = OnLoginNotice;
        handlers[(byte)ServerOpCode.DisplayGroupInvite] = OnDisplayGroupInvite;
        handlers[(byte)ServerOpCode.LoginControl] = OnLoginControl;
        handlers[(byte)ServerOpCode.MapChangePending] = OnMapChangePending;
        handlers[(byte)ServerOpCode.SynchronizeTicksResponse] = OnSynchronizeTicksResponse;
        handlers[(byte)ServerOpCode.MetaData] = OnMetaData;
        handlers[(byte)ServerOpCode.AcceptConnection] = OnAcceptConnection;


        return handlers;
    }

    private HandlerResult OnAcceptConnection(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<AcceptConnectionArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnMetaData(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<MetaDataArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnSynchronizeTicksResponse(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<SynchronizeTicksResponseArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnMapChangePending(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<MapChangePendingArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnLoginControl(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<LoginControlArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnDisplayGroupInvite(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<DisplayGroupInviteArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnLoginNotice(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<LoginNoticeArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnMapLoadComplete(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<MapLoadCompleteArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnServerTableResponse(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<ServerTableResponseArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnExitResponse(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<ExitResponseArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnForceClientPacket(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<ForceClientPacketArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnOtherProfile(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<OtherProfileArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnCancelCasting(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<CancelCastingArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnDisplayExchange(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<DisplayExchangeArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnCooldown(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<CooldownArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnMapData(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<MapDataArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnHeartBeatResponse(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<HeartBeatResponseArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnEffect(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<EffectArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnSelfProfile(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<SelfProfileArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnDisplayUnequip(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<DisplayUnequipArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnEquipment(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<EquipmentArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnWorldList(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<WorldListArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnEditableProfileRequest(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<EditableProfileRequestArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnDisplayAisling(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<DisplayAislingArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnDoor(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<DoorArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnDisplayBoard(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<DisplayBoardArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnDisplayDialog(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<DisplayDialogArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnDisplayMenu(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<DisplayMenuArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnWorldMap(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<WorldMapArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnRemoveSkillFromPane(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<RemoveSkillFromPaneArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnAddSkillToPane(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<AddSkillToPaneArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnAnimation(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<AnimationArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnRefreshResponse(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<RefreshResponseArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnLightLevel(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<LightLevelArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnMapChangeComplete(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<MapChangeCompleteArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnNotepad(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<NotepadArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnBodyAnimation(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<BodyAnimationArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnSound(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<SoundArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnRemoveSpellFromPane(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<RemoveSpellFromPaneArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnAddSpellToPane(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<AddSpellToPaneArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnMapInfo(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<MapInfoArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnHealthBar(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<HealthBarArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnCreatureTurn(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<CreatureTurnArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnRemoveItemFromPane(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<RemoveItemFromPaneArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnAddItemToPane(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<AddItemToPaneArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnRemoveEntity(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<RemoveEntityArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnDisplayPublicMessage(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<DisplayPublicMessageArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnCreatureWalk(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<CreatureWalkArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnClientWalkResponse(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<ClientWalkResponseArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnServerMessage(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<ServerMessageArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnAttributes(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<AttributesArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnDisplayVisibleEntities(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<DisplayVisibleEntitiesArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnUserId(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<UserIdArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnLocation(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<LocationArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnRedirect(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<RedirectArgs>(packet);
        serialized = args;

        //store the port before we overwrite it
        Client.RedirectManager.AddRedirect(args.Id, args.EndPoint);
        args.EndPoint = CONSTANTS.LOOPBACK_LOBBY_ENDPOINT;
        
        return HandlerResult.Edited;
    }

    private HandlerResult OnLoginMessage(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<LoginMessageArgs>(packet);
        serialized = args;

        return HandlerResult.Default;
    }

    private HandlerResult OnConnectionInfo(in Packet packet, out IPacketSerializable serialized)
    {
        var args = PacketSerializer.Deserialize<ConnectionInfoArgs>(packet);
        serialized = args;

        var crypto = new Crypto(args.Seed, args.Key);
        Client.SetCrypto(crypto);

        return HandlerResult.Default;
    }
}