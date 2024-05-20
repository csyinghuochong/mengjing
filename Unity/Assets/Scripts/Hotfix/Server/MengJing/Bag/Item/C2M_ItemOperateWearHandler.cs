using System;
using System.Collections.Generic;
using System.Numerics;

namespace ET.Server
{

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

                ItemLocType locType = ItemLocType.ItemLocBag;
                BagInfo useBagInfo = unit.GetComponent<BagComponentS>().GetItemByLoc(locType, bagInfoID);
                if (useBagInfo == null)
                {
                    return;
                }
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(useBagInfo.ItemID);

                //判断等级
                int roleLv = useInfo.Lv;
                int equipLv = itemConfig.UseLv;
                //简易
                if (useBagInfo.HideSkillLists.Contains(68000103))
                {
                    equipLv = equipLv - 5;
                }

                //无级别
                if (useBagInfo.HideSkillLists.Contains(68000106))
                {
                    equipLv = 1;
                }

                if (roleLv < equipLv)
                {
                    response.Error = ErrorCode.ERR_EquipLvLimit;
                    return;
                }

                //对应部位是否符合
                if (itemConfig.ItemType == 3 && itemConfig.EquipType != 0)
                {
                    //查看自身是否是二转
                    if (useInfo.OccTwo > 0)
                    {
                        OccupationTwoConfig occtwoCof = OccupationTwoConfigCategory.Instance.Get(useInfo.OccTwo);
                        if (occtwoCof.ArmorMastery == itemConfig.EquipType || itemConfig.EquipType == 99 || itemConfig.EquipType == 101)
                        {
                            //可以穿戴
                        }
                        else
                        {
                            bool ifWear = false;
                            if (useInfo.Occ == 1 && (itemConfig.EquipType == 1 || itemConfig.EquipType == 2))
                            {
                                ifWear = true;
                            }

                            if (useInfo.Occ == 2 && (itemConfig.EquipType == 3 || itemConfig.EquipType == 4))
                            {
                                ifWear = true;
                            }
                            if (useInfo.Occ == 3 && (itemConfig.EquipType == 1 || itemConfig.EquipType == 5))
                            {
                                ifWear = true;
                            }

                            //佩戴部位不符
                            if (ifWear == false)
                            {
                                response.Error = ErrorCode.ERR_EquipType;     //错误码:穿戴类型不符
                                return;
                            }
                        }
                    }
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
                M2C_RoleBagUpdate m2c_bagUpdate = new M2C_RoleBagUpdate();

                //获取之前的位置是否有装备
                ItemLocType toLocType = findIndex == 0 ? ItemLocType.ItemLocEquip : ItemLocType.ItemLocEquip_2;
                BagInfo beforeequip = unit.GetComponent<BagComponentS>().GetEquipBySubType(toLocType, weizhi);

                if (beforeequip != null)
                {
                    unit.GetComponent<BagComponentS>().OnChangeItemLoc(beforeequip, ItemLocType.ItemLocBag, toLocType);
                    unit.GetComponent<BagComponentS>().OnChangeItemLoc(useBagInfo, toLocType, ItemLocType.ItemLocBag);

                    unit.GetComponent<SkillSetComponentS>().OnTakeOffEquip(toLocType, beforeequip);
                    unit.GetComponent<SkillSetComponentS>().OnWearEquip(useBagInfo);
                    m2c_bagUpdate.BagInfoUpdate.Add(beforeequip);
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
                m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo);

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

                ItemLocType beloc = ItemLocType.ItemLocEquip;
                BagInfo useBagInfo = unit.GetComponent<BagComponentS>().GetItemByLoc(beloc, bagInfoID);
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
                M2C_RoleBagUpdate m2c_bagUpdate = new M2C_RoleBagUpdate();

                unit.GetComponent<BagComponentS>().OnChangeItemLoc(useBagInfo, ItemLocType.ItemLocBag, beloc);
                unit.GetComponent<SkillSetComponentS>().OnTakeOffEquip(beloc, useBagInfo);
                Function_Fight.UnitUpdateProperty_Base(unit, true, true);
                m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo);
                MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            }

            BagInfo equip_0 = unit.GetComponent<BagComponentS  >().GetEquipBySubType(ItemLocType.ItemLocEquip, (int)ItemSubTypeEnum.Wuqi);
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.Now_Weapon, equip_0 != null ? equip_0.ItemID : 0, true);

            await ETTask.CompletedTask;
        }
    }
}