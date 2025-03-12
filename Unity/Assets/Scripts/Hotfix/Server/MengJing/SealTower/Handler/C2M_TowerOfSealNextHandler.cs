using System.Collections.Generic;

namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_TowerOfSealNextHandler: MessageLocationHandler<Unit, C2M_TowerOfSealNextRequest, M2C_TowerOfSealNextResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TowerOfSealNextRequest request, M2C_TowerOfSealNextResponse response)
        {
            Scene domainScene = unit.Scene();
            SealTowerComponent sealTowerComponent = domainScene.GetComponent<SealTowerComponent>();
            if (sealTowerComponent == null)
            {
                return;
            }

            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();

            int oldArrived = numericComponent.GetAsInt(NumericType.SealTowerArrived);
            int oldFinished = numericComponent.GetAsInt(NumericType.SealTowerFinished);

            // 判断是否已经通关顶层
            if (oldFinished >= 100)
            {
                return;
            }

            // 判断该层是否已经通关
            if (oldFinished != oldArrived)
            {
                return;
            }

            // 判断道具是否足够
            if (request.CostType == 0) // 花费钻石
            {
                GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(89);
                int needGold = int.Parse(globalValueConfig.Value);
                if (userInfoComponent.UserInfo.Diamond < needGold)
                {
                    return;
                }

                // 消耗钻石
                userInfoComponent.UpdateRoleMoneySub(UserDataType.Diamond, (-1 * needGold).ToString(), true, ItemGetWay.TowerOfSealCost);
            }
            else if(request.CostType == 1)//花费凭证
            {
                BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
                GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(90);
                int itemConfigID = int.Parse(globalValueConfig.Value);
                if (bagComponent.GetItemNumber(itemConfigID) <= 0)
                {
                    return;
                }
                
                //消耗凭证
                for (int i = 0; i < bagComponent.GetItemByLoc(ItemLocType.ItemLocBag).Count; i++)
                {
                    if (bagComponent.GetItemByLoc(ItemLocType.ItemLocBag)[i].ItemID == itemConfigID)
                    {
                        bagComponent.OnCostItemData(bagComponent.GetItemByLoc(ItemLocType.ItemLocBag)[i].BagInfoID, 1);
                    }
                }
            }
            else if (request.CostType == 10) // 钻石+钻石 去某10层，这里就相信客户端吧
            {
                GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(89);
                int needGold = int.Parse(globalValueConfig.Value) + 350;
                if (userInfoComponent.UserInfo.Diamond < needGold )
                {
                    return;
                }

                // 消耗钻石
                userInfoComponent.UpdateRoleMoneySub(UserDataType.Diamond, (-1 * needGold).ToString(), true, ItemGetWay.TowerOfSealCost);
            }
            else if (request.CostType == 11) // 凭证+钻石
            {
                int needGold = 350;
                if (userInfoComponent.UserInfo.Diamond < needGold)
                {
                    return;
                }

                // 消耗钻石
                userInfoComponent.UpdateRoleMoneySub(UserDataType.Diamond, (-1 * needGold).ToString(), true, ItemGetWay.TowerOfSealCost);

                BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
                GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(90);
                int itemConfigID = int.Parse(globalValueConfig.Value);
                if (bagComponent.GetItemNumber(itemConfigID) <= 0)
                {
                    return;
                }

                //消耗凭证
                for (int i = 0; i < bagComponent.GetItemByLoc(ItemLocType.ItemLocBag).Count; i++)
                {
                    if (bagComponent.GetItemByLoc(ItemLocType.ItemLocBag)[i].ItemID == itemConfigID)
                    {
                        bagComponent.OnCostItemData(bagComponent.GetItemByLoc(ItemLocType.ItemLocBag)[i].BagInfoID, 1);
                    }
                }
            }

            // 改变玩家数据
            int nextArrived = oldArrived + request.DiceResult;
            if (request.DiceResult > 100 - oldArrived)
            {
                nextArrived = 100;
            }

            numericComponent.ApplyValue(NumericType.SealTowerArrived, nextArrived);

            // 清空关卡怪物
            List<Unit> monsterList = UnitHelper.GetUnitList(unit.Scene(), UnitType.Monster);
            for (int i = monsterList.Count - 1; i >= 0; i--)
            {
                domainScene.GetComponent<UnitComponent>().Remove(monsterList[i].Id);
            }

            await unit.Root().GetComponent<TimerComponent>().WaitAsync(1000);

            // 重置关卡
            sealTowerComponent.GenerateFuben(numericComponent.GetAsInt(NumericType.SealTowerArrived),
                numericComponent.GetAsInt(NumericType.SealTowerFinished));

            unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.TowerOfSeal_28, 0, 1);
            
            await ETTask.CompletedTask;
        }
    }
}