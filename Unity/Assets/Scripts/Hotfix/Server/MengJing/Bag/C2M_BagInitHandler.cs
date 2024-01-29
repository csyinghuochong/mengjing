using System;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_BagInitHandler : MessageLocationHandler<Unit, C2M_BagInitRequest, M2C_BagInitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_BagInitRequest request, M2C_BagInitResponse response)
        {
          
            BagComponentServer bagComponentServer = unit.GetComponent<BagComponentServer>();
            response.BagInfos = bagComponentServer.BagItemList;

            await ETTask.CompletedTask;

        }
    }
}