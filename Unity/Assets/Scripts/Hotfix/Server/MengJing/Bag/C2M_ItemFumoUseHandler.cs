namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(BagComponentServer))]
    public class C2M_ItemFumoUseHandler: MessageLocationHandler<Unit, C2M_ItemFumoUseRequest, M2C_ItemFumoUseResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemFumoUseRequest request, M2C_ItemFumoUseResponse response)
        {
            long bagInfoID = request.OperateBagID;
            BagInfo useBagInfo = unit.GetComponent<BagComponentServer>().GetItemByLoc(ItemLocType.ItemLocBag, bagInfoID);
            if (useBagInfo == null)
            {
                unit.GetComponent<BagComponentServer>().FuMoItemId = 0;
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }
            unit.GetComponent<BagComponentServer>().OnCostItemData(bagInfoID, 1);
            unit.GetComponent<BagComponentServer>().FuMoItemId = useBagInfo.ItemID;
            unit.GetComponent<BagComponentServer>().FuMoProList = request.FuMoProList;
            unit.GetComponent<ChengJiuComponentServer>().TriggerEvent(ChengJiuTargetEnum.FoMoNumber_213, 0, 1);

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(useBagInfo.ItemID);

            unit.GetComponent<TaskComponentServerSystem>().TriggerTaskEvent(TaskTargetType.FuMoQulity_41, itemConfig.ItemQuality, 1);
            unit.GetComponent<TaskComponentServerSystem>().TriggerTaskCountryEvent(TaskTargetType.FuMoQulity_41, itemConfig.ItemQuality, 1);

            await ETTask.CompletedTask;
        }
    }
}