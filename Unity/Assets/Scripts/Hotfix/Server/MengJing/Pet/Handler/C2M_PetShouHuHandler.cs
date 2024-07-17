using System.Collections.Generic;

namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetShouHuHandler : MessageLocationHandler<Unit, C2M_PetShouHuRequest, M2C_PetShouHuResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetShouHuRequest request, M2C_PetShouHuResponse response)
        {
            RolePetInfo rolePetInfo = unit.GetComponent<PetComponentS>().GetPetInfo(request.PetInfoId);
            if (rolePetInfo == null || rolePetInfo.ShouHuPos == 0)
            {
                return;
            }

            List<long> shouhulist = unit.GetComponent<PetComponentS>().PetShouHuList;
            if (PetHelper.IsShenShou(rolePetInfo.ConfigId))
            {
                shouhulist[request.Position] = request.PetInfoId;
            }
            else
            {
                shouhulist[rolePetInfo.ShouHuPos - 1] = request.PetInfoId;
            }


            response.PetShouHuList .AddRange(shouhulist); 
            Function_Fight.UnitUpdateProperty_Base(  unit, true, true);
            await ETTask.CompletedTask;
        }
    }
}
