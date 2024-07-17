namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanPetWalkHandler : MessageLocationHandler<Unit, C2M_JiaYuanPetWalkRequest, M2C_JiaYuanPetWalkResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanPetWalkRequest request, M2C_JiaYuanPetWalkResponse response)
        {
            RolePetInfo rolePetInfo = unit.GetComponent<PetComponentS>().GetPetInfo(request.PetId);
            if (rolePetInfo == null )
            {
                response.Error = ErrorCode.ERR_Pet_NoExist;
                return;
            }
            if (rolePetInfo.PetStatus == 1)
            {
                response.Error = ErrorCode.ERR_Pet_Hint_3;
                response.Message = "出战宠物";
                return;
            }

            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            JiaYuanConfig jiaYuanConfig = JiaYuanConfigCategory.Instance.Get(userInfoComponent.UserInfo.JiaYuanLv);
            if (request.Position == 1 &&  userInfoComponent.UserInfo.Lv < jiaYuanConfig.Lv)
            {
                response.Error = ErrorCode.ERR_JiaYuanLevel;
                return;
            }
            if (request.Position == 2 && userInfoComponent.UserInfo.Lv < jiaYuanConfig.Lv)
            {
                response.Error = ErrorCode.ERR_JiaYuanLevel;
                return;
            }

            JiaYuanPet jiaYuanPet = unit.GetComponent<JiaYuanComponentS>().GetJiaYuanPet(request.PetId);
          
            unit.GetComponent<PetComponentS>().OnPetWalk(request.PetId, request.PetStatus);
            unit.GetComponent<JiaYuanComponentS>().OnJiaYuanPetWalk(rolePetInfo, request.PetStatus, request.Position);
            UnitComponent unitComponent = unit.GetParent<UnitComponent>();
            if (request.PetStatus == 2)
            {
                if (unitComponent.Get(request.PetId) == null)
                {
                    UnitFactory.CreateJiaYuanPet(unit.Scene(), unit.Id, unit.GetComponent<JiaYuanComponentS>().GetJiaYuanPet(request.PetId) );
                }
            }
            if (request.PetStatus == 0)
            {
                if (unitComponent.Get(request.PetId) != null)
                {
                    unitComponent.Remove(request.PetId);
                }
                if (jiaYuanPet != null)
                {
                    unit.GetComponent<PetComponentS>().PetAddExp(rolePetInfo, (int)jiaYuanPet.CurExp);
                }
            }
            UnitCacheHelper.SaveComponentCache(unit.Root(), unit.GetComponent<JiaYuanComponentS>()).Coroutine();
            response.JiaYuanPetList .AddRange( unit.GetComponent<JiaYuanComponentS>().JiaYuanPetList_2);

            await ETTask.CompletedTask;
        }
    }
}
