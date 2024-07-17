namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RolePetProtectHandler : MessageLocationHandler<Unit, C2M_RolePetProtect, M2C_RolePetProtect>
    {
        protected override async ETTask Run(Unit unit, C2M_RolePetProtect request, M2C_RolePetProtect response)
        {
            RolePetInfo rolePetInfo = unit.GetComponent<PetComponentS>().GetPetInfo(request.PetInfoId);
            if (rolePetInfo == null)
            {
                response.Error = ErrorCode.ERR_Pet_NoExist;
                return;
            }

            rolePetInfo.IsProtect = request.IsProtect;
            await ETTask.CompletedTask;
        }
    }
}
