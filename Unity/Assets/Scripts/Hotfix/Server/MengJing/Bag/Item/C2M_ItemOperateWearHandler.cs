namespace ET.Server
{
    //猎人装备武器单独协议处理
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof (UserInfoComponentS))]
    [FriendOf(typeof (BagComponentS))]
    public class C2M_ItemOperateWearHandler: MessageLocationHandler<Unit, C2M_ItemOperateWearRequest, M2C_ItemOperateWearResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemOperateWearRequest request, M2C_ItemOperateWearResponse response)
        {
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            UserInfo useInfo = userInfoComponent.UserInfo;
            long bagInfoID = request.OperateBagID;

            if (request.OperateType == 3)
            {

                int locType = ItemLocType.ItemLocBag;
                ItemInfo useBagInfo = unit.GetComponent<BagComponentS>().GetItemByLoc(locType, bagInfoID);
                if (useBagInfo == null)
                {
                    return;
                }
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(useBagInfo.ItemID);

                int error = ItemHelper.CanEquip(useBagInfo, useInfo);
                if (error != 0)
                {
                    response.Error = error;
                    return;
                }
                
                int weizhi = itemConfig.ItemSubType;
                if (weizhi != (int)ItemSubTypeEnum.Wuqi)
                {
                    response.Error = ErrorCode.ERR_EquipType;     //错误码:穿戴类型不符
                    return;
                }

                ///默认 0弓箭   1剑
                int equipIndex = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.EquipIndex);
                int equipType = itemConfig.EquipType;
                int findIndex = -1;
                if (equipType == (int)ItemEquipType.Bow)
                {
                    findIndex = equipIndex == 0 ? 0 : 1;
                }
                if (equipType == (int)ItemEquipType.Sword)
                {
                    findIndex = equipIndex == 0 ? 1 : 0;
                }
                if (findIndex == -1)
                {
                    response.Error = ErrorCode.ERR_EquipType;     //错误码:穿戴类型不符
                    return;
                }

                //通知客户端背包刷新
                M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();

                //获取之前的位置是否有装备
                int toLocType = findIndex == 0 ? ItemLocType.ItemLocEquip : ItemLocType.ItemLocEquip_2;
                ItemInfo beforeequip = unit.GetComponent<BagComponentS>().GetEquipBySubType(toLocType, weizhi);

                if (beforeequip != null)
                {
                    unit.GetComponent<BagComponentS>().OnChangeItemLoc(beforeequip, ItemLocType.ItemLocBag, toLocType);
                    unit.GetComponent<BagComponentS>().OnChangeItemLoc(useBagInfo, toLocType, ItemLocType.ItemLocBag);

                    unit.GetComponent<SkillSetComponentS>().OnTakeOffEquip(toLocType, beforeequip);
                    unit.GetComponent<SkillSetComponentS>().OnWearEquip(useBagInfo);
                    m2c_bagUpdate.BagInfoUpdate.Add(beforeequip.ToMessage());
                }
                else
                {
                    unit.GetComponent<BagComponentS>().OnChangeItemLoc(useBagInfo, toLocType, ItemLocType.ItemLocBag);
                    unit.GetComponent<SkillSetComponentS>().OnWearEquip(useBagInfo);
                }

                int zodiacnumber = unit.GetComponent<BagComponentS>().GetZodiacnumber();
                unit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.ZodiacEquipNumber_215, 0, zodiacnumber);

                Function_Fight.UnitUpdateProperty_Base(unit, true, true);
                useBagInfo.isBinging = true;
                m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());

                //if (weizhi == (int)ItemSubTypeEnum.Wuqi)
                //{
                //    unit.GetComponent<SkillPassiveComponent>().OnTrigegerPassiveSkill(SkillPassiveTypeEnum.WandBuff_8, useBagInfo.ItemID);
                //    unit.GetComponent<NumericComponent>().ApplyValue(NumericType.Now_Weapon, useBagInfo.ItemID);
                //    unit.GetComponent<NumericComponent>().ApplyValue(NumericType.WearWeaponFisrt, 1, true, true);
                //}
                MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            }
            else
            {

                int beloc = ItemLocType.ItemLocEquip;
                ItemInfo useBagInfo = unit.GetComponent<BagComponentS>().GetItemByLoc(beloc, bagInfoID);
                if (useBagInfo == null)
                {
                    beloc = ItemLocType.ItemLocEquip_2;
                    useBagInfo = unit.GetComponent<BagComponentS>().GetItemByLoc(beloc, bagInfoID);
                }

                if (useBagInfo == null)
                {
                    return;
                }
                //通知客户端背包刷新
                M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();

                unit.GetComponent<BagComponentS>().OnChangeItemLoc(useBagInfo, ItemLocType.ItemLocBag, beloc);
                unit.GetComponent<SkillSetComponentS>().OnTakeOffEquip(beloc, useBagInfo);
                Function_Fight.UnitUpdateProperty_Base(unit, true, true);
                m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());
                MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            }

            ItemInfo equip_0 = unit.GetComponent<BagComponentS  >().GetEquipBySubType(ItemLocType.ItemLocEquip, (int)ItemSubTypeEnum.Wuqi);
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.Now_Weapon, equip_0 != null ? equip_0.ItemID : 0, true);

            await ETTask.CompletedTask;
        }
    }
}