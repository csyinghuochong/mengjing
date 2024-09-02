namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemProtectHandler: MessageLocationHandler<Unit, C2M_ItemProtectRequest, M2C_ItemProtectResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemProtectRequest request, M2C_ItemProtectResponse response)
        {
            ItemInfo bagInfo = unit.GetComponent<BagComponentS>().GetItemByLoc(ItemLocType.ItemLocBag, request.OperateBagID);
            if (bagInfo == null)
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }
            bagInfo.IsProtect = request.IsProtect;
            ItemAddHelper.OnItemUpdate(unit, bagInfo);

            await ETTask.CompletedTask;
        }
    }
}