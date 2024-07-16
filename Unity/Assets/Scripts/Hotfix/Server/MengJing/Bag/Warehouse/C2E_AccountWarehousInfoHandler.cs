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
                DBAccountBagInfo dBAccountWarehouse = await UnitCacheHelper.GetComponent<DBAccountBagInfo>(scene.Root(), request.AccInfoID);
                if (dBAccountWarehouse != null)
                {
                    response.BagInfos = dBAccountWarehouse.BagInfoList;
                }
                else
                {
                    DBAccountBagInfo dBAccountBagInfo = scene.AddChildWithId<DBAccountBagInfo>(request.AccInfoID);
                    UnitCacheHelper.SaveComponent(scene.Root(),request.AccInfoID, dBAccountBagInfo).Coroutine();
                }
            }
            await ETTask.CompletedTask;
        }
    }
}
