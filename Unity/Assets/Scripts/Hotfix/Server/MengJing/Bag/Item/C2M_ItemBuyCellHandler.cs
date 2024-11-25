using System;
using System.Collections.Generic;

namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(BagComponentS))]
    [FriendOf(typeof(UserInfoComponentS))]
    public class C2M_ItemBuyCellHandler: MessageLocationHandler<Unit, C2M_ItemBuyCellRequest, M2C_ItemBuyCellResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemBuyCellRequest request, M2C_ItemBuyCellResponse response)
        {
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
           
            if (request.OperateType == (int)ItemLocType.ItemLocBag)
            {
                if (bagComponent.GetBagTotalCell(ItemLocType.ItemLocBag) >= GlobalValueConfigCategory.Instance.BagMaxCapacity)
                {
                    response.Error = ErrorCode.ERR_AleardyMaxCell;
                    return;
                }
                BuyCellCost buyCellCost = ConfigData.BuyBagCellCosts[bagComponent.BagBuyCellNumber[0]];
                if (!bagComponent.OnCostItemData(buyCellCost.Cost))
                {
                    response.Error = ErrorCode.ERR_ItemNotEnoughError;
                    return;
                }


                string[] iteminfo = buyCellCost.Get.Split(';');
                response.GetItem = buyCellCost.Get;
                bagComponent.BagBuyCellNumber[0] += 1;

                RewardItem rewardItem = new RewardItem()
                {
                    ItemID = int.Parse(iteminfo[0]),
                    ItemNum = int.Parse(iteminfo[1]),
                };
                List<RewardItem> rewardItems = new List<RewardItem>() { rewardItem };
                bagComponent.OnAddItemData(rewardItems, String.Empty, $"{ItemGetWay.CostItem}_{TimeHelper.ServerNow()}", true, false, request.OperateType);
            }
            else if (request.OperateType == (int)ItemLocType.GemWareHouse1)
            {
                Log.Warning("还没有购买格子的需求！");
            }
            else
            {
                int storeindex = request.OperateType;
                if (storeindex < 5 || storeindex > 9)
                {
                    response.Error = ErrorCode.ERR_ModifyData;
                    return;
                }


                if (bagComponent.GetBagTotalCell(request.OperateType) >= GlobalValueConfigCategory.Instance.HourseMaxCapacity)
                {
                    response.Error = ErrorCode.ERR_AleardyMaxCell;
                    return;
                }

                int addcell = bagComponent.BagBuyCellNumber[storeindex];
                BuyCellCost buyCellCost = ConfigData.BuyStoreCellCosts[(storeindex - 5) * 10 + addcell];
                if (!bagComponent.OnCostItemData(buyCellCost.Cost))
                {
                    response.Error = ErrorCode.ERR_ItemNotEnoughError;
                    return;
                }

                string[] iteminfo = buyCellCost.Get.Split(';');
                response.GetItem = buyCellCost.Get;
                bagComponent.BagBuyCellNumber[storeindex] += 1;

                RewardItem rewardItem = new RewardItem()
                {
                    ItemID = int.Parse(iteminfo[0]),
                    ItemNum = int.Parse(iteminfo[1]),
                };
                List<RewardItem> rewardItems = new List<RewardItem>() { rewardItem };
                bagComponent.OnAddItemData(rewardItems, String.Empty, $"{ItemGetWay.CostItem}_{TimeHelper.ServerNow()}", true, false, request.OperateType);
            }

            response.WarehouseAddedCell .AddRange(bagComponent.BagBuyCellNumber); 
            await ETTask.CompletedTask;
        }
    }
    
}