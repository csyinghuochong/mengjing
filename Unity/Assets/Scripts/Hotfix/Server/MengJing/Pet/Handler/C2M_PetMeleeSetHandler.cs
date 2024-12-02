namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetMeleeSetHandler : MessageLocationHandler<Unit, C2M_PetMeleeSetRequest, M2C_PetMeleeSetResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetMeleeSetRequest request, M2C_PetMeleeSetResponse response)
        {
            if (request.PetMeleeInfo == null)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            if (request.PetMeleeInfo.MainPetList.Count >= ConfigData.PetMeleeMainMaxNum)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            if (request.PetMeleeInfo.AssistPetList.Count >= ConfigData.PetMeleeAssistMaxNum)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            if (request.PetMeleeInfo.SkillList.Count >= ConfigData.PetMeleeSkillMaxNum)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            PetComponentS petComponent = unit.GetComponent<PetComponentS>();
            petComponent.PetMeleeInfoList[petComponent.PetMeleePlan].Dispose();
            petComponent.PetMeleeInfoList[petComponent.PetMeleePlan] = request.PetMeleeInfo;

            await ETTask.CompletedTask;
        }
    }
}