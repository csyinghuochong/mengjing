using System;
using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentServer))]
    public class C2M_LifeShieldCostHandler : MessageLocationHandler<Unit, C2M_LifeShieldCostRequest, M2C_LifeShieldCostResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_LifeShieldCostRequest request, M2C_LifeShieldCostResponse response)
        {
            await ETTask.CompletedTask;
            
            BagComponentServer bagComponent = unit.GetComponent<BagComponentServer>();
            int addExp =  0;
            List<long> bagidList = new List<long>();
        
            for (int i = 0; i < request.OperateBagID.Count; i++)
            {
                BagInfo bagInfo = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, request.OperateBagID[i]);
                if (bagInfo == null)
                {
                    continue;
                }
                
                if (!ConfigData.ItemAddShieldExp.ContainsKey(bagInfo.ItemID))
                {
                    continue;
                }

                int addValue = ConfigData.ItemAddShieldExp[bagInfo.ItemID];
                if (addValue > 10) {
                    addValue = RandomHelper.NextInt((int)(addValue * 0.8f), (int)(addValue * 1.2f));
                }
                addExp += addValue * bagInfo.ItemNum;
                bagidList.Add(request.OperateBagID[i]);
                response.AddExp = addExp;
            }

            SkillSetComponentServer skillsetComponent = unit.GetComponent<SkillSetComponentServer>();

            //其他盾的等级要大于生命之盾

            skillsetComponent.OnShieldAddExp(request.OperateType, addExp);

            //扣除装备
            bagComponent.OnCostItemData(bagidList, ItemLocType.ItemLocBag);

            Function_Fight.UnitUpdateProperty_Base(unit, true, true);

            response.ShieldList = skillsetComponent.GetLifeShieldList();
        }
    }
}