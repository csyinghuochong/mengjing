using System;
using System.Collections.Generic;

namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(BagComponent_S))]
    [FriendOf(typeof(UserInfoComponent_S))]
    public class C2M_ItemBuyCellHandler: MessageLocationHandler<Unit, C2M_ItemBuyCellRequest, M2C_ItemBuyCellResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemBuyCellRequest request, M2C_ItemBuyCellResponse response)
        {
            BagComponent_S bagComponent = unit.GetComponent<BagComponent_S>();
           
            if (request.OperateType == (int)ItemLocType.ItemLocBag)
            {
                if (bagComponent.GetBagTotalCell() >= GlobalValueConfigCategory.Instance.BagMaxCapacity)
                {
                    response.Error = ErrorCode.ERR_AleardyMaxCell;
                    return;
                }
                BuyCellCost buyCellCost = ConfigHelper.BuyBagCellCosts()[bagComponent.WarehouseAddedCell[0]];
                if (!bagComponent.OnCostItemData(buyCellCost.Cost))
                {
                    response.Error = ErrorCode.ERR_ItemNotEnoughError;
                    return;
                }


                string[] iteminfo = buyCellCost.Get.Split(';');
                response.GetItem = buyCellCost.Get;
                bagComponent.WarehouseAddedCell[0] += 1;

                RewardItem rewardItem = new RewardItem()
                {
                    ItemID = int.Parse(iteminfo[0]),
                    ItemNum = int.Parse(iteminfo[1]),
                };
                List<RewardItem> rewardItems = new List<RewardItem>() { rewardItem };
                bagComponent.OnAddItemData(rewardItems, String.Empty, $"{ItemGetWay.CostItem}_{TimeHelper.ServerNow()}", true, false, (ItemLocType)request.OperateType);
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


                if (bagComponent.GetHourseTotalCell(request.OperateType) >= GlobalValueConfigCategory.Instance.HourseMaxCapacity)
                {
                    response.Error = ErrorCode.ERR_AleardyMaxCell;
                    return;
                }

                int addcell = bagComponent.WarehouseAddedCell[storeindex];
                BuyCellCost buyCellCost = ConfigHelper.BuyStoreCellCosts()[(storeindex - 5) * 10 + addcell];
                if (!bagComponent.OnCostItemData(buyCellCost.Cost))
                {
                    response.Error = ErrorCode.ERR_ItemNotEnoughError;
                    return;
                }

                string[] iteminfo = buyCellCost.Get.Split(';');
                response.GetItem = buyCellCost.Get;
                bagComponent.WarehouseAddedCell[storeindex] += 1;

                RewardItem rewardItem = new RewardItem()
                {
                    ItemID = int.Parse(iteminfo[0]),
                    ItemNum = int.Parse(iteminfo[1]),
                };
                List<RewardItem> rewardItems = new List<RewardItem>() { rewardItem };
                bagComponent.OnAddItemData(rewardItems, String.Empty, $"{ItemGetWay.CostItem}_{TimeHelper.ServerNow()}", true, false, (ItemLocType)request.OperateType);
            }

            response.WarehouseAddedCell = bagComponent.WarehouseAddedCell;
            await ETTask.CompletedTask;
        }
    }
    
}