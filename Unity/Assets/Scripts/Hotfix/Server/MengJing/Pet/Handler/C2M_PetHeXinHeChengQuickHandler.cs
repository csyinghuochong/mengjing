using System.Collections.Generic;

namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetHeXinHeChengQuickHandler : MessageLocationHandler<Unit, C2M_PetHeXinHeChengQuickRequest, M2C_PetHeXinHeChengQuickResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetHeXinHeChengQuickRequest request, M2C_PetHeXinHeChengQuickResponse response)
        {
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            List<ItemInfo> allPetHeXin = bagComponent.GetItemByLoc(ItemLocType.ItemPetHeXinBag);

            List<long> costList = new List<long>();
            List<RewardItem> rewardItems = new List<RewardItem>();  
            Dictionary<int, List<ItemInfo>> keyValuePairs = new Dictionary<int, List<ItemInfo>>();
            for (int i = 0; i < allPetHeXin.Count; i++)
            {
                ItemInfo bagInfo = allPetHeXin[i];   
                if (!keyValuePairs.ContainsKey(bagInfo.ItemID))
                {
                    keyValuePairs.Add(bagInfo.ItemID, new List<ItemInfo>());
                }
                keyValuePairs[bagInfo.ItemID].Add(bagInfo);
            }


            //去掉多余的
            foreach (var item in keyValuePairs)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(item.Key);
                if (itemConfig.PetHeXinHeChengID == 0)
                {
                    item.Value.Clear();
                    continue;
                }
                if (keyValuePairs.Count < 2)
                {
                    item.Value.Clear();
                }
                if (item.Value.Count % 2 > 0)
                {
                    item.Value.RemoveAt(item.Value.Count - 1);
                }
            }

            foreach (var item in keyValuePairs)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(item.Key);
    
                int number1 = item.Value.Count / 2;
                //新增item
                for (int n = 0; n < number1; n++)
                {
                    rewardItems.Add( new RewardItem() { ItemID = itemConfig.PetHeXinHeChengID, ItemNum = 1 } );
                }

                //移除item
                for (int n = 0; n < item.Value.Count; n++)
                {
                    costList.Add(item.Value[n].BagInfoID);
                }
            }

            bagComponent.OnCostItemData(costList, ItemLocType.ItemPetHeXinBag);
            bagComponent.OnAddItemData(rewardItems, string.Empty, $"{ItemGetWay.PetHeXinHeCheng}_{TimeHelper.ServerNow()}");

            await ETTask.CompletedTask;
        }
    }
}
