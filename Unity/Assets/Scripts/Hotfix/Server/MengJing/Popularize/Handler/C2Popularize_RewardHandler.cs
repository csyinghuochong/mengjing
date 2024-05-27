using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2Popularize_RewardHandler : MessageHandler<Scene, C2Popularize_RewardRequest, Popularize2C_RewardResponse>
    {
        protected override async ETTask Run(Scene scene, C2Popularize_RewardRequest request, Popularize2C_RewardResponse response)
        {
            using (await scene.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Popularize, request.ActorId))
            {
                DBPopularizeInfo dBPopularizeInfo = await UnitCacheHelper.GetComponent<DBPopularizeInfo>(scene.Root(), request.ActorId);
                if (dBPopularizeInfo == null)
                {
                    return;
                }

                for (int i = 0; i < dBPopularizeInfo.MyPopularizeList.Count; i++)
                {
                    long unitid = dBPopularizeInfo.MyPopularizeList[i].UnitId;
                    int oldZone = UnitIdStruct.GetUnitZone(unitid);
                    int newZone = ServerHelper.GetNewServerId(oldZone);
                    if (newZone < 5)
                    {
                        continue;
                    }
                    UserInfoComponentS userInfoComponent = await UnitCacheHelper.GetComponent<UserInfoComponentS>(scene.Root(), unitid);
                    if (userInfoComponent == null)
                    {
                        continue;
                    }
                    dBPopularizeInfo.MyPopularizeList[i].Nmae = userInfoComponent.UserInfo.Name;
                    dBPopularizeInfo.MyPopularizeList[i].Level = userInfoComponent.UserInfo.Lv;
                    dBPopularizeInfo.MyPopularizeList[i].Occ = userInfoComponent.UserInfo.Occ;
                    dBPopularizeInfo.MyPopularizeList[i].OccTwo = userInfoComponent.UserInfo.OccTwo;
                }
                List<RewardItem> rewardItems = PopularizeHelper.GetRewardList(dBPopularizeInfo.MyPopularizeList);

                Log.Warning($"推广奖励: {request.ActorId}  {rewardItems.Count}");

                Popularize2M_RewardRequest rewardRequest = new Popularize2M_RewardRequest() { ReardList = rewardItems };
                M2Popularize_RewardResponse reqEnter = (M2Popularize_RewardResponse)await scene.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Call(request.ActorId, rewardRequest);
                //(M2Popularize_RewardResponse)await MessageHelper.CallLocationActor(request.ActorId, rewardRequest);
                if (reqEnter.Error == ErrorCode.ERR_Success)
                {
                    await UnitCacheHelper.SaveComponent(scene.Root(), request.ActorId, dBPopularizeInfo);
                }

            }

            reply();
            await ETTask.CompletedTask;
        }
    }
}
