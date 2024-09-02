using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JingHeWearHandler : MessageLocationHandler<Unit, C2M_JingHeWearRequest, M2C_JingHeWearResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JingHeWearRequest request, M2C_JingHeWearResponse response)
        {
            int equipIndex = 0;
            try
            {
                equipIndex = int.Parse(request.OperatePar);
            }
            catch (Exception ex) 
            {
                Log.Error(ex);  
                Log.Error($"C2M_JingHeWearRequest 1");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }
            

            int locType = request.OperateType == 1 ? ItemLocType.ItemLocBag : ItemLocType.SeasonJingHe;
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            ItemInfo useBagInfo = bagComponent.GetItemByLoc(locType, request.OperateBagID);
            if (useBagInfo == null)
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }

            //通知客户端背包刷新
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
            if (request.OperateType == 1)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(useBagInfo.ItemID);

                if (unit.GetComponent<UserInfoComponentS>().UserInfo.Lv < itemConfig.UseLv)
                {
                    response.Error = ErrorCode.ERR_EquipLvLimit;
                    return;
                }
                if (itemConfig.ItemType != ItemTypeEnum.Equipment || itemConfig.EquipType != 201)
                {
                    response.Error = ErrorCode.ERR_EquipType;
                    return;
                }
                if (bagComponent.IsEquipJingHe(useBagInfo.ItemID))
                {
                    response.Error = ErrorCode.ERR_EquipType;
                    return;
                }

                //穿戴 获取当前位置是否有装备
                ItemInfo beforeequip = bagComponent.GetJingHeByWeiZhi(equipIndex);
                if (beforeequip != null)
                {
                    beforeequip.EquipPlan = 0;
                    beforeequip.EquipIndex = 0;
                    useBagInfo.EquipPlan = bagComponent.SeasonJingHePlan;
                    useBagInfo.EquipIndex = equipIndex;
                    unit.GetComponent<BagComponentS>().OnChangeItemLoc(beforeequip, ItemLocType.ItemLocBag, ItemLocType.SeasonJingHe);
                    unit.GetComponent<BagComponentS>().OnChangeItemLoc(useBagInfo, ItemLocType.SeasonJingHe, ItemLocType.ItemLocBag);

                    unit.GetComponent<SkillSetComponentS>().OnTakeOffEquip(ItemLocType.SeasonJingHe, beforeequip);
                    unit.GetComponent<SkillSetComponentS>().OnWearEquip(useBagInfo);
                    m2c_bagUpdate.BagInfoUpdate.Add(beforeequip.ToMessage());
                }
                else
                {
                    useBagInfo.EquipPlan = bagComponent.SeasonJingHePlan;
                    useBagInfo.EquipIndex = equipIndex;
                    unit.GetComponent<BagComponentS>().OnChangeItemLoc(useBagInfo, ItemLocType.SeasonJingHe, ItemLocType.ItemLocBag);
                    unit.GetComponent<SkillSetComponentS>().OnWearEquip(useBagInfo);
                }

                Function_Fight.UnitUpdateProperty_Base(unit, true, true);
                useBagInfo.isBinging = true;
                m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());
            }
            if (request.OperateType == 2)
            {
                //卸下  判断背包格子是否足够
                bool full = unit.GetComponent<BagComponentS>().IsBagFullByLoc(ItemLocType.ItemLocBag);
                if (full)
                {
                    response.Error = ErrorCode.ERR_BagIsFull;
                    return;
                }
                useBagInfo.EquipPlan = 0;
                unit.GetComponent<BagComponentS>().OnChangeItemLoc(useBagInfo, ItemLocType.ItemLocBag, ItemLocType.SeasonJingHe);
                unit.GetComponent<SkillSetComponentS>().OnTakeOffEquip(ItemLocType.SeasonJingHe, useBagInfo);
                Function_Fight.UnitUpdateProperty_Base(unit, true, true);
                m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());
            }

            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            //通知客户端属性刷新
            await ETTask.CompletedTask;
        }
    }
}
