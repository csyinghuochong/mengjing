namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemXiLianSelectHandler : MessageLocationHandler<Unit, C2M_ItemXiLianSelectRequest, M2C_ItemXiLianSelectResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemXiLianSelectRequest request, M2C_ItemXiLianSelectResponse response)
        {
            int itemLocType = ItemLocType.ItemLocBag;
            ItemInfo bagInfo = unit.GetComponent<BagComponentS>().GetItemByLoc(ItemLocType.ItemLocBag, request.OperateBagID);
            if (bagInfo == null)
            {
                bagInfo = unit.GetComponent<BagComponentS>().GetItemByLoc(ItemLocType.ItemLocEquip, request.OperateBagID);
                itemLocType = ItemLocType.ItemLocEquip;
            }
            if (bagInfo == null)
            {
                bagInfo = unit.GetComponent<BagComponentS>().GetItemByLoc(ItemLocType.ItemLocEquip_2, request.OperateBagID);
                itemLocType = ItemLocType.ItemLocEquip_2;
            }

            if (itemLocType == ItemLocType.ItemLocEquip || itemLocType == ItemLocType.ItemLocEquip_2)
            {
                unit.GetComponent<SkillSetComponentS>().OnTakeOffEquip(itemLocType, bagInfo, bagInfo.BagInfoID);
            }

            ItemXiLianResult itemXiLian = request.ItemXiLianResult;
            if (itemXiLian != null)
            {
                bagInfo.XiLianHideProLists = itemXiLian.XiLianHideProLists;              //基础属性洗炼
                bagInfo.HideSkillLists = itemXiLian.HideSkillLists;                      //隐藏技能
                bagInfo.XiLianHideTeShuProLists = itemXiLian.XiLianHideTeShuProLists;    //特殊属性洗炼
            }

            if (itemLocType == ItemLocType.ItemLocEquip || itemLocType == ItemLocType.ItemLocEquip_2)
            {
                    unit.GetComponent<SkillSetComponentS>().OnWearEquip(bagInfo);
            }

            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
            //通知客户端背包道具发生改变
            m2c_bagUpdate.BagInfoUpdate.Add(bagInfo.ToMessage());
            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);

            Function_Fight.UnitUpdateProperty_Base(unit, true, true);
            
            await ETTask.CompletedTask;
        }
    }
}
