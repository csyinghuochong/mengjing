namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemInheritSelectHandler: MessageLocationHandler<Unit, C2M_ItemInheritSelectRequest, M2C_ItemInheritSelectResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemInheritSelectRequest request, M2C_ItemInheritSelectResponse response)
        {
            BagInfo bagInfo = unit.GetComponent<BagComponentServer  >().GetItemByLoc(ItemLocType.ItemLocBag, request.OperateBagID);
            if (bagInfo == null)
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }
            bagInfo.InheritSkills = unit.GetComponent<BagComponentServer>().InheritSkills;

            //֪ͨ�ͻ��˱������߷����ı�
            M2C_RoleBagUpdate m2c_bagUpdate = new M2C_RoleBagUpdate();
            m2c_bagUpdate.BagInfoUpdate.Add(bagInfo);
            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);

            await ETTask.CompletedTask;
        }
    }
}