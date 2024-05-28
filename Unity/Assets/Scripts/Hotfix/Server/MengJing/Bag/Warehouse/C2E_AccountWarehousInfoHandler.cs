using System;
using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2E_AccountWarehousInfoHandler : MessageHandler<Scene, C2E_AccountWarehousInfoRequest, E2C_AccountWarehousInfoResponse>
    {
        protected override async ETTask Run(Scene scene, C2E_AccountWarehousInfoRequest request, E2C_AccountWarehousInfoResponse response)
        {
            using (await scene.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.LoginAccount, request.AccInfoID))
            {
                DBAccountInfo dBAccountWarehouse = await UnitCacheHelper.GetComponent<DBAccountInfo>(scene.Root(), request.AccInfoID);
                if (dBAccountWarehouse != null)
                {
                    response.BagInfos = dBAccountWarehouse.BagInfoList;
                }

            }
            await ETTask.CompletedTask;
        }
    }
}
