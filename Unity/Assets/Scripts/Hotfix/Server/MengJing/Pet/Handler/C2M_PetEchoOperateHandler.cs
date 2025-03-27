namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetEchoOperateHandler : MessageLocationHandler<Unit, C2M_PetEchoOperateRequest, M2C_PetEchoOperateResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetEchoOperateRequest request, M2C_PetEchoOperateResponse response)
        {
            PetComponentS petComponentS = unit.GetComponent<PetComponentS>();
            
            switch (request.OperateType)
            {
                case 1:
                    string[] openlist = ConfigData.PetEchoAttri[request.Position].Value2.Split("&");
             
                    int needlv = int.Parse(openlist[0]);
                    UserInfoComponentS userInfoComponentS = unit.GetComponent<UserInfoComponentS>();
                    if (userInfoComponentS.UserInfo.Lv < needlv)
                    {
                        response.Error = ErrorCode.ERR_LevelIsNot;
                        return;
                    }
              
                    BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
                    if (!bagComponent.OnCostItemData(openlist[1]))
                    {
                        response.Error = ErrorCode.ERR_ItemNotEnoughError;
                        return;
                    }
                    
                    petComponentS.PetEchoList[request.Position].KeyId = 1;
                    break;
                case 2:
                    int oldIndex = petComponentS.PetEchoList.FindIndex(p => p.Value == request.ParamId);
                    
                    petComponentS.PetEchoList[request.Position].Value = request.ParamId;

                    if (oldIndex != -1)
                    {
                        petComponentS.PetEchoList[oldIndex].Value = 0;
                    }

                    int totalCombat = PetHelper.GetPetTotalCombat(petComponentS.RolePetInfos, petComponentS.PetEchoList);
                    SkillSetComponentS skillSetComponentS = unit.GetComponent<SkillSetComponentS>();    
                    skillSetComponentS.UpdatePetEchoSkill(totalCombat);
                    
                    break;
            }
            response.PetEchoList .AddRange( petComponentS.PetEchoList );  
            await ETTask.CompletedTask;
        }
    }
}