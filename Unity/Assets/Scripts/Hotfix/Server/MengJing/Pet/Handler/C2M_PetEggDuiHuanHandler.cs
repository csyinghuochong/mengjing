using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetEggDuiHuanHandler: MessageLocationHandler<Unit, C2M_PetEggDuiHuanRequest, M2C_PetEggDuiHuanResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetEggDuiHuanRequest request, M2C_PetEggDuiHuanResponse response)
        {
            if (!PetEggDuiHuanConfigCategory.Instance.Contain(request.ChouKaId))
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            PetEggDuiHuanConfig config = PetEggDuiHuanConfigCategory.Instance.Get(request.ChouKaId);
            if (unit.GetComponent<BagComponentS>().OnCostItemData(config.CostItems))
            {
                List<RewardItem> rewardItems = new List<RewardItem>();
                DropHelper.DropIDToDropItem_2(config.DropID, rewardItems);
                unit.GetComponent<BagComponentS>().OnAddItemData(rewardItems, string.Empty, $"{ItemGetWay.PetEggDuiHuan}_{TimeHelper.ServerNow()}");
                response.RewardList = rewardItems;   
            }
            await ETTask.CompletedTask;
        }
    }
}

