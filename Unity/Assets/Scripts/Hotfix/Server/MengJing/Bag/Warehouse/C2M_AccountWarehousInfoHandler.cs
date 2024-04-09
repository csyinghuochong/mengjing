using System;
using System.Collections.Generic;

namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_AccountWarehousInfoHandler: MessageLocationHandler<Unit, C2M_AccountWarehousInfoRequest, M2C_AccountWarehousInfoResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_AccountWarehousInfoRequest request, M2C_AccountWarehousInfoResponse response)
        {
            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.LoginAccount, request.AccInfoID))
            {
                DBAccountInfo dBAccountWarehouse = await UnitCacheHelper.GetComponentBD<DBAccountInfo>(unit.Root(), request.AccInfoID);
                if (dBAccountWarehouse != null)
                {
                    response.BagInfos = dBAccountWarehouse.BagInfoList;
                }
            }
            await ETTask.CompletedTask;
        }
    }
}
