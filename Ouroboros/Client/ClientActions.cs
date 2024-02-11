using Chaos.Networking.Entities.Server;

namespace Ouroboros.Client;

public sealed class ClientActions
{
    private readonly DarkAgesClient DarkAgesClient;

    public ClientActions(DarkAgesClient client) => DarkAgesClient = client;

    public void SendCancelCasting()
    {
        var args = new CancelCastingArgs();
        
        DarkAgesClient.ClientEnqueue(args);
    }

    public void SendMapChangeComplete()
    {
        var args = new MapChangePendingArgs();
        
        DarkAgesClient.ClientEnqueue(args);
    }

    public void SendMapChangePending()
    {
        var args = new MapChangePendingArgs();
        
        DarkAgesClient.ClientEnqueue(args);
    }

    public void SendMapLoadComplete()
    {
        var args = new MapLoadCompleteArgs();
        
        DarkAgesClient.ClientEnqueue(args);
    }

    public void SendEditableProfileRequest()
    {
        var args = new EditableProfileRequestArgs();
        
        DarkAgesClient.ClientEnqueue(args);
    }

    public void SendRefreshResponse()
    {
        var args = new RefreshResponseArgs();
        
        DarkAgesClient.ClientEnqueue(args);
    }

    public void SendAcceptConnection(AcceptConnectionArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendAddItemToPane(AddItemToPaneArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendAddSkillToPane(AddSkillToPaneArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendAddSpellToPane(AddSpellToPaneArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendAnimation(AnimationArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendAttributes(AttributesArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendDisplayBoard(DisplayBoardArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendBodyAnimation(BodyAnimationArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendClientWalkResponse(ClientWalkResponseArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendExitResponse(ExitResponseArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendConnectionInfo(ConnectionInfoArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendCooldown(CooldownArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendCreatureTurn(CreatureTurnArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendCreatureWalk(CreatureWalkArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendDisplayDialog(DisplayDialogArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendDisplayAisling(DisplayAislingArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendDisplayVisibleEntities(DisplayVisibleEntitiesArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendDoor(DoorArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendEffect(EffectArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendEquipment(EquipmentArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendForceClientPacket(ForceClientPacketArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendDisplayGroupInvite(DisplayGroupInviteArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendHealthBar(HealthBarArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendHeartBeatResponse(HeartBeatResponseArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendLightLevel(LightLevelArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendLocation(LocationArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendLoginControl(LoginControlArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendLoginMessage(LoginMessageArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendLoginNotice(LoginNoticeArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendMapData(MapDataArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendMapInfo(MapInfoArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendDisplayMenu(DisplayMenuArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendMetaData(MetaDataArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendNotepad(NotepadArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendOtherProfile(OtherProfileArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendDisplayPublicMessage(DisplayPublicMessageArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendRedirect(RedirectArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendRemoveEntity(RemoveEntityArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendRemoveItemFromPane(RemoveItemFromPaneArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendRemoveSkillFromPane(RemoveSkillFromPaneArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendRemoveSpellFromPane(RemoveSpellFromPaneArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendSelfProfile(SelfProfileArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendDisplayExchange(DisplayExchangeArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendServerMessage(ServerMessageArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendServerTableResponse(ServerTableResponseArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendSound(SoundArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendSynchronizeTicksResponse(SynchronizeTicksResponseArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendDisplayUnequip(DisplayUnequipArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendUserId(UserIdArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendWorldList(WorldListArgs args) => DarkAgesClient.ClientEnqueue(args);
    public void SendWorldMap(WorldMapArgs args) => DarkAgesClient.ClientEnqueue(args);
}