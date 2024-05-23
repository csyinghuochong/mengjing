using System;
using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Center)]
    public class C2Center_DeleteAccountHandler : MessageHandler<Session, C2Center_DeleteAccountRequest, Center2C_DeleteAccountResponse>
    {
        protected override async ETTask Run(Session session, C2Center_DeleteAccountRequest request, Center2C_DeleteAccountResponse response)
        {
            Log.Warning($"C2Center_DeleteAccountRequest: { session.Zone()}");
            DBManagerComponent dbManagerComponent = session.Root().GetComponent<DBManagerComponent>();
            DBComponent dbComponent = dbManagerComponent.GetZoneDB(session.Zone());
            
            List<DBCenterAccountInfo> centerAccountInfoList = await dbComponent.Query<DBCenterAccountInfo>(session.Zone(), d => d.Account == request.Account && d.Password == request.Password);
            DBCenterAccountInfo dBCenterAccountInfo = centerAccountInfoList != null && centerAccountInfoList.Count > 0 ? centerAccountInfoList[0] : null;
            if (dBCenterAccountInfo != null)
            {
                ///确认要不要删除所有区服的账号数据
                //dBCenterAccountInfo.AccountType = 2;////(int)AccountType.Delete;
                //await Game.Scene.GetComponent<DBComponent>().Save<DBCenterAccountInfo>(session.DomainZone(), dBCenterAccountInfo); 
                await dbComponent.Remove<DBCenterAccountInfo>(session.Zone(), dBCenterAccountInfo.Id);

                List<int> allZones = BroadMessageHelper.GetAllZone();
                for ( int i = 0; i < allZones.Count; i++ )
                { 
                    int pzone = allZones[i];
                    await dbComponent.Remove<DBAccountInfo>(pzone, dBCenterAccountInfo.Id);
                }
            }
            else
            {
            }
            //response.PlayerInfo = dBCenterAccountInfo != null ? dBCenterAccountInfo.PlayerInfo : null;
            //response.AccountId = dBCenterAccountInfo != null ? dBCenterAccountInfo.Id : 0;
            await ETTask.CompletedTask;
        }
    }
}