using System;

namespace ET.Server
{

    public class C2M_BagInitHandler : MessageLocationHandler<Unit, C2M_BagInitRequest, M2C_BagInitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_BagInitRequest request, M2C_BagInitResponse response)
        {
            await ETTask.CompletedTask;

            BagComponentServer bagComponentServer = unit.GetComponent<BagComponentServer>();
        }
    }
}