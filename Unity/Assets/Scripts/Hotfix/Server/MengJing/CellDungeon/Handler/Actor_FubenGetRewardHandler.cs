using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class Actor_FubenGetRewardHandler : MessageLocationHandler<Unit, Actor_GetFubenRewardRequest, Actor_GetFubenRewardReponse>
    {
        protected override async ETTask Run(Unit unit, Actor_GetFubenRewardRequest request, Actor_GetFubenRewardReponse response)
        {
            //需要验证, 奖励的数据放在fubencompoentsystem

            List<RewardItem> rewardItems = new List<RewardItem>();
            rewardItems.Add(request.RewardItem);
            unit.GetComponent<BagComponentS>().OnAddItemData(rewardItems, string.Empty, $"{ItemGetWay.FubenGetReward}_{TimeHelper.ServerNow()}");

            response.Error = ErrorCode.ERR_Success;
            await ETTask.CompletedTask;
        }
    }
}
