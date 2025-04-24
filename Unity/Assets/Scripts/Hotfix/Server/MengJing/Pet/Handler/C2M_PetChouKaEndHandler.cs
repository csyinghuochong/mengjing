using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetChouKaEndHandler: MessageLocationHandler<Unit, C2M_PetChouKaEndRequest, M2C_PetChouKaEndResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetChouKaEndRequest request, M2C_PetChouKaEndResponse response)
        {
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }
            
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            if (numericComponent.GetAsInt(NumericType.PetChouKaRewardItemId) != 0)
            {
                List<RewardItem> reward = new List<RewardItem>();
                reward.Add(new RewardItem() { ItemID = numericComponent.GetAsInt(NumericType.PetChouKaRewardItemId), ItemNum = 1 });

                unit.GetComponent<BagComponentS>().OnAddItemData(reward, string.Empty, $"{ItemGetWay.PetExplore}_{TimeHelper.ServerNow()}");
                numericComponent.ApplyValue(NumericType.PetChouKaRewardItemId, 0);
                numericComponent.ApplyValue(NumericType.PetChouKaRewardItemNum, 0);
            }
            
            await ETTask.CompletedTask;
        }
    }
}