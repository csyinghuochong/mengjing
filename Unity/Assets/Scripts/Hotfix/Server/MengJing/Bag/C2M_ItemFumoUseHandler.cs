namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(BagComponent_S))]
    public class C2M_ItemFumoUseHandler: MessageLocationHandler<Unit, C2M_ItemFumoUseRequest, M2C_ItemFumoUseResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemFumoUseRequest request, M2C_ItemFumoUseResponse response)
        {
            long bagInfoID = request.OperateBagID;
            BagInfo useBagInfo = unit.GetComponent<BagComponent_S>().GetItemByLoc(ItemLocType.ItemLocBag, bagInfoID);
            if (useBagInfo == null)
            {
                unit.GetComponent<BagComponent_S>().FuMoItemId = 0;
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }
            unit.GetComponent<BagComponent_S>().OnCostItemData(bagInfoID, 1);
            unit.GetComponent<BagComponent_S>().FuMoItemId = useBagInfo.ItemID;
            unit.GetComponent<BagComponent_S>().FuMoProList = request.FuMoProList;
            unit.GetComponent<ChengJiuComponent_S>().TriggerEvent(ChengJiuTargetEnum.FoMoNumber_213, 0, 1);

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(useBagInfo.ItemID);

            unit.GetComponent<TaskComponent_S>().TriggerTaskEvent(TaskTargetType.FuMoQulity_41, itemConfig.ItemQuality, 1);
            unit.GetComponent<TaskComponent_S>().TriggerTaskCountryEvent(TaskTargetType.FuMoQulity_41, itemConfig.ItemQuality, 1);

            await ETTask.CompletedTask;
        }
    }
}