using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.LoginCenter)]
    public class M2L_CenterServerInfoHandler : MessageHandler<Scene, M2L_CenterServerInfoReuest, L2M_CenterServerInfoRespone>
    {

        protected override async ETTask Run(Scene scene, M2L_CenterServerInfoReuest request, L2M_CenterServerInfoRespone response)
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
