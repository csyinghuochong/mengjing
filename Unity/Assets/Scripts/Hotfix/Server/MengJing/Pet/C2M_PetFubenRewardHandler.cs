using System;
using System.Collections.Generic;

namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetFubenRewardHandler : MessageLocationHandler<Unit, C2M_PetFubenRewardRequest, M2C_PetFubenRewardResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_PetFubenRewardRequest request, M2C_PetFubenRewardResponse response)
        {
            int rewardId = unit.GetComponent<PetComponent_S>().GetCanRewardId();
            if (rewardId == 0)
            {
                response.Error = ErrorCode.ERR_AlreadyFinish;
                return;
            }
            PetFubenRewardConfig rewardConfig = PetFubenRewardConfigCategory.Instance.Get(rewardId);
            unit.GetComponent<BagComponent_S>().OnAddItemData(rewardConfig.RewardItems, $"{ItemGetWay.PetFubenReward}_{TimeHelper.ServerNow()}");
            unit.GetComponent<PetComponent_S>().PetFubeRewardId = rewardId;
            
            await ETTask.CompletedTask;
        }
    }
}
