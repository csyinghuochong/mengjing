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
                response.RankList .AddRange(rankComponent.RankingTrials); 
            }
            else
            {
                rankComponent.RankingTrials .Clear();
                
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

                    UserInfoComponentS userInfoComponent = await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(scene.Root(), ranklist[i].KeyId);
                    UserInfo unionInfoCache = userInfoComponent.ChildrenDB[0] as UserInfo;
                    RankingTrialInfo RankingTrialInfo = RankingTrialInfo.Create();
                    RankingTrialInfo.UserId = ranklist[i].KeyId;
                    RankingTrialInfo.Hurt = ranklist[i].Value;
                    RankingTrialInfo.FubenId = (int)(ranklist[i].Value2);
                    RankingTrialInfo.PlayerLv = unionInfoCache.Lv;
                    RankingTrialInfo.PlayerName = unionInfoCache.Name;
                    RankingTrialInfo.Occ = unionInfoCache.Occ;
                    rankComponent.RankingTrials.Add(RankingTrialInfo);
                }
                rankComponent.RankingTrialLastTime = TimeHelper.ServerNow();
                response.RankList.AddRange(rankComponent.RankingTrials);

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
