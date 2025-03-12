using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_DamageValueListRequestHandler : MessageLocationHandler<Unit, C2M_DamageValueListRequest, M2C_DamageValueListResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_DamageValueListRequest request, M2C_DamageValueListResponse response)
        {
            response.DamageValueList .AddRange(unit.GetComponent<AttackRecordComponent>().DamageValueList);

            await ETTask.CompletedTask;
        }
    }
}