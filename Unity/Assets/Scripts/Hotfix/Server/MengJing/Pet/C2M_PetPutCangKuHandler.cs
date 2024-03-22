using System;


namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetPutCangKuHandler : MessageLocationHandler<Unit, C2M_PetPutCangKu, M2C_PetPutCangKu>
    {
        protected override async ETTask Run(Unit unit, C2M_PetPutCangKu request, M2C_PetPutCangKu response)
        {
            PetComponent_S petComponent = unit.GetComponent<PetComponent_S>();
            RolePetInfo petinfo = petComponent.GetPetInfo(request.PetInfoId);
            if (petinfo == null)
            {
                response.Error = ErrorCode.ERR_Pet_NoExist;
                return;
            }
            if (request.PetStatus == 3)
            {
                int cangkupetNumber = PetHelper.GetCangKuPetNum(petComponent.RolePetInfos);
                if (cangkupetNumber >= petComponent.PetCangKuOpen.Count)
                {
                    response.Error = ErrorCode.ERR_CangKu_NotOpen;
                    return;
                }
            }

            petinfo.PetStatus= request.PetStatus;
            await ETTask.CompletedTask;
        }
    }
}
