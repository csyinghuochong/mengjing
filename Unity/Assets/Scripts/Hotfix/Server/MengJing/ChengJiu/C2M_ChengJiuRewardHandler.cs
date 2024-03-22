

using System;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(ChengJiuComponent_S))]
    public class C2M_ChengJiuRewardHandler : MessageLocationHandler<Unit, C2M_ChengJiuRewardRequest, M2C_ChengJiuRewardResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_ChengJiuRewardRequest request, M2C_ChengJiuRewardResponse response)
        {
            ChengJiuComponent_S chengJiuComponent = unit.GetComponent<ChengJiuComponent_S>();
            if (!ChengJiuRewardConfigCategory.Instance.Contain(request.RewardId))
            {
                response.Error = ErrorCode.ERR_NetWorkError;
                return;
            }

            ChengJiuRewardConfig chengJiuConfig = ChengJiuRewardConfigCategory.Instance.Get(request.RewardId);
            if (chengJiuComponent.TotalChengJiuPoint < chengJiuConfig.NeedPoint)
            {
                return;
            }
            if (chengJiuComponent.AlreadReceivedId.Contains(request.RewardId))
            {
                return;
            }

            response.Error = chengJiuComponent.ReceivedReward(request.RewardId);
            await ETTask.CompletedTask;
        }
    }
}