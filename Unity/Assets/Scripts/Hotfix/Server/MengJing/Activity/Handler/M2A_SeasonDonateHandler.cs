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
                petMingPlayerInfos.CommonSeasonBossRefreshState = 1;
                uplevel = true;
            }
            
            if (uplevel)
            {
                M2F_FubenSceneIdRequest M2F_FubenSceneIdRequest = M2F_FubenSceneIdRequest.Create();
                M2F_FubenSceneIdRequest.SceneId =  SceneConfigHelper.GetSceneListByType(MapTypeEnum.MiJing)[0];
                F2M_FubenSceneIdResponse f2M_YeWaiSceneIdResponse = (F2M_FubenSceneIdResponse)await scene.Root().GetComponent<MessageSender>().Call(
                    UnitCacheHelper.GetFubenCenterId(scene.Zone()), M2F_FubenSceneIdRequest);
                
                M2M_SeasonDonateCreateBossRequest mSeasonDonateCreateBossRequest = M2M_SeasonDonateCreateBossRequest.Create();
                mSeasonDonateCreateBossRequest.SeasonBossLevel = petMingPlayerInfos.CommonSeasonBossLevel - 1;
                M2M_SeasonDonateCreateBossResponse mSeasonDonateCreateBossResponse = (M2M_SeasonDonateCreateBossResponse)await scene.Root().GetComponent<MessageSender>().Call(
                    f2M_YeWaiSceneIdResponse.FubenActorId, mSeasonDonateCreateBossRequest);
            }

            response.CommonSeasonBossExp = petMingPlayerInfos.CommonSeasonBossExp;
            response.CommonSeasonBossLevel = petMingPlayerInfos.CommonSeasonBossLevel;
            await ETTask.CompletedTask;
        }
    }
}
