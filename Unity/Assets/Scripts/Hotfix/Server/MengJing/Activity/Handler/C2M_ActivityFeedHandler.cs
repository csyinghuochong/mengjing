namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_ActivityFeedHandler : MessageLocationHandler<Unit, C2M_ActivityFeedRequest, M2C_ActivityFeedResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ActivityFeedRequest request, M2C_ActivityFeedResponse response)
        {
            int costItemId = request.ItemID;
            if (!ConfigData.FeedItemReward.ContainsKey(costItemId))
            {
                response.Error = ErrorCode.ERR_ItemNotExist;

                return;
            }
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                response.Error = ErrorCode.ERR_BagIsFull;

                return;
            }
            if (bagComponent.GetItemNumber(costItemId) < 1)
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;

                return;
            }
            bagComponent.OnCostItemData($"{costItemId};1");
            bagComponent.OnAddItemData(ConfigData.FeedItemReward[costItemId], $"{ItemGetWay.Activity}_{TimeHelper.ServerNow()}");
            ActorId activitySceneid = UnitCacheHelper.GetActivityServerId(unit.Zone());

            M2A_ActivityFeedRequest M2A_ActivityFeedRequest = M2A_ActivityFeedRequest.Create();
            M2A_ActivityFeedRequest.UnitID = unit.Id;
            A2M_ActivityFeedResponse r_GameStatusResponse = (A2M_ActivityFeedResponse)await unit.Root().GetComponent<MessageSender>().Call
                 (activitySceneid, M2A_ActivityFeedRequest);

            response.ActivityV1InfoProto = unit.GetComponent<ActivityComponentS>().ActivityV1Info.ToMessage();
            response.ActivityV1InfoProto.BaoShiDu = r_GameStatusResponse.BaoShiDu;

            await ETTask.CompletedTask;
        }
    }
}
