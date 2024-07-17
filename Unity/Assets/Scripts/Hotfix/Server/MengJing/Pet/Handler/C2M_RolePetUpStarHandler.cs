namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RolePetUpStarHandler : MessageLocationHandler<Unit, C2M_RolePetUpStar, M2C_RolePetUpStar>
    {
        protected override async ETTask Run(Unit unit, C2M_RolePetUpStar request, M2C_RolePetUpStar response)
        {

            PetComponentS petComponent = unit.GetComponent<PetComponentS>();
          
            //获取当前操作宠物星数
            float upStartLvPro = 0;
            RolePetInfo rolePetInfo = petComponent.GetPetInfo(request.PetInfoId);
            switch (rolePetInfo.Star) {

                case 0:
                    upStartLvPro = 0.25f;
                    break;

                case 1:
                    upStartLvPro = 0.25f;
                    break;

                case 2:
                    upStartLvPro = 0.2f;
                    break;

                case 3:
                    upStartLvPro = 0.15f;
                    break;

                case 4:
                    upStartLvPro = 0.1f;
                    break;

            }

            //设置概率              
            upStartLvPro = upStartLvPro * request.CostPetInfoIds.Count;
            bool starError = false;
            //判断是否符合宠物条件
            for (int i = 0; i < request.CostPetInfoIds.Count; i++)
            {
                //判断星数是否符合
                if (petComponent.GetPetInfo(request.CostPetInfoIds[i]).Star < rolePetInfo.Star) 
                {
                    
                    starError = true;
                }
            }

            if (starError)
            {
                response.Error = ErrorCode.ERR_Pet_Hint_1;
                return;
            }

            bool success = RandomHelper.RandFloat() <= upStartLvPro;
            if (!success)
            {
                response.Error = ErrorCode.ERR_Pet_UpStar;
                return;
            }

            rolePetInfo.Star++;
            for (int i = 0; i < request.CostPetInfoIds.Count; i++)
            {
                petComponent.RemovePet(request.CostPetInfoIds[i]);
            }
            response.rolePetInfo = rolePetInfo;
            
            await ETTask.CompletedTask;
        }
    }
}
