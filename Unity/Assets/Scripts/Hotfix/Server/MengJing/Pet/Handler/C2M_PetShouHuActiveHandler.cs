namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetShouHuActiveHandler : MessageLocationHandler<Unit, C2M_PetShouHuActiveRequest, M2C_PetShouHuActiveResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetShouHuActiveRequest request, M2C_PetShouHuActiveResponse response)
        {
            unit.GetComponent<PetComponentS>().PetShouHuActive  = request.PetShouHuActive;
            response.PetShouHuActive = request.PetShouHuActive;
            Function_Fight.UnitUpdateProperty_Base( unit, true, true );
            await ETTask.CompletedTask;
        }
    }
}
