namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_ShoujiRewardHandler : MessageLocationHandler<Unit, C2M_ShoujiRewardRequest, M2C_ShoujiRewardResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ShoujiRewardRequest request, M2C_ShoujiRewardResponse response)
        {
            ShoujiComponentS shoujiComponent = unit.GetComponent<ShoujiComponentS>();
            ShouJiChapterInfo shouJiChapterInfo = shoujiComponent.GetShouJiChapterInfo(request.ChapterId);
            if (!ShouJiConfigCategory.Instance.Contain(request.ChapterId))
            {
                Log.Error($"C2M_ShoujiRewardRequest 1");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }
            ShouJiConfig shouJiConfig = ShouJiConfigCategory.Instance.Get(request.ChapterId);
            if (request.RewardIndex == 1 && shouJiChapterInfo.StarNum < shouJiConfig.ProList1_StartNum)
            {
                return;
            }
            if (request.RewardIndex == 2 && shouJiChapterInfo.StarNum < shouJiConfig.ProList2_StartNum)
            {
                return;
            }
            if (request.RewardIndex == 3 && shouJiChapterInfo.StarNum < shouJiConfig.ProList3_StartNum)
            {
                return;
            }
            if ((shouJiChapterInfo.RewardInfo & 1 << request.RewardIndex) > 0)
            {
                return;
            }

            string rewards = "";
            if (request.RewardIndex == 3) rewards = shouJiConfig.RewardList_3;
            if (request.RewardIndex == 2) rewards = shouJiConfig.RewardList_2;
            if (request.RewardIndex == 1) rewards = shouJiConfig.RewardList_1;
            if (!unit.GetComponent<BagComponentS>().OnAddItemData(rewards, $"{ItemGetWay.ShoujiReward}_{TimeHelper.ServerNow()}"))
            {
                return;
            }
            shouJiChapterInfo.RewardInfo |= (1 << request.RewardIndex);
            await ETTask.CompletedTask;
        }

    }
}
