namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(BagComponentS))]
    public class C2M_ItemFumoUseHandler: MessageLocationHandler<Unit, C2M_ItemFumoUseRequest, M2C_ItemFumoUseResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemFumoUseRequest request, M2C_ItemFumoUseResponse response)
        {
            long bagInfoID = request.OperateBagID;
            ItemInfo useBagInfo = unit.GetComponent<BagComponentS>().GetItemByLoc(ItemLocType.ItemLocBag, bagInfoID);
            if (useBagInfo == null)
            {
                unit.GetComponent<BagComponentS>().FuMoItemId = 0;
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }
            unit.GetComponent<BagComponentS>().OnCostItemData(bagInfoID, 1);
            unit.GetComponent<BagComponentS>().FuMoItemId = useBagInfo.ItemID;
            unit.GetComponent<BagComponentS>().FuMoProList = request.FuMoProList;
            unit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.FoMoNumber_213, 0, 1);

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(useBagInfo.ItemID);

            unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.FuMoQulity_41, itemConfig.ItemQuality, 1);

            await ETTask.CompletedTask;
        }
    }
}