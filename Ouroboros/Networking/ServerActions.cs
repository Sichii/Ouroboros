using Chaos.Networking.Entities.Client;

namespace Ouroboros.Networking;

public sealed class ServerActions
{
    private readonly Client Client;
    public ServerActions(Client client) => Client = client;

    public void SendSequenceChange(byte sequence)
    {
        var args = new SequenceChangeArgs();
        
        Client.ServerEnqueue(args);
    }

    public void SendHomepageRequest()
    {
        var args = new HomepageRequestArgs();
        
        Client.ServerEnqueue(args);
    }

    public void SendNoticeRequest()
    {
        var args = new NoticeRequestArgs();
        
        Client.ServerEnqueue(args);
    }

    public void SendMapDataRequest()
    {
        var args = new MapDataRequestArgs();
        
        Client.ServerEnqueue(args);
    }

    public void SendSelfProfileRequest()
    {
        var args = new SelfProfileRequestArgs();
        
        Client.ServerEnqueue(args);
    }

    public void SendRefreshRequest()
    {
        var args = new RefreshRequestArgs();
        
        Client.ServerEnqueue(args);
    }

    public void SendSpacebar()
    {
        var args = new SpacebarArgs();

        Client.ServerEnqueue(args);
    }
    
    public void SendToggleGroup()
    {
        var args = new ToggleGroupArgs();
        
        Client.ServerEnqueue(args);
    }
    
    public void SendWorldListRequest()
    {
        var args = new WorldListRequestArgs();
        
        Client.ServerEnqueue(args);
    }
    
    public void SendBeginChant(BeginChantArgs args) => Client.ServerEnqueue(args);
    public void SendBoardInteraction(BoardInteractionArgs args) => Client.ServerEnqueue(args);
    public void SendClick(ClickArgs args) => Client.ServerEnqueue(args);
    public void SendClientException(ClientExceptionArgs args) => Client.ServerEnqueue(args);
    public void SendExchangeInteraction(ExchangeInteractionArgs args) => Client.ServerEnqueue(args);
    public void SendClientWalk(ClientWalkArgs args) => Client.ServerEnqueue(args);
    public void SendCreateCharFinalize(CreateCharFinalizeArgs args) => Client.ServerEnqueue(args);
    public void SendCreateCharInitial(CreateCharInitialArgs args) => Client.ServerEnqueue(args);
    public void SendDialogInteraction(DialogInteractionArgs args) => Client.ServerEnqueue(args);
    public void SendChant(ChantArgs args) => Client.ServerEnqueue(args);
    public void SendDisplayEntityRequest(DisplayEntityRequestArgs args) => Client.ServerEnqueue(args);
    public void SendEmote(EmoteArgs args) => Client.ServerEnqueue(args);
    public void SendExitRequest(ExitRequestArgs args) => Client.ServerEnqueue(args);
    public void SendGoldDrop(GoldDropArgs args) => Client.ServerEnqueue(args);
    public void SendGoldDroppedOnCreature(GoldDroppedOnCreatureArgs args) => Client.ServerEnqueue(args);
    public void SendGroupInvite(GroupInviteArgs args) => Client.ServerEnqueue(args);
    public void SendHeartBeat(HeartBeatArgs args) => Client.ServerEnqueue(args);
    public void SendIgnore(IgnoreArgs args) => Client.ServerEnqueue(args);
    public void SendItemDrop(ItemDropArgs args) => Client.ServerEnqueue(args);
    public void SendItemDroppedOnCreature(ItemDroppedOnCreatureArgs args) => Client.ServerEnqueue(args);
    public void SendItemUse(ItemUseArgs args) => Client.ServerEnqueue(args);
    public void SendLogin(LoginArgs args) => Client.ServerEnqueue(args);
    public void SendMetaDataRequest(MetaDataRequestArgs args) => Client.ServerEnqueue(args);
    public void SendPasswordChange(PasswordChangeArgs args) => Client.ServerEnqueue(args);
    public void SendPickup(PickupArgs args) => Client.ServerEnqueue(args);
    public void SendEditableProfile(EditableProfileArgs args) => Client.ServerEnqueue(args);
    public void SendMenuInteraction(MenuInteractionArgs args) => Client.ServerEnqueue(args);
    public void SendRaiseStat(RaiseStatArgs args) => Client.ServerEnqueue(args);
    public void SendPublicMessage(PublicMessageArgs args) => Client.ServerEnqueue(args);
    public void SendServerTableRequest(ServerTableRequestArgs args) => Client.ServerEnqueue(args);
    public void SendSetNotepad(SetNotepadArgs args) => Client.ServerEnqueue(args);
    public void SendSkillUse(SkillUseArgs args) => Client.ServerEnqueue(args);
    public void SendSocialStatus(SocialStatusArgs args) => Client.ServerEnqueue(args);
    public void SendSpellUse(SpellUseArgs args) => Client.ServerEnqueue(args);
    public void SendSwapSlot(SwapSlotArgs args) => Client.ServerEnqueue(args);
    public void SendSynchronizeTicks(SynchronizeTicksArgs args) => Client.ServerEnqueue(args);
    public void SendTurn(TurnArgs args) => Client.ServerEnqueue(args);
    public void SendUnequip(UnequipArgs args) => Client.ServerEnqueue(args);
    public void SendOptionToggle(OptionToggleArgs args) => Client.ServerEnqueue(args);
    public void SendVersion(VersionArgs args) => Client.ServerEnqueue(args);
    public void SendWhisper(WhisperArgs args) => Client.ServerEnqueue(args);
    public void SendWorldMapClick(WorldMapClickArgs args) => Client.ServerEnqueue(args);
}