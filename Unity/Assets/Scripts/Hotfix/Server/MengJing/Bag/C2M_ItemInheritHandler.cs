namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemInheritHandler: MessageLocationHandler<Unit, C2M_ItemInheritRequest, M2C_ItemInheritResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemInheritRequest request, M2C_ItemInheritResponse response)
        {
            BagInfo bagInfo = unit.GetComponent<BagComponentServer>().GetItemByLoc(ItemLocType.ItemLocBag, request.OperateBagID);
            if (bagInfo == null)
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }
            if (bagInfo.InheritTimes >= GlobalValueConfigCategory.Instance.Get(117).Value2)
            {
                response.Error = ErrorCode.ERR_TimesIsNot;
                return;
            }

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            string costitem = GlobalValueConfigCategory.Instance.Get(88).Value;
            BagComponentServer bagComponent = unit.GetComponent<BagComponentServer>();
            if (!bagComponent.CheckCostItem(costitem))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }
            unit.GetComponent<BagComponentServer>().OnCostItemData(costitem);

            int subtype = itemConfig.ItemSubType;
            int skillid = XiLianHelper.XiLianChuanChengJianDing(itemConfig, unit.GetComponent<UserInfoComponent>().UserInfo.Occ, unit.GetComponent<UserInfoComponent>().UserInfo.OccTwo);

            if (skillid == 0)
            {
                response.Error = ErrorCode.ERR_EquipChuanChengFail;
            }

            response.InheritSkills.Add(skillid);
            bagInfo.isBinging = true;
            bagInfo.InheritTimes += 1;
            unit.GetComponent<BagComponentServer>().InheritSkills = response.InheritSkills;
            //通知客户端背包道具发生改变
            M2C_RoleBagUpdate m2c_bagUpdate = new M2C_RoleBagUpdate(); ;
            m2c_bagUpdate.BagInfoUpdate.Add(bagInfo);
            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);

            await ETTask.CompletedTask;
        }
    }
}