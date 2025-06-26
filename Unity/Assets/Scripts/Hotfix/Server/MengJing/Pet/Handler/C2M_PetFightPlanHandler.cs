namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetFightPlanHandler : MessageLocationHandler<Unit, C2M_PetFightPlanRequest, M2C_PetFightPlanResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetFightPlanRequest request, M2C_PetFightPlanResponse response)
        {
            if (request.PetFightPlan < 0 || request.PetFightPlan > 2)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            TransferHelper.RemoveFightPetList(unit);
            unit.GetComponent<PetComponentS>().PetFightPlan = request.PetFightPlan;
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.PetFightIndex, 0);
            TransferHelper.CreateFightPetList(unit);

            await ETTask.CompletedTask;
        }
    }
}