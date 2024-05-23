﻿using System;
using System.Collections.Generic;


namespace ET
{
    [ActorMessageHandler]
    public class M2Center_ShareSucessHandler : AMActorRpcHandler<Scene, M2Center_ShareSucessRequest, Center2M_ShareSucessResponse>
    {
        protected override async ETTask Run(Scene scene, M2Center_ShareSucessRequest request, Center2M_ShareSucessResponse response, Action reply)
        {
            Log.Warning($"M2Center_ShareSucessRequest:{request.AccountId}");
            List<DBCenterAccountInfo> centerAccountInfoList = await Game.Scene.GetComponent<DBComponent>().Query<DBCenterAccountInfo>(scene.DomainZone(), d => d.Id == request.AccountId);
            //await Game.Scene.GetComponent<DBComponent>().Query<DBCenterAccountInfo>(202, d => d.Id == userInfo.AccInfoID);
            if (centerAccountInfoList == null || centerAccountInfoList.Count == 0)
            {
                response.Error = ErrorCode.ERR_NotFindAccount;
                reply();
                return;
            }
            int totalTimes = 0;
            long serverNow = TimeHelper.ServerNow();
            DBCenterAccountInfo dBAccountInfos = centerAccountInfoList[0];
            List<long> ShareTimes = dBAccountInfos.PlayerInfo.ShareTimes;
            for (int i = 0; i < ShareTimes.Count; i++)
            {
                if (ComHelp.GetDayByTime(serverNow) == ComHelp.GetDayByTime(ShareTimes[i]))
                {
                    totalTimes++;
                }
            }
            if (totalTimes >= 6)
            {
                response.Error = ErrorCode.ERR_FenXiangMaxNum;
                reply();
                return;
            }

            dBAccountInfos.PlayerInfo.ShareTimes.Add(serverNow);
            Game.Scene.GetComponent<DBComponent>().Save<DBCenterAccountInfo>(scene.DomainZone(), dBAccountInfos).Coroutine();
            reply();
            await ETTask.CompletedTask;
        }
    }
}
