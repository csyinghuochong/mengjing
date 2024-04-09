using System;
using System.Collections.Generic;

namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemXiLianHandler : MessageLocationHandler<Unit, C2M_ItemXiLianRequest, M2C_ItemXiLianResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemXiLianRequest request, M2C_ItemXiLianResponse response)
        {
            try
            {
                ItemLocType itemLocType = ItemLocType.ItemLocBag;
                BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
                BagInfo bagInfo = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, request.OperateBagID);

                if (bagInfo == null)
                {
                    bagInfo = bagComponent.GetItemByLoc(ItemLocType.ItemLocEquip, request.OperateBagID);
                    itemLocType = ItemLocType.ItemLocEquip;
                }
                if (bagInfo == null)
                {
                    bagInfo = bagComponent.GetItemByLoc(ItemLocType.ItemLocEquip_2, request.OperateBagID); 
                    itemLocType = ItemLocType.ItemLocEquip_2;
                }
                
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);

                if (itemConfig.EquipType == 101 || itemConfig.EquipType == 201)
                {
                    response.Error = ErrorCode.ERR_ItemUseError;
                    return;
                }

                int[] costItems = itemConfig.XiLianStone;
                List<RewardItem> rewardItems = new List<RewardItem>();

                bool ifZuanShi = false;

                if (request.Times == 1)
                {
                    if (costItems != null && costItems.Length > 1)
                    {
                        //普通洗炼
                        rewardItems.Add(new RewardItem() { ItemID = costItems[0], ItemNum = costItems[1] * request.Times });
                    }
                }
                else
                {
                    //钻石洗炼
                    UserInfo userInfo = unit.GetComponent<UserInfoComponentS>().UserInfo;
                    int itemXiLianNumber = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.ItemXiLianNumber);
                    string[] set = GlobalValueConfigCategory.Instance.Get(116).Value.Split(';');
                    double discount;
                    if (itemXiLianNumber < int.Parse(set[0]))
                    {
                        discount = 1;
                    }
                    else
                    {
                        discount = double.Parse(set[1]);
                    }
                    int needDimanond = int.Parse(GlobalValueConfigCategory.Instance.Get(73).Value.Split('@')[0]);
                    needDimanond = (int)(needDimanond * discount);
                    if (userInfo.Diamond < needDimanond)
                    {
                        response.Error = ErrorCode.ERR_DiamondNotEnoughError;
                        return;
                    }
                    rewardItems.Add(new RewardItem() { ItemID = (int)UserDataType.Diamond, ItemNum = needDimanond });
                    ifZuanShi = true;
                }

                bool sucess = bagComponent.OnCostItemData(rewardItems);
                if (!sucess)
                {
                    return;
                }
                int diamondXiLianTimes = unit.GetComponent<DataCollationComponent>().DiamondXiLianTimes;
                int xilianLevel = XiLianHelper.GetXiLianId(unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.ItemXiLianDu));
                xilianLevel = xilianLevel != 0 ? EquipXiLianConfigCategory.Instance.Get(xilianLevel).XiLianLevel : 0;
                string userName = unit.GetComponent<UserInfoComponentS>().UserName;
                for (int i = 0; i < request.Times; i++)
                {
                    response.ItemXiLianResults.Add( XiLianHelper.XiLianItem(unit, bagInfo, 1, xilianLevel, ifZuanShi ? 1: 0, diamondXiLianTimes, 0, userName) );     //精炼属性不进行重置
                }

                if (ifZuanShi)
                {
                    unit.GetComponent<NumericComponentS>().ApplyChange(null, NumericType.ItemXiLianNumber, request.Times, 0);
                }

                if (request.Times == 1 && (itemLocType == ItemLocType.ItemLocEquip || itemLocType == ItemLocType.ItemLocEquip_2))
                {
                    unit.GetComponent<SkillSetComponentS>().OnTakeOffEquip(itemLocType, bagInfo, bagInfo.BagInfoID);
                }

                if (request.Times == 1)
                {
                    ItemXiLianResult itemXiLian = response.ItemXiLianResults[0];
                    bagInfo.XiLianHideProLists = itemXiLian.XiLianHideProLists;              //基础属性洗炼
                    bagInfo.HideSkillLists = itemXiLian.HideSkillLists;                      //隐藏技能
                    bagInfo.XiLianHideTeShuProLists = itemXiLian.XiLianHideTeShuProLists;    //特殊属性洗炼

                    M2C_RoleBagUpdate m2c_bagUpdate = new M2C_RoleBagUpdate();
                    //通知客户端背包道具发生改变
                    m2c_bagUpdate.BagInfoUpdate.Add(bagInfo);
                    MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
                }

                if (request.Times == 1 && (itemLocType == ItemLocType.ItemLocEquip || itemLocType == ItemLocType.ItemLocEquip_2))
                {
                    unit.GetComponent<SkillSetComponentS>().OnWearEquip(bagInfo);
                }

                for (int i = 0; i < response.ItemXiLianResults.Count; i++)
                {
                    ItemXiLianResult itemXiLianResult = response.ItemXiLianResults[i];
                    for (int skill = 0; skill < itemXiLianResult.HideSkillLists.Count; skill++)
                    {
                        unit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.EquipActiveSkillId_222, itemXiLianResult.HideSkillLists[skill], 1);
                    }

                    for (int attr = 0;  attr < itemXiLianResult.XiLianHideProLists.Count; attr++ )
                    {
                        unit.GetComponent<TaskComponentS>().TriggerTaskEvent( TaskTargetType.XiLianAttriId_45, itemXiLianResult.XiLianHideProLists[0].HideID, 1);
                        unit.GetComponent<TaskComponentS>().TriggerTaskCountryEvent(TaskTargetType.XiLianAttriId_45, itemXiLianResult.XiLianHideProLists[0].HideID, 1);
                    }

                    unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.XiLianSkillNumber_44, itemXiLianResult.HideSkillLists.Count, 1);
                    unit.GetComponent<TaskComponentS>().TriggerTaskCountryEvent(TaskTargetType.XiLianSkillNumber_44, itemXiLianResult.HideSkillLists.Count, 1);
                }

                unit.GetComponent<ChengJiuComponentS>().OnEquipXiLian(request.Times);
                unit.GetComponent<TaskComponentS>().OnEquipXiLian(request.Times);
                unit.GetComponent<DataCollationComponent>().OnXiLian(request.Times);
                Function_Fight.UnitUpdateProperty_Base( unit, true, true );


                string[] xiliandu = GlobalValueConfigCategory.Instance.Get(49).Value.Split(";");
                int addXilian = RandomHelper.RandomNumber(int.Parse(xiliandu[0]), int.Parse(xiliandu[1]));
                if (ifZuanShi)
                {
                    addXilian = (int)(addXilian * 2f);
                }
                else 
                {
                    addXilian = (int)(addXilian * 0.7f);
                }
                unit.GetComponent<NumericComponentS>().ApplyChange(null, NumericType.ItemXiLianDu, addXilian * request.Times, 0, true);

                await ETTask.CompletedTask;
            }
            catch (Exception ex)
            {
                Log.Debug(ex.ToString());
            }
        }
    }
}
