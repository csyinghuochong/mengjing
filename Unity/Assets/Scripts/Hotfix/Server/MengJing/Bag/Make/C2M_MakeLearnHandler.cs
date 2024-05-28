using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_MakeLearnHandler : MessageLocationHandler<Unit, C2M_MakeLearnRequest, M2C_MakeLearnResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_MakeLearnRequest request, M2C_MakeLearnResponse response)
        {
            try
            {
                EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(request.MakeId);

                //判断学习金币是否不足
                if (unit.GetComponent<UserInfoComponentS>().UserInfo.Gold <equipMakeConfig.LearnGoldValue)
                {
                    response.Error = ErrorCode.ERR_GoldNotEnoughError;
                    return;
                }

                //判断是否已经学习
                if (unit.GetComponent<UserInfoComponentS>().UserInfo.MakeList.Contains(request.MakeId))
                {
                    return;
                }

                //判断学习是否已经满足熟练度要求
                int shulianduNumeric = request.Plan == 1 ? NumericType.MakeShuLianDu_1 : NumericType.MakeShuLianDu_2;
                if (unit.GetComponent<NumericComponentS>().GetAsInt(shulianduNumeric) < equipMakeConfig.NeedProficiencyValue) {
                    response.Error = ErrorCode.ERR_ShuLianDuNotEnough;
                    return;
                }

                //判断学习等级是否满足
                if (unit.GetComponent<UserInfoComponentS>().UserInfo.Lv < equipMakeConfig.LearnLv)
                {
                    response.Error = ErrorCode.ERR_LevelNoEnough;
                    return;
                }

                List<RewardItem> costItems = new List<RewardItem>();
                string neadItems = equipMakeConfig.LearnNeedItems;
                string[] needList = neadItems.Split('@');
                for (int i = 0; i < needList.Length; i++)
                {
                    string[] itemInfo = needList[i].Split(';');
                    if (itemInfo.Length < 2)
                    {
                        continue;
                    }
                    int itemId = int.Parse(itemInfo[0]);
                    int itemNum = int.Parse(itemInfo[1]);
                    costItems.Add(new RewardItem() { ItemID = itemId, ItemNum = itemNum });
                }
                bool success = unit.GetComponent<BagComponentS>().OnCostItemData(costItems);
                if (success)
                {
                    unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneySub(UserDataType.Gold, (equipMakeConfig.LearnGoldValue * -1).ToString(), true, ItemGetWay.SkillMake);
                    unit.GetComponent<UserInfoComponentS>().UserInfo.MakeList.Add(request.MakeId);
                }
                else
                {
                    response.Error = ErrorCode.ERR_GoldNotEnoughError;
                }
                await ETTask.CompletedTask;
            }
            catch (Exception ex)
            {
                Log.Debug(ex.ToString());
            }
            
        }
    }
}

