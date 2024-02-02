using Chaos.Networking.Entities.Server;

namespace Ouroboros.Networking;

public sealed class ClientActions
{
    private readonly Client Client;

    public ClientActions(Client client) => Client = client;

    public void SendCancelCasting()
    {
        var args = new CancelCastingArgs();
        
        Client.ClientEnqueue(args);
    }

    public void SendMapChangeComplete()
    {
        var args = new MapChangePendingArgs();
        
        Client.ClientEnqueue(args);
    }

    public void SendMapChangePending()
    {
        var args = new MapChangePendingArgs();
        
        Client.ClientEnqueue(args);
    }

    public void SendMapLoadComplete()
    {
        var args = new MapLoadCompleteArgs();
        
        Client.ClientEnqueue(args);
    }

    public void SendEditableProfileRequest()
    {
        var args = new EditableProfileRequestArgs();
        
        Client.ClientEnqueue(args);
    }

    public void SendRefreshResponse()
    {
        var args = new RefreshResponseArgs();
        
        Client.ClientEnqueue(args);
    }

    public void SendAcceptConnection(AcceptConnectionArgs args) => Client.ClientEnqueue(args);
    public void SendAddItemToPane(AddItemToPaneArgs args) => Client.ClientEnqueue(args);
    public void SendAddSkillToPane(AddSkillToPaneArgs args) => Client.ClientEnqueue(args);
    public void SendAddSpellToPane(AddSpellToPaneArgs args) => Client.ClientEnqueue(args);
    public void SendAnimation(AnimationArgs args) => Client.ClientEnqueue(args);
    public void SendAttributes(AttributesArgs args) => Client.ClientEnqueue(args);
    public void SendDisplayBoard(DisplayBoardArgs args) => Client.ClientEnqueue(args);
    public void SendBodyAnimation(BodyAnimationArgs args) => Client.ClientEnqueue(args);
    public void SendClientWalkResponse(ClientWalkResponseArgs args) => Client.ClientEnqueue(args);
    public void SendExitResponse(ExitResponseArgs args) => Client.ClientEnqueue(args);
    public void SendConnectionInfo(ConnectionInfoArgs args) => Client.ClientEnqueue(args);
    public void SendCooldown(CooldownArgs args) => Client.ClientEnqueue(args);
    public void SendCreatureTurn(CreatureTurnArgs args) => Client.ClientEnqueue(args);
    public void SendCreatureWalk(CreatureWalkArgs args) => Client.ClientEnqueue(args);
    public void SendDisplayDialog(DisplayDialogArgs args) => Client.ClientEnqueue(args);
    public void SendDisplayAisling(DisplayAislingArgs args) => Client.ClientEnqueue(args);
    public void SendDisplayVisibleEntities(DisplayVisibleEntitiesArgs args) => Client.ClientEnqueue(args);
    public void SendDoor(DoorArgs args) => Client.ClientEnqueue(args);
    public void SendEffect(EffectArgs args) => Client.ClientEnqueue(args);
    public void SendEquipment(EquipmentArgs args) => Client.ClientEnqueue(args);
    public void SendForceClientPacket(ForceClientPacketArgs args) => Client.ClientEnqueue(args);
    public void SendDisplayGroupInvite(DisplayGroupInviteArgs args) => Client.ClientEnqueue(args);
    public void SendHealthBar(HealthBarArgs args) => Client.ClientEnqueue(args);
    public void SendHeartBeatResponse(HeartBeatResponseArgs args) => Client.ClientEnqueue(args);
    public void SendLightLevel(LightLevelArgs args) => Client.ClientEnqueue(args);
    public void SendLocation(LocationArgs args) => Client.ClientEnqueue(args);
    public void SendLoginControl(LoginControlArgs args) => Client.ClientEnqueue(args);
    public void SendLoginMessage(LoginMessageArgs args) => Client.ClientEnqueue(args);
    public void SendLoginNotice(LoginNoticeArgs args) => Client.ClientEnqueue(args);
    public void SendMapData(MapDataArgs args) => Client.ClientEnqueue(args);
    public void SendMapInfo(MapInfoArgs args) => Client.ClientEnqueue(args);
    public void SendDisplayMenu(DisplayMenuArgs args) => Client.ClientEnqueue(args);
    public void SendMetaData(MetaDataArgs args) => Client.ClientEnqueue(args);
    public void SendNotepad(NotepadArgs args) => Client.ClientEnqueue(args);
    public void SendOtherProfile(OtherProfileArgs args) => Client.ClientEnqueue(args);
    public void SendDisplayPublicMessage(DisplayPublicMessageArgs args) => Client.ClientEnqueue(args);
    public void SendRedirect(RedirectArgs args) => Client.ClientEnqueue(args);
    public void SendRemoveEntity(RemoveEntityArgs args) => Client.ClientEnqueue(args);
    public void SendRemoveItemFromPane(RemoveItemFromPaneArgs args) => Client.ClientEnqueue(args);
    public void SendRemoveSkillFromPane(RemoveSkillFromPaneArgs args) => Client.ClientEnqueue(args);
    public void SendRemoveSpellFromPane(RemoveSpellFromPaneArgs args) => Client.ClientEnqueue(args);
    public void SendSelfProfile(SelfProfileArgs args) => Client.ClientEnqueue(args);
    public void SendDisplayExchange(DisplayExchangeArgs args) => Client.ClientEnqueue(args);
    public void SendServerMessage(ServerMessageArgs args) => Client.ClientEnqueue(args);
    public void SendServerTableResponse(ServerTableResponseArgs args) => Client.ClientEnqueue(args);
    public void SendSound(SoundArgs args) => Client.ClientEnqueue(args);
    public void SendSynchronizeTicksResponse(SynchronizeTicksResponseArgs args) => Client.ClientEnqueue(args);
    public void SendDisplayUnequip(DisplayUnequipArgs args) => Client.ClientEnqueue(args);
    public void SendUserId(UserIdArgs args) => Client.ClientEnqueue(args);
    public void SendWorldList(WorldListArgs args) => Client.ClientEnqueue(args);
    public void SendWorldMap(WorldMapArgs args) => Client.ClientEnqueue(args);
}