using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Rank)]
    public class C2R_RankSeasonTowerHandler : MessageHandler<Scene, C2R_RankSeasonTowerRequest, R2C_RankSeasonTowerResponse>
    {
        protected override async ETTask Run(Scene scene, C2R_RankSeasonTowerRequest request, R2C_RankSeasonTowerResponse response)
        {
            long timeNow = TimeHelper.ServerNow();
            RankSceneComponent rankComponent = scene.GetComponent<RankSceneComponent>();

            if (timeNow - rankComponent.RankSeasonTowerLastTime < TimeHelper.Second * 10)
            {
                response.RankList .AddRange(rankComponent.RankSeasonTowers); 
            }
            else
            {
                rankComponent.RankSeasonTowers.Clear();
                List<KeyValuePairLong> ranklist = rankComponent.DBRankInfo.rankSeasonTower;

                List<long> idlist = new List<long>();
                List<long> idremove = new List<long>();

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
                    RankSeasonTowerInfo RankSeasonTowerInfo = RankSeasonTowerInfo.Create();
                    RankSeasonTowerInfo.UserId = ranklist[i].KeyId;
                    RankSeasonTowerInfo.TotalTime = ranklist[i].Value;        //时间
                    RankSeasonTowerInfo.FubenId = (int)(ranklist[i].Value2);  //副本
                    RankSeasonTowerInfo.PlayerLv = unionInfoCache.Lv;
                    RankSeasonTowerInfo.PlayerName = unionInfoCache.Name;
                    RankSeasonTowerInfo.Occ = unionInfoCache.Occ;
                    rankComponent.RankSeasonTowers.Add(RankSeasonTowerInfo);
                }
                rankComponent.RankSeasonTowerLastTime = TimeHelper.ServerNow();
                response.RankList.AddRange(rankComponent.RankSeasonTowers);

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
