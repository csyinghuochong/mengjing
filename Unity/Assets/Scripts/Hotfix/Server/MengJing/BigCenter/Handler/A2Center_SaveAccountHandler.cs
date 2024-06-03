using System;
using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.BigCenter)]
    public class A2Center_SaveAccountHandler : MessageHandler<Scene, A2Center_SaveAccount, Center2A_SaveAccount>
    {
        protected override async ETTask Run(Scene scene, A2Center_SaveAccount request, Center2A_SaveAccount response)
        { 
            Log.Warning($"Save<DBCenterAccountInfo>3333: { scene.Zone()}");
            DBManagerComponent dbManagerComponent = scene.Root().GetComponent<DBManagerComponent>();
            DBComponent dbComponent = dbManagerComponent.GetZoneDB(scene.Zone());
            
            List<DBCenterAccountInfo> resulets = await dbComponent.Query<DBCenterAccountInfo>(scene.Zone(), d => d.Id == request.AccountId);

            DBCenterAccountInfo dBCenterAccountInfo = null;
            if (resulets != null && resulets.Count > 0)
            {
                dBCenterAccountInfo = resulets[0];
            }
            else
            {
                dBCenterAccountInfo = scene.AddChildWithId<DBCenterAccountInfo>(request.AccountId);
            }
            dBCenterAccountInfo.Account = request.AccountName;
            dBCenterAccountInfo.Password = request.Password;
            dBCenterAccountInfo.PlayerInfo = request.PlayerInfo;
           
            await dbComponent.Save(scene.Zone(), dBCenterAccountInfo);
            dBCenterAccountInfo.Dispose();
            await ETTask.CompletedTask;
        }
    }
}
