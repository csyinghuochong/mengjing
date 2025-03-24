using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    [MessageHandler(SceneType.Rank)]
    public class C2R_RankLastRewardHandler : MessageHandler<Scene, C2R_RankLastRewardRequest, R2C_RankLastRewardResponse>
    {
        protected override async ETTask Run(Scene scene, C2R_RankLastRewardRequest request, R2C_RankLastRewardResponse response)
        {
            RankSceneComponent rankComponent = scene.GetComponent<RankSceneComponent>();
            
            List<long> lastIds = new List<long>();
          
            switch (request.RankType)
            {
                case 1:
                    lastIds = rankComponent.DBRankInfo.LastRewardCombatIds;
                    break;
                case 2:
                    lastIds = rankComponent.DBRankInfo.LastRewardPetIds;
                    break;
            }

            List<RankingInfo> all = new List<RankingInfo>();

            for (int i = 0; i < lastIds.Count; i++)
            {
                UserInfoComponentS userInfoComponent = await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(scene.Root(), lastIds[i]);
                userInfoComponent.DeserializeDB();

                RankingInfo rankingInfo = RankingInfo.Create();
                rankingInfo.UserId = lastIds[i];
                rankingInfo.PlayerName = userInfoComponent.UserInfo.Name;
                rankingInfo.Occ = userInfoComponent.UserInfo.Occ;
                rankingInfo.PlayerLv = userInfoComponent.UserInfo.Lv;
            }
            
            response.LastRewardList.AddRange(all);

            if (response.LastRewardList.Count == 0 && rankComponent.DBRankInfo.rankingCombats.Count > 0)
            {
                response.LastRewardList.Add(rankComponent.DBRankInfo.rankingCombats[0]);
            }
            
            await ETTask.CompletedTask;
        }
    }
}
