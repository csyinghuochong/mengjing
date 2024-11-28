﻿namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetMeleePlanHandler : MessageLocationHandler<Unit, C2M_PetMeleePlanRequest, M2C_PetMeleePlanResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetMeleePlanRequest request, M2C_PetMeleePlanResponse response)
        {
            if (request.PetMeleePlan < 0 || request.PetMeleePlan > 2)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            unit.GetComponent<PetComponentS>().PetMeleePlan = request.PetMeleePlan;

            await ETTask.CompletedTask;
        }
    }
}