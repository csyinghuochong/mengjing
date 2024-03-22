namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemInheritSelectHandler: MessageLocationHandler<Unit, C2M_ItemInheritSelectRequest, M2C_ItemInheritSelectResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemInheritSelectRequest request, M2C_ItemInheritSelectResponse response)
        {
            BagInfo bagInfo = unit.GetComponent<BagComponent_S  >().GetItemByLoc(ItemLocType.ItemLocBag, request.OperateBagID);
            if (bagInfo == null)
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }
            bagInfo.InheritSkills = unit.GetComponent<BagComponent_S>().InheritSkills;

            //通知客户端背包道具发生改变
            M2C_RoleBagUpdate m2c_bagUpdate = new M2C_RoleBagUpdate();
            m2c_bagUpdate.BagInfoUpdate.Add(bagInfo);
            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);

            await ETTask.CompletedTask;
        }
    }
}