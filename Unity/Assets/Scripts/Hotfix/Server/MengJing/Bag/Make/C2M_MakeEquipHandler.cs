using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_MakeEquipHandler: MessageLocationHandler<Unit, C2M_MakeEquipRequest, M2C_MakeEquipResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_MakeEquipRequest request, M2C_MakeEquipResponse response)
        {
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) == 0)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            if (!EquipMakeConfigCategory.Instance.Contain(request.MakeId))
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(request.MakeId);
            int locType = ItemLocType.ItemLocBag;
            int costItemId = 0;
            if (request.BagInfoID != 0)
            {
                ItemInfo useBagInfo = unit.GetComponent<BagComponentS>().GetItemByLoc(locType, request.BagInfoID);
                if (useBagInfo != null)
                {
                    costItemId = useBagInfo.ItemID;
                }
            }

            if (costItemId == 0 && equipMakeConfig.ProficiencyType == 0)
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            if (unit.GetComponent<UserInfoComponentS>().UserInfo.Gold < equipMakeConfig.MakeNeedGold)
            {
                response.Error = ErrorCode.ERR_GoldNotEnoughError;
                return;
            }

            if (unit.GetComponent<UserInfoComponentS>().UserInfo.Vitality < equipMakeConfig.CostVitality)
            {
                response.Error = ErrorCode.ERR_VitalityNotEnoughError;
                return;
            }

            //制造图纸查看当前背包是否已经有图纸了

            List<RewardItem> costItems = new List<RewardItem>();
            string neadItems = equipMakeConfig.NeedItems;
            string[] needList = neadItems.Split('@');
            for (int i = 0; i < needList.Length; i++)
            {
                string[] itemInfo = needList[i].Split(';');
                if (itemInfo.Length != 2)
                {
                    continue;
                }

                int itemId = int.Parse(itemInfo[0]);
                int itemNum = int.Parse(itemInfo[1]);
                costItems.Add(new RewardItem() { ItemID = itemId, ItemNum = itemNum });
            }

            if (costItemId != 0)
            {
                costItems.Add(new RewardItem() { ItemID = costItemId, ItemNum = 1 });
            }

            bool success = unit.GetComponent<BagComponentS>().OnCostItemData(costItems);
            if (!success)
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            unit.GetComponent<UserInfoComponentS>()
                    .UpdateRoleMoneySub(UserDataType.Gold, (equipMakeConfig.MakeNeedGold * -1).ToString(), true, ItemGetWay.SkillMake);
            unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.Vitality, (equipMakeConfig.CostVitality * -1).ToString());
            if (request.BagInfoID == 0)
            {
                unit.GetComponent<UserInfoComponentS>().OnMakeItem(equipMakeConfig.Id);
            }

            float rate = RandomHelper.RandFloat01();
            if (equipMakeConfig.MakeSuccesPro >= rate)
            {
                List<RewardItem> rewardItems = new List<RewardItem>();
                rewardItems.Add(new RewardItem() { ItemID = equipMakeConfig.MakeItemID, ItemNum = equipMakeConfig.MakeEquipNum });
                unit.GetComponent<BagComponentS>().OnAddItemData(rewardItems, unit.GetComponent<UserInfoComponentS>().UserInfo.Name,
                    $"{ItemGetWay.SkillMake}_{request.Plan}_{TimeHelper.ServerNow()}"); //传入制造装备和制造玩家的ID
                unit.GetComponent<TaskComponentS>().OnMakeItem();
                response.ItemId = equipMakeConfig.MakeItemID;
            }
            else
            {
                response.ItemId = 0;
            }

            //制作的过程中有一定概率可以领悟当前等级可以学习的配方
            int makeType = unit.GetComponent<NumericComponentS>().GetAsInt(request.Plan == 1? NumericType.MakeType_1 : NumericType.MakeType_2);
            int newMakeId = MakeHelper.GetNewMakeID(makeType, request.MakeId,
                unit.GetComponent<UserInfoComponentS>().UserInfo.MakeList);
            //宝石不领悟
            if (equipMakeConfig.ProficiencyType != 4 && equipMakeConfig.ProficiencyType != 5 && newMakeId != 0)
            {
                unit.GetComponent<UserInfoComponentS>().UserInfo.MakeList.Add(newMakeId);
                response.NewMakeId = newMakeId;
            }

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(equipMakeConfig.MakeItemID);

            if (equipMakeConfig.ProficiencyType != 4
                && equipMakeConfig.ProficiencyValue != null
                && equipMakeConfig.ProficiencyValue.Length > 1)
            {
                int shulianduNumeric = request.Plan == 1? NumericType.MakeShuLianDu_1 : NumericType.MakeShuLianDu_2;
                int curShuLian = unit.GetComponent<NumericComponentS>().GetAsInt(shulianduNumeric);
                int addShuLian = RandomHelper.RandomNumber(equipMakeConfig.ProficiencyValue[0], equipMakeConfig.ProficiencyValue[1]);
                curShuLian += addShuLian;
                curShuLian = Math.Min(GlobalValueConfigCategory.Instance.MaxShuLianDu, curShuLian);
                unit.GetComponent<NumericComponentS>().ApplyValue(shulianduNumeric, curShuLian);
                unit.GetComponent<ChengJiuComponentS>().OnSkillShuLianDu(curShuLian);
            }

            unit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.MakeNumber_216, 0, 1);
            unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.MakeNumber_12, 0, 1);
            unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.MakeQulityNumber_29, itemConfig.ItemQuality, 1);

            await ETTask.CompletedTask;
        }
    }
}