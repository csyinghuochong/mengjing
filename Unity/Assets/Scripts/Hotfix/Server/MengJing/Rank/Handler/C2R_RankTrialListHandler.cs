using System;
using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Rank)]
    public class C2R_RankTrialListHandler : MessageHandler<Scene, C2R_RankTrialListRequest, R2C_RankTrialListResponse>
    {

        protected override async ETTask Run(Scene scene, C2R_RankTrialListRequest request, R2C_RankTrialListResponse response)
        {
            long timeNow = TimeHelper.ServerNow();
            RankSceneComponent rankComponent = scene.GetComponent<RankSceneComponent>();

            if (timeNow - rankComponent.RankingTrialLastTime < TimeHelper.Minute)
            {
                response.RankList = rankComponent.RankingTrials;
            }
            else
            {
                List<KeyValuePairLong> ranklist = rankComponent.DBRankInfo.rankingTrial;
              
                List<long> idlist = new List<long>();
                List<long> idremove = new List<long> (); 

                for (int i = 0; i < ranklist.Count; i++)
                {
                    if (idlist.Contains(ranklist[i].KeyId))
                    {
                        idremove.Add(ranklist[i].KeyId);
                        continue;
                    }

                    idlist.Add(ranklist[i].KeyId);

                    UserInfoComponentS userinfoComponent =
                            await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(scene.Root(), ranklist[i].KeyId);
                    response.RankList.Add(new RankingTrialInfo()
                    { 
                        UserId = ranklist[i].KeyId,
                        Hurt = ranklist[i].Value,
                        FubenId = (int)(ranklist[i].Value2),
                        PlayerLv = userinfoComponent.UserInfo.Lv,
                        PlayerName = userinfoComponent.UserInfo.Name,   
                        Occ = userinfoComponent.UserInfo.Occ,
                    });
                }
                rankComponent.RankingTrialLastTime = TimeHelper.ServerNow();
                rankComponent.RankingTrials = response.RankList;

                for (int remove = 0; remove < idremove.Count; remove++)
                {
                    for (int i = ranklist.Count - 1; i >= 0; i--)
                    {
                        if (ranklist[i].KeyId == idremove[remove])
                        {
                            ranklist.RemoveAt(i);   
                            break;
                        }
                    }
                }
            }
            
            await ETTask.CompletedTask;
        }
    }
}
