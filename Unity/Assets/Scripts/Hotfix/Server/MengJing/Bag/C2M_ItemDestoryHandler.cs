namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(BagComponent_S))]
    public class C2M_ItemDestoryHandler: MessageLocationHandler<Unit, C2M_ItemDestoryRequest, M2C_ItemDestoryResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemDestoryRequest request, M2C_ItemDestoryResponse response)
        {
            long bagInfoID = request.OperateBagID;
            BagInfo useBagInfo = unit.GetComponent<BagComponent_S>().GetItemByLoc(ItemLocType.ItemLocBag, bagInfoID);
            if (useBagInfo == null)
            {
                return;
            }
            unit.GetComponent<BagComponent_S>().OnCostItemData(bagInfoID, 1);

            await ETTask.CompletedTask;
        }
    }
    
}