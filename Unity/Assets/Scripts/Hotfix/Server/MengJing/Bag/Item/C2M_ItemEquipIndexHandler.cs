namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(BagComponentS))]
    [FriendOf(typeof(NumericComponentS))]
    public class C2M_ItemEquipIndexHandler: MessageLocationHandler<Unit, C2M_ItemEquipIndexRequest, M2C_ItemEquipIndexResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemEquipIndexRequest request, M2C_ItemEquipIndexResponse response)
        {
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            ItemInfo equip_0 = bagComponent.GetEquipBySubType(ItemLocType.ItemLocEquip, (int)ItemSubTypeEnum.Wuqi);
            ItemInfo equip_1 = bagComponent.GetEquipBySubType(ItemLocType.ItemLocEquip_2, (int)ItemSubTypeEnum.Wuqi);
            if (equip_0 == null || equip_1 == null)
            {
                response.Error = ErrorCode.ERR_EquipType;
                return;
            }

            //0远程 1近战
            int equipIndex = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.EquipIndex);

            //通知客户端背包刷新
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();

            //交换装备位置
            bagComponent.OnChangeItemLoc(equip_0, ItemLocType.ItemLocEquip_2, ItemLocType.ItemLocEquip);
            bagComponent.OnChangeItemLoc(equip_1, ItemLocType.ItemLocEquip, ItemLocType.ItemLocEquip_2);

            //unit.GetComponent<SkillSetComponentServer>().OnTakeOffEquip(ItemLocType.ItemLocEquip, equip_0);
            //unit.GetComponent<SkillSetComponentServer>().OnWearEquip(equip_1);


            m2c_bagUpdate.BagInfoUpdate.Add(equip_0.ToMessage());
            m2c_bagUpdate.BagInfoUpdate.Add(equip_1.ToMessage());
            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);

            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.EquipIndex, request.EquipIndex, true);
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.Now_Weapon, bagComponent.GetWuqiItemId(), true);

            //unit.GetComponent<SkillSetComponentServer>().OnChangeEquipIndex(request.EquipIndex);
            unit.GetComponent<SkillPassiveComponent>().OnTrigegerPassiveSkill(SkillPassiveTypeEnum.EquipIndex_15);

            await ETTask.CompletedTask;
        }
    }
}