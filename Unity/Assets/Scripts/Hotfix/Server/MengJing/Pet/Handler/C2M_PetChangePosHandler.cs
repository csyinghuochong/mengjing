using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetChangePosHandler: MessageLocationHandler<Unit, C2M_PetChangePosRequest, M2C_PetChangePosResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetChangePosRequest request, M2C_PetChangePosResponse response)
        {
            
            PetComponentS petComponent = unit.GetComponent<PetComponentS>();
            List<RolePetInfo> RolePetInfos = petComponent.GetAllPets();
            if (request.Index1 < 0 || request.Index1 >= RolePetInfos.Count)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            if (request.Index2 < 0 || request.Index2 >= RolePetInfos.Count)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            if (request.Index1 == request.Index2)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            (RolePetInfos[request.Index1], RolePetInfos[request.Index2]) =
                    (RolePetInfos[request.Index2], RolePetInfos[request.Index1]);
            
            await ETTask.CompletedTask;
        }
    }
}

