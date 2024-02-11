using Chaos.Networking.Entities.Client;

namespace Ouroboros.Client;

public sealed class ServerActions
{
    private readonly DarkAgesClient DarkAgesClient;
    public ServerActions(DarkAgesClient client) => DarkAgesClient = client;

    public void SendSequenceChange(byte sequence)
    {
        var args = new SequenceChangeArgs();
        
        DarkAgesClient.ServerEnqueue(args);
    }

    public void SendHomepageRequest()
    {
        var args = new HomepageRequestArgs();
        
        DarkAgesClient.ServerEnqueue(args);
    }

    public void SendNoticeRequest()
    {
        var args = new NoticeRequestArgs();
        
        DarkAgesClient.ServerEnqueue(args);
    }

    public void SendMapDataRequest()
    {
        var args = new MapDataRequestArgs();
        
        DarkAgesClient.ServerEnqueue(args);
    }

    public void SendSelfProfileRequest()
    {
        var args = new SelfProfileRequestArgs();
        
        DarkAgesClient.ServerEnqueue(args);
    }

    public void SendRefreshRequest()
    {
        var args = new RefreshRequestArgs();
        
        DarkAgesClient.ServerEnqueue(args);
    }

    public void SendSpacebar()
    {
        var args = new SpacebarArgs();

        DarkAgesClient.ServerEnqueue(args);
    }
    
    public void SendToggleGroup()
    {
        var args = new ToggleGroupArgs();
        
        DarkAgesClient.ServerEnqueue(args);
    }
    
    public void SendWorldListRequest()
    {
        var args = new WorldListRequestArgs();
        
        DarkAgesClient.ServerEnqueue(args);
    }
    
    public void SendBeginChant(BeginChantArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendBoardInteraction(BoardInteractionArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendClick(ClickArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendClientException(ClientExceptionArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendExchangeInteraction(ExchangeInteractionArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendClientWalk(ClientWalkArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendCreateCharFinalize(CreateCharFinalizeArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendCreateCharInitial(CreateCharInitialArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendDialogInteraction(DialogInteractionArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendChant(ChantArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendDisplayEntityRequest(DisplayEntityRequestArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendEmote(EmoteArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendExitRequest(ExitRequestArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendGoldDrop(GoldDropArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendGoldDroppedOnCreature(GoldDroppedOnCreatureArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendGroupInvite(GroupInviteArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendHeartBeat(HeartBeatArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendIgnore(IgnoreArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendItemDrop(ItemDropArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendItemDroppedOnCreature(ItemDroppedOnCreatureArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendItemUse(ItemUseArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendLogin(LoginArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendMetaDataRequest(MetaDataRequestArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendPasswordChange(PasswordChangeArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendPickup(PickupArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendEditableProfile(EditableProfileArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendMenuInteraction(MenuInteractionArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendRaiseStat(RaiseStatArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendPublicMessage(PublicMessageArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendServerTableRequest(ServerTableRequestArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendSetNotepad(SetNotepadArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendSkillUse(SkillUseArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendSocialStatus(SocialStatusArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendSpellUse(SpellUseArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendSwapSlot(SwapSlotArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendSynchronizeTicks(SynchronizeTicksArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendTurn(TurnArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendUnequip(UnequipArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendOptionToggle(OptionToggleArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendVersion(VersionArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendWhisper(WhisperArgs args) => DarkAgesClient.ServerEnqueue(args);
    public void SendWorldMapClick(WorldMapClickArgs args) => DarkAgesClient.ServerEnqueue(args);
}