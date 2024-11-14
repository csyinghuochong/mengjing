using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetBarSetHandler: MessageLocationHandler<Unit, C2M_PetBarSetRequest, M2C_PetBarSetResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetBarSetRequest request, M2C_PetBarSetResponse response)
        {
            PetComponentS petComponent = unit.GetComponent<PetComponentS>();
            petComponent.PetFightList = request.PetBarList;
            await ETTask.CompletedTask;
        }
    }
}

