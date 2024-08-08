using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.LoginCenter)]
    public class M2L_ShareSucessHandler : MessageHandler<Scene, M2L_ShareSucessRequest, L2M_ShareSucessResponse>
    {
        protected override async ETTask Run(Scene scene, M2L_ShareSucessRequest request, L2M_ShareSucessResponse response)
        {
            Log.Warning($"M2Center_ShareSucessRequest:{request.AccountId}");
            DBManagerComponent dbManagerComponent = scene.Root().GetComponent<DBManagerComponent>();
            DBComponent dbComponent = dbManagerComponent.GetZoneDB(scene.Zone());
            
            List<DBCenterAccountInfo> centerAccountInfoList = await dbComponent.Query<DBCenterAccountInfo>(scene.Zone(), d => d.Id == request.AccountId);
            //await Game.Scene.GetComponent<DBComponent>().Query<DBCenterAccountInfo>(202, d => d.Id == userInfo.AccInfoID);
            if (centerAccountInfoList == null || centerAccountInfoList.Count == 0)
            {
                response.Error = ErrorCode.ERR_NotFindAccount;
                return;
            }
            int totalTimes = 0;
            long serverNow = TimeHelper.ServerNow();
            DBCenterAccountInfo dBAccountInfos = centerAccountInfoList[0];
            List<long> ShareTimes = dBAccountInfos.PlayerInfo.ShareTimes;
            for (int i = 0; i < ShareTimes.Count; i++)
            {
                if (CommonHelp.GetDayByTime(serverNow) == CommonHelp.GetDayByTime(ShareTimes[i]))
                {
                    totalTimes++;
                }
            }
            if (totalTimes >= 6)
            {
                response.Error = ErrorCode.ERR_FenXiangMaxNum;
                return;
            }

            dBAccountInfos.PlayerInfo.ShareTimes.Add(serverNow);
            dbComponent.Save<DBCenterAccountInfo>(scene.Zone(), dBAccountInfos).Coroutine();
            await ETTask.CompletedTask;
        }
    }
}
