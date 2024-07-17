namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetTargetLockHandler : MessageLocationHandler<Unit, C2M_PetTargetLockRequest, M2C_PetTargetLockResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetTargetLockRequest request, M2C_PetTargetLockResponse response)
        {
            unit.GetComponent<AttackRecordComponent>().PetLockId = request.TargetId;
            
            await ETTask.CompletedTask;
        }
    }
}
