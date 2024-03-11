using System;
using System.Collections.Generic;
using System.Numerics;

namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof (UserInfoComponentServer))]
    [FriendOf(typeof (BagComponentServer))]
    public class C2M_ItemOperateWearHandler: MessageLocationHandler<Unit, C2M_ItemOperateWearRequest, M2C_ItemOperateWearResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemOperateWearRequest request, M2C_ItemOperateWearResponse response)
        {
            UserInfoComponentServer userInfoComponent = unit.GetComponent<UserInfoComponentServer>();
            UserInfo useInfo = userInfoComponent.UserInfo;
            long bagInfoID = request.OperateBagID;

            if (request.OperateType == 3)
            {

                ItemLocType locType = ItemLocType.ItemLocBag;
                BagInfo useBagInfo = unit.GetComponent<BagComponentServer>().GetItemByLoc(locType, bagInfoID);
                if (useBagInfo == null)
                {
                    return;
                }
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(useBagInfo.ItemID);

                //�жϵȼ�
                int roleLv = useInfo.Lv;
                int equipLv = itemConfig.UseLv;
                //����
                if (useBagInfo.HideSkillLists.Contains(68000103))
                {
                    equipLv = equipLv - 5;
                }

                //�޼���
                if (useBagInfo.HideSkillLists.Contains(68000106))
                {
                    equipLv = 1;
                }

                if (roleLv < equipLv)
                {
                    response.Error = ErrorCode.ERR_EquipLvLimit;
                    return;
                }

                //��Ӧ��λ�Ƿ����
                if (itemConfig.ItemType == 3 && itemConfig.EquipType != 0)
                {
                    //�鿴�����Ƿ��Ƕ�ת
                    if (useInfo.OccTwo > 0)
                    {
                        OccupationTwoConfig occtwoCof = OccupationTwoConfigCategory.Instance.Get(useInfo.OccTwo);
                        if (occtwoCof.ArmorMastery == itemConfig.EquipType || itemConfig.EquipType == 99 || itemConfig.EquipType == 101)
                        {
                            //���Դ���
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

                            //�����λ����
                            if (ifWear == false)
                            {
                                response.Error = ErrorCode.ERR_EquipType;     //������:�������Ͳ���
                                return;
                            }
                        }
                    }
                }

                int weizhi = itemConfig.ItemSubType;
                if (weizhi != (int)ItemSubTypeEnum.Wuqi)
                {
                    response.Error = ErrorCode.ERR_EquipType;     //������:�������Ͳ���
                    return;
                }

                ///Ĭ�� 0����   1��
                int equipIndex = unit.GetComponent<NumericComponentServer>().GetAsInt(NumericType.EquipIndex);
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
                    response.Error = ErrorCode.ERR_EquipType;     //������:�������Ͳ���
                    return;
                }

                //֪ͨ�ͻ��˱���ˢ��
                M2C_RoleBagUpdate m2c_bagUpdate = new M2C_RoleBagUpdate();

                //��ȡ֮ǰ��λ���Ƿ���װ��
                ItemLocType toLocType = findIndex == 0 ? ItemLocType.ItemLocEquip : ItemLocType.ItemLocEquip_2;
                BagInfo beforeequip = unit.GetComponent<BagComponentServer>().GetEquipBySubType(toLocType, weizhi);

                if (beforeequip != null)
                {
                    unit.GetComponent<BagComponentServer>().OnChangeItemLoc(beforeequip, ItemLocType.ItemLocBag, toLocType);
                    unit.GetComponent<BagComponentServer>().OnChangeItemLoc(useBagInfo, toLocType, ItemLocType.ItemLocBag);

                    unit.GetComponent<SkillSetComponentServer>().OnTakeOffEquip(toLocType, beforeequip);
                    unit.GetComponent<SkillSetComponentServer>().OnWearEquip(useBagInfo);
                    m2c_bagUpdate.BagInfoUpdate.Add(beforeequip);
                }
                else
                {
                    unit.GetComponent<BagComponentServer>().OnChangeItemLoc(useBagInfo, toLocType, ItemLocType.ItemLocBag);
                    unit.GetComponent<SkillSetComponentServer>().OnWearEquip(useBagInfo);
                }

                int zodiacnumber = unit.GetComponent<BagComponentServer>().GetZodiacnumber();
                unit.GetComponent<ChengJiuComponentServer>().TriggerEvent(ChengJiuTargetEnum.ZodiacEquipNumber_215, 0, zodiacnumber);

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
                BagInfo useBagInfo = unit.GetComponent<BagComponentServer>().GetItemByLoc(beloc, bagInfoID);
                if (useBagInfo == null)
                {
                    beloc = ItemLocType.ItemLocEquip_2;
                    useBagInfo = unit.GetComponent<BagComponentServer>().GetItemByLoc(beloc, bagInfoID);
                }

                if (useBagInfo == null)
                {
                    return;
                }
                //֪ͨ�ͻ��˱���ˢ��
                M2C_RoleBagUpdate m2c_bagUpdate = new M2C_RoleBagUpdate();

                unit.GetComponent<BagComponentServer>().OnChangeItemLoc(useBagInfo, ItemLocType.ItemLocBag, beloc);
                unit.GetComponent<SkillSetComponentServer>().OnTakeOffEquip(beloc, useBagInfo);
                Function_Fight.UnitUpdateProperty_Base(unit, true, true);
                m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo);
                MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            }

            BagInfo equip_0 = unit.GetComponent<BagComponentServer  >().GetEquipBySubType(ItemLocType.ItemLocEquip, (int)ItemSubTypeEnum.Wuqi);
            unit.GetComponent<NumericComponentServer>().SetEvent(NumericType.Now_Weapon, equip_0 != null ? equip_0.ItemID : 0, true);

            await ETTask.CompletedTask;
        }
    }
}