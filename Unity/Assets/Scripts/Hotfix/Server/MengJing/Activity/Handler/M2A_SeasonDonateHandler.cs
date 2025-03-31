using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Activity)]
    [FriendOf(typeof(ActivitySceneComponent))]
    public class M2A_SeasonDonateHandler : MessageHandler<Scene, M2A_SeasonDonateRequest, A2M_SeasonDonateResponse>
    {

        protected override async ETTask Run(Scene scene, M2A_SeasonDonateRequest request, A2M_SeasonDonateResponse response)
        {
            
            DBDayActivityInfo petMingPlayerInfos = scene.GetComponent<ActivitySceneComponent>().DBDayActivityInfo;
            
            petMingPlayerInfos.CommonSeasonBossExp += 1;

            long seasonbossexp = petMingPlayerInfos.CommonSeasonBossExp;
            int seasonbosslevel = petMingPlayerInfos.CommonSeasonBossLevel;
            long upneedLevel = ConfigData.CommonSeasonBossList[ seasonbosslevel ].Value;
            
           
            bool uplevel = false;    //是否升级
            if (seasonbossexp >= upneedLevel && seasonbosslevel < ConfigData.CommonSeasonBossList.Count)
            {
                petMingPlayerInfos.CommonSeasonBossLevel += 1;
                petMingPlayerInfos.CommonSeasonBossExp = 0;
                petMingPlayerInfos.CommonSeasonBossRefreshTime = TimeHelper.ServerNow();
                uplevel = true;
            }
            
            if (uplevel)
            {
                ///
                
            }
           
            await ETTask.CompletedTask;
        }
    }
}
