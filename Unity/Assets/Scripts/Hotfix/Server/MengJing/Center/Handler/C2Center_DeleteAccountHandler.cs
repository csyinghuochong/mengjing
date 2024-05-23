﻿using System;
using System.Collections.Generic;

namespace ET
{

    [MessageHandler]
    public class C2Center_DeleteAccountHandler : AMRpcHandler<C2Center_DeleteAccountRequest, Center2C_DeleteAccountResponse>
    {
        protected override async ETTask Run(Session session, C2Center_DeleteAccountRequest request, Center2C_DeleteAccountResponse response, Action reply)
        {
            Log.Warning($"C2Center_DeleteAccountRequest: { session.DomainZone()}");
            List<DBCenterAccountInfo> centerAccountInfoList = await Game.Scene.GetComponent<DBComponent>().Query<DBCenterAccountInfo>(session.DomainZone(), d => d.Account == request.Account && d.Password == request.Password);
            DBCenterAccountInfo dBCenterAccountInfo = centerAccountInfoList != null && centerAccountInfoList.Count > 0 ? centerAccountInfoList[0] : null;
            if (dBCenterAccountInfo != null)
            {
                ///确认要不要删除所有区服的账号数据
                //dBCenterAccountInfo.AccountType = 2;////(int)AccountType.Delete;
                //await Game.Scene.GetComponent<DBComponent>().Save<DBCenterAccountInfo>(session.DomainZone(), dBCenterAccountInfo); 
                await Game.Scene.GetComponent<DBComponent>().Remove<DBCenterAccountInfo>(session.DomainZone(), dBCenterAccountInfo.Id);

                List<int> allZones = ServerMessageHelper.GetAllZone();
                for ( int i = 0; i < allZones.Count; i++ )
                { 
                    int pzone = allZones[i];
                    await Game.Scene.GetComponent<DBComponent>().Remove<DBAccountInfo>(pzone, dBCenterAccountInfo.Id);
                }
            }
            else
            {
            }




            //response.PlayerInfo = dBCenterAccountInfo != null ? dBCenterAccountInfo.PlayerInfo : null;
            //response.AccountId = dBCenterAccountInfo != null ? dBCenterAccountInfo.Id : 0;
            
            
            reply();
            await ETTask.CompletedTask;
        }
    }
}