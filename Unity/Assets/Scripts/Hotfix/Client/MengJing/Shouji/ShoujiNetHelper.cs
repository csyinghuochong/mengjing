using System.Collections.Generic;

namespace ET.Client
{
    public static partial class ShoujiNetHelper
    {
        public static async ETTask<M2C_ShouJiTreasureResponse> ShouJiTreasure(Scene root, List<long> itemIds, int shouJiId)
        {
            C2M_ShouJiTreasureRequest request = C2M_ShouJiTreasureRequest.Create();
            request.ItemIds = itemIds;
            request.ShouJiId = shouJiId;

            M2C_ShouJiTreasureResponse response = (M2C_ShouJiTreasureResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error == ErrorCode.ERR_Success)
            {
                root.GetComponent<ShoujiComponentC>().OnShouJiTreasure(shouJiId, response.ActiveNum);
            }
            
            return response;
        }

        public static async ETTask<M2C_ShoujiRewardResponse> ShoujiReward(Scene root, int chapterId, int rewardIndex)
        {
            C2M_ShoujiRewardRequest request = C2M_ShoujiRewardRequest.Create();
            request.ChapterId = chapterId;
            request.RewardIndex = rewardIndex;

            M2C_ShoujiRewardResponse response = (M2C_ShoujiRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error == ErrorCode.ERR_Success)
            {
                ShoujiComponentC shoujiComponent = root.GetComponent<ShoujiComponentC>();
                ShouJiChapterInfo shouJiChapterInfo = shoujiComponent.GetShouJiChapterInfo(chapterId);
                shouJiChapterInfo.RewardInfo |= (1 << rewardIndex);
            }

            return response;
        }
    }
}