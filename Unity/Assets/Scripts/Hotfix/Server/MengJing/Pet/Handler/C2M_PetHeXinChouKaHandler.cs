using System.Collections.Generic;

namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetHeXinChouKaHandler: MessageLocationHandler<Unit, C2M_PetHeXinChouKaRequest, M2C_PetHeXinChouKaResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetHeXinChouKaRequest request, M2C_PetHeXinChouKaResponse response)
        {
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < request.ChouKaType)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            int dropId = 0;
            int exlporeNumber = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetHeXinExploreNumber);
            string[] set = GlobalValueConfigCategory.Instance.Get(112).Value.Split(';');
            float discount;
            if (exlporeNumber < int.Parse(set[0])) // 超过300次打8折
            {
                discount = 1;
            }
            else
            {
                discount = float.Parse(set[1]);
            }

            if (request.ChouKaType == 1)
            {
                string needItems = GlobalValueConfigCategory.Instance.Get(110).Value.Split('@')[0];
                dropId = int.Parse(GlobalValueConfigCategory.Instance.Get(110).Value.Split('@')[1]);
                bool sucess = unit.GetComponent<BagComponentS>().OnCostItemData(needItems);
                if (!sucess)
                {
                    response.Error = ErrorCode.ERR_ItemNotEnoughError;
                    return;
                }

                //unit.GetComponent<NumericComponent>().ApplyChange(null, NumericType.PetExploreNumber, 1, 0);
            }
            else if (request.ChouKaType == 10)
            {
                string[] itemInfo10 = GlobalValueConfigCategory.Instance.Get(111).Value.Split('@')[0].Split(';');
                dropId = int.Parse(GlobalValueConfigCategory.Instance.Get(111).Value.Split('@')[1]);
                bool sucess = unit.GetComponent<BagComponentS>().OnCostItemData(new List<RewardItem>()
                {
                    new RewardItem() { ItemID = int.Parse(itemInfo10[0]), ItemNum = (int)(int.Parse(itemInfo10[1]) * discount) }
                });
                if (!sucess)
                {
                    response.Error = ErrorCode.ERR_ItemNotEnoughError;
                    return;
                }
                unit.GetComponent<NumericComponentS>().ApplyChange(NumericType.PetHeXinExploreNumber, 10);
            }

            List<RewardItem> rewardItems = new List<RewardItem>();
            for (int i = 0; i < request.ChouKaType; i++)
            {
                DropHelper.DropIDToDropItem_2(dropId, rewardItems);
            }
            
            unit.GetComponent<BagComponentS>()
                    .OnAddItemData(rewardItems, string.Empty, $"{ItemGetWay.PetExplore}_{TimeHelper.ServerNow()}");
            response.RewardList = rewardItems;

            await ETTask.CompletedTask;
        }
    }
}