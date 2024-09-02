namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(BagComponentS))]
    public class C2M_ItemDestoryHandler: MessageLocationHandler<Unit, C2M_ItemDestoryRequest, M2C_ItemDestoryResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemDestoryRequest request, M2C_ItemDestoryResponse response)
        {
            long bagInfoID = request.OperateBagID;
            ItemInfo useBagInfo = unit.GetComponent<BagComponentS>().GetItemByLoc(ItemLocType.ItemLocBag, bagInfoID);
            if (useBagInfo == null)
            {
                return;
            }
            unit.GetComponent<BagComponentS>().OnCostItemData(bagInfoID, 1);

            await ETTask.CompletedTask;
        }
    }
    
}