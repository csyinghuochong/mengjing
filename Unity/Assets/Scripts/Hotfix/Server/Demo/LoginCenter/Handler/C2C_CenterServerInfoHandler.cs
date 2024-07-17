using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.LoginCenter)]
    public class C2C_CenterServerInfoHandler : MessageHandler<Scene, C2C_CenterServerInfoReuest, C2C_CenterServerInfoRespone>
    {

        protected override async ETTask Run(Scene scene, C2C_CenterServerInfoReuest request, C2C_CenterServerInfoRespone response)
        {
            Log.Warning($"C2C_CenterServerInfoReuest:{request.Zone}");
            DBManagerComponent dbManagerComponent = scene.Root().GetComponent<DBManagerComponent>();
            DBComponent dbComponent = dbManagerComponent.GetZoneDB(scene.Zone());
            
            List<DBCenterServerInfo> result = await dbComponent.Query<DBCenterServerInfo>(scene.Zone(), d => d.Id == scene.Zone());
            DBCenterServerInfo dBServerInfo = result[0];
            switch (request.infoType)
            {
                case 1:     //充值是否开启
                    if (dBServerInfo.RechageDic.Contains(request.Zone))
                    {
                        response.Value = "1";
                    }
                    else
                    {
                        response.Value = dBServerInfo.RechageOpen.ToString();
                    }
                    break;
            }
            
            await ETTask.CompletedTask;
        }
    }
}
